using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class registerScript : MonoBehaviour {
    public TMP_InputField UserName;
    public TMP_InputField Password1;
    public TMP_InputField Password2;
    public TMP_InputField email;
    public TMP_InputField teacherCode;
    public GameObject teacheCodeOb;
    public static String reciveedString="";
    public GameObject Register;
    public GameObject overToScreen;
    public GameObject DuplicateUser;
    public GameObject passwordNotEqual;
    public GameObject teacherZone;
    public Text errorInput;
    public TMP_Text teacherInfoName;
    public TMP_Text teacherInfoID;
    public TMP_Text studentInfoName;

    public GameObject loading;
    public String name;
    public String password1;
    public String password2;
    public String mail;
    public String teachCode;

    public void action (String mes) { //get info from server and use it
        Debug.Log("action - " + mes);
       
        if (globalVarible.Instance.teacher) //is teacher
        {
            Debug.Log(mes.Split(',')[0]);
            globalVarible.Instance.TeacherId = mes.Split(',')[0];

            teacherZone.SetActive(true);
            Register.SetActive(false);
            changeTeacherInfo();

        }
        else{ //is student
            if(mes.Split(',')[0].Contains("sucsess"))
            {
                Debug.Log("student register sucsess");
                overToScreen.SetActive(true);
                Register.SetActive(false);
                studentInfoName.text = globalVarible.Instance.name; 
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
    public void toogle(bool toggle)
    {
        if (toggle)
        {
            globalVarible.Instance.teacher = true;
            teacheCodeOb.SetActive(false);
        }
        else
        {
            globalVarible.Instance.teacher = false;
            teacheCodeOb.SetActive(true);
        }
    }
    //function to regeister new user
    public void registerFunc () {
        //input validatiion
        errorInput.text  = "";
        //Debug.Log($" is  year{(2 == 1 ? "true" : "s")} old.");

        name = UserName.text;
        password1 = Password1.text;
        password2 = Password2.text;
        mail = email.text;
        teachCode = teacherCode.text;
        
        globalVarible.Instance.name = name;

        if (password1 != password2)
        {
            //must be equal
            passwordNotEqual.SetActive(true);
            return;
        }
        if (name == "") //check name
        {
            //canot be empty
            errorInput.text  = "ךרע ליכהל בייח רזוי הדש";
            return;
        }
        
        else if (password1.Length<8)//password not strong
        {
            //password must be 8 character or less
            errorInput.text  = "םיוות 8 תוחפל ליכהל הכירצ המסיסה";
            return;
        }
        
        loading.SetActive(true);
        Invoke("sendToServer", 1);

        
    }
    public void sendToServer(){
        String actionType;
        if(globalVarible.Instance.teacher) // is teacher
        {
            actionType = "registerTeach";
        }
        else{
            actionType = "registerStu";
        }

        Debug.Log("validation ok");
        //send the query to the server by the func connect and store the result in the var reciveedString
                
        string teachOrStu = globalVarible.Instance.teacher ? "": ",\"teacherID\":\"" + teachCode + "\""; //if is teacher after the mail stay empty. if its student -teacher code enter there
        
        reciveedString = connect.Connect ("localhost", "{\"action\":\""+actionType+"\",\"name\":\"" + name + "\",\"pass\":\"" + password1 + "\",\"email\":\"" + mail  + "\""+teachOrStu+"}\n");
        loading.SetActive(false);
        //take action with the result
        action(reciveedString);
    }
}
