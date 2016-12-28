using UnityEngine;

//Used to manage level triggers and pick the random color to be chased by thu player
public class Arch : MonoBehaviour
{
    [SerializeField] private GameObject _nextLvl;
    [SerializeField] private Material _archMaterial;
    [SerializeField] private Material _materialToChange;

    private GetCamColors _camColor;
    private Color _etalon;

    // Use this for initialization
    void Start()
    {
        //Disable the exit
        _nextLvl.SetActive(false);
        //Get random color (not black cause the first frames of GetCamTexture are black)
        _etalon = new Color(Random.Range(0.01f, 1f),Random.Range(0.01f, 1f),Random.Range(0.01f, 1f));
        //Apply the color to all elements
        _archMaterial.color = _etalon;
        //Initialize GetCamColors
        _camColor = new GetCamColors();
    }

    // Update is called once per frame
    void Update()
    {
        //Get average color
        Color _colorToCheck = _camColor.MainColor;
        //Apply it
        _materialToChange.color = _colorToCheck;
        //Check color correspondence
        bool _isCorresponding = Mathf.Abs(_etalon.r - _colorToCheck.r) + Mathf.Abs(_etalon.g - _colorToCheck.g) + Mathf.Abs(_etalon.b - _colorToCheck.b) < 0.1f * 3;
        _nextLvl.SetActive(_isCorresponding);
    }
}