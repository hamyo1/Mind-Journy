using UnityEngine;
using UnityEngine.SceneManagement;


public class goToLevel : MonoBehaviour
{
    //private Text name;
    public int points;
    public bool isTeacher;
    public GameObject strartGame;
    public GameObject continuegame;

    public GameObject teacherScreen;


    void Start() {
        
        //name.text=globalVarible.Instance.name.ToString();
        points=globalVarible.Instance.points;
        isTeacher = globalVarible.Instance.teacher;
        
        if(points==0)
        {
            strartGame.SetActive(true);
        }
        else
        {
            continuegame.SetActive(true);
        }

        if (isTeacher == true)
        {
            Debug.Log("is teacher");
            teacherScreen.SetActive(true);
        }
    }
    public void start_game()
    {
        SceneManager.LoadScene(1);
    }

    public void continue_game()
    {
        if(points<10)SceneManager.LoadScene(1);
        if(points>=10&&points<250)
        {
            SceneManager.LoadScene(2);
        }
        if(points>=250)
        {
            SceneManager.LoadScene(4);
        }
        Debug.Log("continue");
    }
    public void logout()
    {
        globalVarible.Instance.name = "";
        globalVarible.Instance.points = 0;
    }
}
