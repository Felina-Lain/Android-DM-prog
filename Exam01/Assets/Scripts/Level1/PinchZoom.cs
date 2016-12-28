using UnityEngine;

//Used to zoom
public class PinchZoom : MonoBehaviour {

    //Power of the zoom
	public float perspectiveZoom = 0.8f;

	// Update is called once per frame
	void Update () {
	    //If there are two fingers on screen, zoom
	    if (Input.touchCount == 2)
	        Zoom();
	}

    void Zoom()
    {
	    // Store touches
	    Touch _touchZero = Input.GetTouch (0);
	    Touch _touchOne = Input.GetTouch (1);

        //Get direction of pinch
	    Vector2 _touchZeroPrevPos = _touchZero.position - _touchZero.deltaPosition;
	    Vector2 _touchOnePrevPos = _touchOne.position - _touchOne.deltaPosition;

        //Get amount of pinch
	    float _prevTouchDeltaMag = (_touchZeroPrevPos - _touchOnePrevPos).magnitude;
	    float _touchDeltaMag = (_touchZero.position - _touchOne.position).magnitude;

        //Apply it by changing the FOV
	    float _deltaMagnitudeDiff = _prevTouchDeltaMag - _touchDeltaMag;

	    GetComponent<Camera>().fieldOfView += _deltaMagnitudeDiff * perspectiveZoom;
	    GetComponent<Camera>().fieldOfView = Mathf.Clamp (GetComponent<Camera>().fieldOfView, 10f, 60f);
    }
}
