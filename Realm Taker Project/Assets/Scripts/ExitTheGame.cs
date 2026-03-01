using UnityEngine;

public class ExitTheGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Application.Quit();
            Debug.Log("Game is quitting...");
            KeluarGame();
        }
    }

    public void KeluarGame()
    {
#if UNITY_EDITOR
        // Ini akan menghentikan mode Play di Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Ini yang akan jalan saat game sudah jadi (.exe/.apk)
        Application.Quit();
#endif
    }

}
