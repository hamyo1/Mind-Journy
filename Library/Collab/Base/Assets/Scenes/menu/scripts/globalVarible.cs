using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVarible : MonoBehaviour
{
    public static globalVarible Instance {get; private set;}
    public int points;
    public string name;
    private void Awake() {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
        {
            //Destroy(gameObject);
        }
    }

}
