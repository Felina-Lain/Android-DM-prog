using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _victoryText;

    //Used to get a reference to GetCamColors class since we cannot launch multiple instance of it (cause we can have multiple webcamtexture from the same camera)
    //Also used to count points
    public static int winCountNeeded;
    public static int winCount;
    public static GetCamColors camColors;


    // Use OnEnable to have it done before all the Start in Drag and CheckChannel
    void OnEnable()
    {
        camColors = new GetCamColors();
    }

    public static void AddPoint()
    {
        winCount++;
        if (winCount == winCountNeeded)
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
    }

    public void Win()
    {
       _victoryText.SetActive(true);
    }
}
