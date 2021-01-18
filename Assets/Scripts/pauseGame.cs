using UnityEngine;

public class pauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static void pause()
    {
        Time.timeScale = 0f;
    }

    public static void resume()
    {
        Time.timeScale = 1f;
    }
}
