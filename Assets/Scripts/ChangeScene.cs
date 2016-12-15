using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    // function click for the button
    public void changeToScene(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }
    public void RestartchangeToScene(int changeTheScene)
    {
        level.easy = false;
        level.med = false;
        level.hard = false;
        SceneManager.LoadScene(changeTheScene);
    }

}
