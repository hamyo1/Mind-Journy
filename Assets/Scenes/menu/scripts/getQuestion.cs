using UnityEngine;

public class getQuestion : MonoBehaviour
{

    public GameObject loading;
    public static string[] question1;
    public static string[] question2;
    public static string[] question3;

    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(true);
        Invoke("sendToServer", 1);       
    }
    public void action(string mes)
    {
        string[] questions = mes.Split('|'); //split 3 questions
        Debug.Log(questions[0]);

        question1 = questions[0].Split(',');
        question2 = questions[1].Split(',');
        question3 = questions[2].Split(',');
    }


    //function to connect user (check validation)
    public void sendToServer () {
        //the get query
        string result = connect.Connect ("localhost", "{\"action\":\"getStudentQuestions\",\"teacherID\":\"" + globalVarible.Instance.TeacherId.ToString() + "\"}\n");
        loading.SetActive(false);
        //take action in the game with the result
        action(result);
    }
}
