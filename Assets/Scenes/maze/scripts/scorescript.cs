using UnityEngine;
using UnityEngine.UI;

public class scorescript : MonoBehaviour
{
    public GameObject player;
    public static int scorevalu;
    public static string nexLevel = "";
    
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        scorevalu=globalVarible.Instance.points;
                           
        if(globalVarible.Instance.flag==1)
        {
            globalVarible.Instance.points+=100;
        }
        if(globalVarible.Instance.points >= 150&&globalVarible.Instance.points<250)
        {
            player.transform.position = new Vector3(23.75f,-0.437f,3.01f);
        }
        if(globalVarible.Instance.flag==2&&globalVarible.Instance.points>250)
        {
            Debug.Log(globalVarible.Instance.points);
        }
        Debug.Log(globalVarible.Instance.points);
    }

    // Update is called once per frame
    void Update()
    {

        score.text = "Score: " + globalVarible.Instance.points.ToString();
    }
}
