using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    [SerializeField] private string SceneToPlay;
    [SerializeField] private bool PressAnything;

    void Update()
    {

        if (PressAnything && Input.anyKeyDown)
        {
            ChangeScene();
        }

    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(SceneToPlay))
        {
            SceneManager.LoadScene(SceneToPlay);
        }
        else
        {
            Debug.LogError("SceneToPlay is not set.");
        }
    }

}
