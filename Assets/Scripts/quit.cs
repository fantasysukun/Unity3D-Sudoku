using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class quit : MonoBehaviour
{
    public Canvas start;
    public Button exit;

    public void keluar()
    {
        Application.Quit();
    }

}
