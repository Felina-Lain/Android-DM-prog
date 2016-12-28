using UnityEngine;

//I really need to explain that ?
public class RotateAuto : MonoBehaviour {

	[SerializeField] private float _speedx;
	[SerializeField] private float _speedy;
	[SerializeField] private float _speedz;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Time.deltaTime * _speedx, Time.deltaTime * _speedy, Time.deltaTime * _speedz);
	}
}
