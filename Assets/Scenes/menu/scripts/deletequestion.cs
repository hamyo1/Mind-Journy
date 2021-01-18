using UnityEngine;
using TMPro;

public class deletequestion : MonoBehaviour
{
    public TMP_Text Question;
    
    public GameObject questionToDelete;
    public GameObject loading;
    public langHendler langhendler;

    public void action (string mes){
        Destroy(questionToDelete);
    }
    public void deleteQuestion () {
        loading.SetActive(true);
        Invoke("sendToServer", 1);
    }
    public void sendToServer()
    {
        //the get query
        langhendler = FindObjectOfType<langHendler>();

        if (langhendler.langStatus == 0) Question.text= langhendler.convertHeb(Question.text);
        string result = connect.Connect ("localhost", "{\"action\":\"deleteQuestion\",\"question\":\"" + Question.text + "\",\"teacherID\":\"" + globalVarible.Instance.TeacherId.ToString()+ "\"}\n");
        loading.SetActive(false);
        action(result);
    }
}
