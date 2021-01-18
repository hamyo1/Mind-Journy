using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject settingsButton;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("esc");
                //  openSettings();
            }


    }
    public void openSettings(){
        settingsPanel.SetActive(true);
        settingsButton.SetActive(false);
    }

    public void quite(){
        SceneManager.LoadScene(0);
        QuitGame();
    }

    public static void QuitGame()
    {
        //send query to the server to update points in the db
        String result = connect.Connect("localhost", "{\"action\":\"uppoint\",\"name\":\"" + globalVarible.Instance.name.ToString() + "\",\"points\":\"" + globalVarible.Instance.points.ToString() + "\"}\n");
        Debug.Log(result);//show feedback that the points are update
        Debug.Log("Quit");//quit from the game
        //Application.Quit();
        
    }
}
