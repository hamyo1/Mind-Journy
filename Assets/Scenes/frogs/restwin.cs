using UnityEngine;
using TMPro;
public class restwin : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField numOfCubs;
    public GameObject secretdoor;
    public Animator animator;
    public int count=0;
    public bool flag=false;
    //change_color mychange=GameObject.transform.GetChild (0).GetComponent<change_color>();
    //GameObject  ChildGameObject1 = restwin.transform.GetChild (0).gameObject;
    // Start is called before the first frame update
    void Start()
    {
        animator=secretdoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void closeButton()
    {
        canvas.gameObject.SetActive(false);
    }

    public void resetBinButton()
    {
        foreach(Transform child in this.transform) 
        {
            GameObject obj = child.gameObject;
            if(numOfCubs.text[0]=='6')flag=true;
            // Do things with obj
            //Debug.Log("The tag for this GameObject is" + obj.GetComponent<change_color>().a);

            if(!obj.GetComponent<change_color>().a)
            {
                count++;
                if(count==6&&flag)
                {
                    Debug.Log("you win");
                    canvas.gameObject.SetActive(true);
                    animator.SetBool("open",true);
                }
            }

        }
        if(count!=6||!flag)Application.LoadLevel(Application.loadedLevel);
        flag=false;
        count=0;
    }

}
