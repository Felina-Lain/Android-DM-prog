using UnityEngine;
using System.Collections;

//Make the camera advance when double tap
public class DoubleTapAdvance : MonoBehaviour
{
    //Time to double tap
    [SerializeField] private float _cooldown = 0.5f;
    //Speed of advance
    [SerializeField] private float _speed;
    //Distance to advance
    [SerializeField] private float _distance;

    //Count taps
    private int _count;
    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        //If one tap
        if (Input.GetMouseButtonDown(0))
        {
            //If there's already been a tap within the timer, launch the move
            if (_cooldown > 0 && _count == 1 /*Number of Taps you want Minus One*/)
            {
                Vector3 _start_pos = transform.position;
				Vector3 _start_forward = transform.forward * 10;
				StartCoroutine(AvanceSmooth(_start_pos, _start_forward));

                //Has double tapped
            }
            //Else launch timer
            else
            {
                _cooldown = 0.5f;
                _count += 1;
            }
        }
        //If timer launched, count time
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }
        else
        {
            _count = 0;
        }
    }

    //Advance while you didn't go forward to _distance meters away
	IEnumerator AvanceSmooth(Vector3 _start, Vector3 _startForw)
    {
		Vector3 _targetPosition = _startForw;
        _targetPosition.y = 0;
		while (Mathf.Abs(_start.z - transform.position.z) < _distance)// || Mathf.Abs(_start.y - transform.position.y) < _distance || Mathf.Abs(_start.x - transform.position.x) < _distance)
        {
            transform.position = Vector3.SmoothDamp(transform.position, transform.position + _targetPosition, ref _velocity, 1 / _speed);
            yield return null;
        }
    }
}