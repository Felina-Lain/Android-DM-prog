using UnityEngine;
using UnityEngine.SceneManagement;

//When we hit the open door, go to next level
public class ChangeLevel : MonoBehaviour {
	
    void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
