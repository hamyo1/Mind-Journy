using UnityEngine;
using System;

public class globalVarible : MonoBehaviour
{
    public static globalVarible Instance {get; private set;}
    public int points;
    public string name;

    public String TeacherId;
    public int flag;
    public bool teacher = false;


    public int gateToOpen;
    public GameObject correctGate;
    public int correctAns;
   
    private void Awake() {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        //String result = connect.Connect("localhost", "{\"action\":\"uppoint\",\"name\":\"" + globalVarible.Instance.name.ToString() + "\",\"points\":\"" + globalVarible.Instance.points.ToString() + "\"}\n");
    }

}
