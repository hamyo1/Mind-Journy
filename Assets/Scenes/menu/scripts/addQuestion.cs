using UnityEngine;
using TMPro;

public class addQuestion : MonoBehaviour
{
    //public int gateNum;
    //public GameObject gate;
    public string[] QuestionArray; //get question from "getQuestion", by gate number
    public GameObject panelQuestion;
    public langHendler langhendler;

    public GameObject A3;
    public GameObject A4;

    public TMP_Text question;
    public TMP_Text ans1;
    public TMP_Text ans2;
    public TMP_Text ans3 ;
    public TMP_Text ans4;
    public TMP_Text feedback;
    

    
    
    void OnCollisionEnter(Collision collision) //call when men toch the gate. active and put the question on board
     {
         Debug.Log("touch on gate " + gameObject.tag);
         
        panelQuestion.SetActive(true);
        pauseGame.pause();
        globalVarible.Instance.correctGate = gameObject;
        switch (gameObject.tag) //find how gate we are
        {
            case "1":
                QuestionArray = getQuestion.question1;
                break;
            case "2":
                QuestionArray = getQuestion.question2;
                break;
            case "3":
                QuestionArray = getQuestion.question3;
                break;
        }
        System.Random random = new System.Random();
        int random_ans;
        
        if(QuestionArray[3] =="") //hide ans 3 if is empty
        {
            random_ans = random.Next(1,3);
            A3.SetActive(false);
            A4.SetActive(false);
        }
        else if(QuestionArray[4] =="") //hide ans 4 if is empty
        {
            random_ans = random.Next(1,4);
            A4.SetActive(false);
        }
        else{
            random_ans = random.Next(1,5); //choose which question is correct randomaly
        }
         Debug.Log("random_ans" +random_ans);
         globalVarible.Instance.correctAns = random_ans;
        langhendler = FindObjectOfType<langHendler>();

        //Debug.Log(QuestionArray[0] + " - " + QuestionArray[1] + " - " + QuestionArray[2] + " - " + QuestionArray[3] + " - " + QuestionArray[4] + " - ");
        question.text = QuestionArray[0];
        string temp = QuestionArray[random_ans];
        QuestionArray[random_ans] = QuestionArray[1];
        QuestionArray[1] = temp;


        ans1.text =  QuestionArray[1];
        ans2.text =  QuestionArray[2];
        ans3.text =  QuestionArray[3];
        ans4.text =  QuestionArray[4];
       if(QuestionArray[5] == "0")
        {
            question.text = langhendler.convertEnglish(question.text);
            ans1.text = langhendler.convertEnglish(ans1.text);
            ans2.text = langhendler.convertEnglish(ans2.text);
            ans3.text = langhendler.convertEnglish(ans3.text);
            ans4.text = langhendler.convertEnglish(ans4.text);
        }
     }

    public void colectAns(int answer) //get and check answer from player
     {
         //gameObject.SetActive(false);

         if(answer == globalVarible.Instance.correctAns ) //correct answer
         {
            feedback.text = "correct!! open gate";
            Debug.Log("correct!! open gate");
            globalVarible.Instance.points +=10;
            panelQuestion.SetActive(false);
            pauseGame.resume();
            globalVarible.Instance.correctGate.SetActive(false);
            feedback.text = "";   
            A3.SetActive(true);
            A4.SetActive(true);    
         }
         else{ //wrong answer
            feedback.text = "wrong!! start over";
            Debug.Log("wrong!! start over");
            globalVarible.Instance.points =10; 
            traps.startEgain(); //move to start game egain  
         }
     }
}
