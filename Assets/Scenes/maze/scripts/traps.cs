using UnityEngine;
using UnityEngine.SceneManagement;


public class traps : MonoBehaviour
{
    public static void startEgain()
    {
        Debug.Log("start egain");
        if(globalVarible.Instance.points>10&&globalVarible.Instance.points<150)
        {
            globalVarible.Instance.points =10;
        }
        if(globalVarible.Instance.points>=150)
        {
            globalVarible.Instance.points =150;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
		
    }

    public void trapButton()
    {
        startEgain();
    }
    
}
