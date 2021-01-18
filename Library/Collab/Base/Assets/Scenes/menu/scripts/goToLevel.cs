using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class goToLevel : MonoBehaviour
{
    public Text name;
    void Start() {
        name = gameObject.GetComponent<Text>(); 
        name.text="hello " + globalVarible.Instance.name;
        
    }
    public void start_game()
    {
        SceneManager.LoadScene(1);
    }

    public void continue_game()
    {
        Debug.Log("continue");
    }
}
