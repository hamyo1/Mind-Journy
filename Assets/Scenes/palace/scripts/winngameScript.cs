using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winngameScript : MonoBehaviour
{
    public GameObject winnPanel;
     void OnCollisionEnter(Collision collision)
    {
        globalVarible.Instance.points +=1000;
        winnPanel.SetActive(true);
    }

    public void quite(){
        SceneManager.LoadScene(0);
        String result = connect.Connect("localhost", "{\"action\":\"uppoint\",\"name\":\"" + globalVarible.Instance.name.ToString() + "\",\"points\":\"" + globalVarible.Instance.points.ToString() + "\"}\n");
    }
}
