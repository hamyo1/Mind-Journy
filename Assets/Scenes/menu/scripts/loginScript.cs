using System;
using TMPro;
using UnityEngine;

public class loginScript : MonoBehaviour {

    public TMP_InputField UserName;
    public TMP_InputField Password;
    public GameObject teacherZone;

    public GameObject Login;
    public GameObject overToGame;
    public GameObject MesEror;
    public TMP_Text teacherInfoName;
    public TMP_Text teacherInfoID;
    public TMP_Text studentInfoName;

    public GameObject loading;
    
    public void action (string mes) {
        Debug.Log ("action - " + mes);
        if(globalVarible.Instance.teacher)
        {
            Debug.Log("teacher");
           if( mes.Split (',') [1]=="1")
            {
                Debug.Log("teachr connect");
                globalVarible.Instance.TeacherId = mes.Split(',')[0]; //set teacher ID to global varible
                globalVarible.Instance.name = UserName.text; // set name to global varible
                teacherZone.SetActive(true);
                Login.SetActive(false);
                changeTeacherInfo();
            }
            else
            {
                Debug.Log("disconnect");
                MesEror.SetActive(true);
            }
        }
        else
        {
            Debug.Log("student");
            String connect = mes.Split (',') [0];
            
            if ( connect=="1") {
                Debug.Log ("connect");

                String TeacherID =  mes.Split (',') [1]; //get teacher ID from db
                globalVarible.Instance.TeacherId = TeacherID; //set teacher ID to global varible
                
                globalVarible.Instance.name = UserName.text;
                studentInfoName.text = globalVarible.Instance.name; //set student name to global varible
                
                int points = Int32.Parse(mes.Split (',') [2]); //get student points from db
                globalVarible.Instance.points = points; //set student points to global varible
            
                Login.SetActive (false);
                overToGame.SetActive (true);
            } else {
                Debug.Log ("disconnect");
                MesEror.SetActive (true);
            }
        }
        
    }
    public void changeTeacherInfo()
    {
        Debug.Log("changeTeacherInfo");
        Debug.Log(globalVarible.Instance.name);
        Debug.Log(globalVarible.Instance.TeacherId);

        teacherInfoName.text = globalVarible.Instance.name;
        teacherInfoID.text = globalVarible.Instance.TeacherId;

    }

    public void toggleChange(bool toggle)

    {
        
        Debug.Log(toggle);
        globalVarible.Instance.teacher = toggle;

    }
    
    //function to connect user (check validation)
    public void submitInput () {
        
        loading.SetActive(true);
        Invoke("sendToServer", 1);
        
        
    }

    public void sendToServer()
    {
        //the get query
        //connectTea,connectStu
        String actionType;
        if (globalVarible.Instance.teacher) // is teacher
        {
            actionType = "connectTea";
        }
        else
        {
            actionType = "connectStu";
        }
        
        string result = connect.Connect ("localhost", "{\"action\":\""+actionType+"\",\"name\":\"" + UserName.text + "\",\"pass\":\"" + Password.text + "\"}\n");
        loading.SetActive(false);
        //take action in the game with the result
        action(result);
    }

}