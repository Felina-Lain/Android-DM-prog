using UnityEngine;

public class Gyroscope : MonoBehaviour 
{

	private const float LowPassFilterFactor = 0.2f;

	private Quaternion _baseIdentity =  Quaternion.Euler(90, 0, 0);
	private Quaternion _landscapeRight =  Quaternion.Euler(0, 0, 90);
	private Quaternion _landscapeLeft =  Quaternion.Euler(0, 0, -90);
	private Quaternion _upsideDown =  Quaternion.Euler(0, 0, 180);

	private Quaternion _baseOrientation =  Quaternion.Euler(90, 0, 0);
	private Quaternion _baseOrientationRotationFix =  Quaternion.identity;

	private Quaternion _referanceRotation = Quaternion.identity;

	void Start () 
	{
		AttachGyro();
	}

    //Update rotation based on the gyro. Slerp is used to smooth it
	void Update() 
	{
		transform.rotation = Quaternion.Slerp(transform.rotation, ConvertRotation(_referanceRotation * Input.gyro.attitude) * GetRotFix(), LowPassFilterFactor);
	}

	//Initialyze the gyro
	private void AttachGyro()
	{
		Input.gyro.enabled = true;
		CalculateBaseOrientation();
		CalculateReferenceRotation();
	}

    //Make the axis fit the real view
    //(Cause it's invert by default)
    //No one knows why
    //Unity black magic probably
	private static Quaternion ConvertRotation(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);	
	}


	//Make sure it works in every screen position
	private Quaternion GetRotFix()
	{
		#if UNITY_3_5
		if (Screen.orientation == ScreenOrientation.Portrait)
		return Quaternion.identity;

		if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.Landscape)
		return landscapeLeft;

		if (Screen.orientation == ScreenOrientation.LandscapeRight)
		return landscapeRight;

		if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
		return upsideDown;
		return Quaternion.identity;
		#else
		return Quaternion.identity;
		#endif
	}

	private void CalculateBaseOrientation()
	{
		_baseOrientationRotationFix = GetRotFix();
		_baseOrientation = _baseOrientationRotationFix * _baseIdentity;
	}


	private void CalculateReferenceRotation()
	{
		_referanceRotation = Quaternion.Inverse (_baseOrientation);
	}


}
