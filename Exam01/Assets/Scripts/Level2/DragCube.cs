using UnityEngine;

public class DragCube : MonoBehaviour
{

    //Channel to display (Red, Green or Blue)
    [SerializeField] private Channels _channel;

    //Script getting and divinding colors
    private GetCamColors _camColors;
    private Vector3 _originPos;
    private Material _myMaterial;

    void Start()
    {
        _originPos = transform.position;
        _camColors = GameManager.camColors;
        _myMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        //Get the middle color from Webcam and get the channel corresponding to it field
        _myMaterial.color = _camColors.DivideColors(_camColors.MainColor, _channel);
    }

    void OnMouseDrag()
    {
        //When we drag, follow the y position of the finger on the screen
        Vector3 _fingerPosInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        transform.position = new Vector3(_originPos.x,_fingerPosInWorld.y,0);
    }

    void OnMouseUp()
    {
        //When release drag, get back to original position
        transform.position = _originPos;
    }
}
