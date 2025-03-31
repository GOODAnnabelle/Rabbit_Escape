using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{

    public string targetSceneName = "TargetSceneName";

    public void ChangeScene()
    {

        SceneManager.LoadScene(targetSceneName);

    }

}