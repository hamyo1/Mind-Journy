using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class teacherZoneScript : MonoBehaviour
{
    //screens game object
    public GameObject teacherZone;
    public GameObject addQuestion;

    public GameObject ans3Input;
    public GameObject ans4Input;

    //table of students
    public GameObject studentsContent;
    public GameObject studentRow;
    
    public TMP_Text studentName;
    public TMP_Text studentPoints;

    //table of questions
    public GameObject QuestionContent;
    public GameObject QuestionRow;
    
    public TMP_Text Question;
    public TMP_Text Ans1;
    public TMP_Text Ans2;
    public TMP_Text Ans3;
    public TMP_Text Ans4;
    public GameObject loading;
    public langHendler langhendler;

    List <GameObject> questionArray = new List<GameObject>();
    public void onDropdownChange(Dropdown change) //active or unactive answers input fields (3 and 4)
        {
            if (change.value == 0) // value = 2
            {
                ans3Input.SetActive(false);
                ans4Input.SetActive(false);

            }
            else if (change.value == 1) // value = 3
            {
                ans3Input.SetActive(true);
                ans4Input.SetActive(false);
            }
            else if (change.value == 2) // value = 4
            {
                ans3Input.SetActive(true);
                ans4Input.SetActive(true);
            }
        }

    public void action (string mes,int type) {
        Debug.Log ("action - " + mes);
        langhendler = FindObjectOfType<langHendler>();

        if (type == 0) // get students
        {
            RectTransform rt = (RectTransform)studentsContent.transform;
            
            float height = rt.rect.height;
            rt.sizeDelta = new Vector2(0, height = 75f); //restart content size

            String[] rows = mes.Split('|');
            //Transform rowTransform =  studentsContent.transform;
            float addY = 0;
            //Debug.Log(studentRow.transform.position.x);
        
            for (int i = 0; i<rows.Length-1;i++)
            {
                rt.sizeDelta = new Vector2(0, height += 75f);
                String name = rows[i].Split(',')[0]; // name
                String points = rows[i].Split(',')[1]; // points
                
                studentName.text = name;
                studentPoints.text = points;

                Instantiate(studentRow,new Vector3(studentRow.transform.position.x,studentRow.transform.position.y + addY,0),Quaternion.identity,studentsContent.transform);
                addY-=75;   
            }

            studentRow.SetActive(false);
        }
        else if (type == 1) // get questions
        {
            foreach(GameObject ques in questionArray) //clear question in 'show question' panel
            {
                Destroy(ques);
            }
            QuestionRow.SetActive(true);
            RectTransform rt = (RectTransform)QuestionContent.transform;
            
            float height = rt.rect.height;
            
            rt.sizeDelta = new Vector2(0, height = 150f); //restart content size
            
            String[] rows = mes.Split('|');
            
            float addY = 0;
            
            //Debug.Log(studentRow.transform.position.x);
        
            for (int i = 0; i<rows.Length-1;i++)
            {
                
                rt.sizeDelta = new Vector2(0, height += 150f);
                String getQuestion = rows[i].Split(',')[0]; // question
                String setAns1 = rows[i].Split(',')[1]; // answers
                String setAns2 = rows[i].Split(',')[2]; // answers
                String setAns3 = rows[i].Split(',')[3]; // answers
                String setAns4 = rows[i].Split(',')[4]; // answers
                langhendler.langStatus = Int32.Parse(rows[i].Split(',')[5]);
                if (langhendler.langStatus == 0)
                {
                    Question.text = langhendler.convertEnglish(getQuestion);
                    Ans1.text = langhendler.convertEnglish(setAns1);
                    Ans2.text = langhendler.convertEnglish(setAns2);
                    Ans3.text = langhendler.convertEnglish(setAns3);
                    Ans4.text = langhendler.convertEnglish(setAns4);
                    
                }
                if (langhendler.langStatus == 1)
                {
                    Question.text = getQuestion;
                    Ans1.text = setAns1;
                    Ans2.text = setAns2;
                    Ans3.text = setAns3;
                    Ans4.text = setAns4;
                }

                GameObject newQuestionRow=  Instantiate(QuestionRow,new Vector3(QuestionRow.transform.position.x,QuestionRow.transform.position.y + addY,0),Quaternion.identity,QuestionContent.transform);
                addY-=150;
                
                questionArray.Add(newQuestionRow);
                
            }

            QuestionRow.SetActive(false);
        }
        else if (type == 2) // set question
        {
            if (mes.Contains("sucsess"))
            {
                Debug.Log("sucsess");
                teacherZone.SetActive(true);
                addQuestion.SetActive(false);
            }
        }

    }
    

    //function to connect the server (active on player click button)
    public void getStudents () {
        loading.SetActive(true);
        Invoke("SENDgetStudents", 1);
        
    }
    public void SENDgetStudents(){
        //the get query
        string result = connect.Connect ("localhost", "{\"action\":\"getStudents\",\"teacherID\":\"" + globalVarible.Instance.TeacherId+ "\"}\n");
        loading.SetActive(false);
        //take action in the game with the result
        action(result,0);
    }

    public void getQuestions () {
        loading.SetActive(true);
        Invoke("SENDgetQuestions", 1);
    }
    public void SENDgetQuestions(){
        //the get query
        string result = connect.Connect ("localhost", "{\"action\":\"getTeachQuestions\",\"teacherID\":\"" + globalVarible.Instance.TeacherId.ToString() + "\"}\n");
        loading.SetActive(false);
        //take action in the game with the result
        action(result,1);
    }

    public void insertQuestion () {
        loading.SetActive(true);
        Invoke("SENDinsertQuestion", 1);
    }


    public void SENDinsertQuestion()
    {
        langhendler = FindObjectOfType<langHendler>();

        //the get query
        if (langhendler.langStatus == 0)
        {
            langhendler.beforSendAction();
            Debug.Log("hebrew");
        }
        if (langhendler.langStatus == 1)
        {
            Debug.Log("english");
        }
        string result = connect.Connect ("localhost", "{\"action\":\"insertQuestion\",\"question\":\"" + langhendler.question.text + "\",\"ans1\":\"" + langhendler.ans1.text + "\",\"ans2\":\"" + langhendler.ans2.text + "\",\"ans3\":\"" + langhendler.ans3.text + "\",\"ans4\":\"" + langhendler.ans4.text + "\",\"teacherID\":\"" + globalVarible.Instance.TeacherId.ToString() + "\",\"langStatus\":\"" + langhendler.langStatus + "\"}\n");
        loading.SetActive(false);
        //take action in the game with the result
        action(result,2);
    }
    
}
