using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CheckChannel : MonoBehaviour
{
    //Displayed channel (R, G or B)
    [SerializeField] private Channels _myChannel;

    //Color to divide
    private Color _myColor;

	// Use this for initialization
	void Start () {
	    //Set random color (not black because the cam's always black at the beginning of the game)
	    _myColor = new Color(Random.Range(0.1f,1f),Random.Range(0.1f,1f),Random.Range(0.1f,1f));
	    GetComponent<MeshRenderer>().material.color = GameManager.camColors.DivideColors(_myColor,_myChannel);
	    //Count number of cubes to validate
	    GameManager.winCountNeeded++;
	}

    void OnTriggerEnter(Collider _collider)
    {
        //When cubes overlaps, check if colors are the same. If so count 1 point and destroy the cube
        if (CheckColor(_myColor, _collider.GetComponent<MeshRenderer>().material.color, _myChannel))
        {
            Destroy(_collider.gameObject);
            GameManager.AddPoint();
        }
    }

    //Check if two divided are the same
    bool CheckColor(Color _firstColor, Color _secondColor, Channels _channel)
    {
        switch (_channel)
        {
            case Channels.Red:
                if (_firstColor.r - _secondColor.r < 0.15f)
                    return true;
                break;
            case Channels.Green:
                if (_firstColor.g - _secondColor.g < 0.15f)
                    return true;
                break;
            case Channels.Blue:
                if (_firstColor.b - _secondColor.b < 0.15f)
                    return true;
                break;
            default:
                throw new ArgumentOutOfRangeException("_channel", _channel, null);
        }
        return false;
    }
}
