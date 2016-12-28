using System;
using UnityEngine;

public enum Channels {Red,Green,Blue}

public class GetCamColors
{

    private WebCamTexture _webcamTexture;
    private Color32[] _colorsCam;

    //MainColor is the average of every pixel color channel
    public Color MainColor
    {
        get
        {
            _webcamTexture.GetPixels32(_colorsCam);
            Vector3 _colorTemp = Vector3.zero;
            for (int i = 0; i < _colorsCam.Length; i++)
            {
                _colorTemp.x += _colorsCam[i].r / 255f;
                _colorTemp.y += _colorsCam[i].g / 255f;
                _colorTemp.z += _colorsCam[i].b / 255f;
            }
            _colorTemp /= _colorsCam.Length;
            return new Color(_colorTemp.x, _colorTemp.y, _colorTemp.z, 1);
        }
    }

    //Contructor to make sure everything's set up
    public GetCamColors()
    {
        _webcamTexture = new WebCamTexture();
        //In order to avoid problems during scene load
        if(!_webcamTexture.isPlaying)
            _webcamTexture.Play();
        _colorsCam = new Color32[_webcamTexture.width * _webcamTexture.height];
    }

    //Return a one channel color based on a color
    public Color DivideColors(Color _color, Channels _channel)
    {
        switch (_channel)
        {
            case Channels.Red:
                return new Color(_color.r,0,0);
            case Channels.Green:
                return new Color(0,_color.g,0);
            case Channels.Blue:
                return new Color(0,0,_color.b);
            default:
                throw new ArgumentOutOfRangeException("_channel", _channel, null);
        }
    }
}