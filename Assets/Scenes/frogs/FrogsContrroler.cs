using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogsContrroler : MonoBehaviour
{
    public int size = 7;
    public int[] status;
    //public int entertTag;
    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < size; i++)
        {
            if (i < size / 2) status[i] = i+1;
            if (i == size / 2) status[i] = 0;
            if (i > size / 2) status[i] = i;
        }
        //status now is {1,2,3,0,4,5,6}
    }

    public void checRecurseive() {

    }


    public void gameAction(int entertTag)
    {
        float movement= 4.0f;
        int i,tagIndex=0;
        for (i = 0; i < size; i++) if (status[i] == entertTag) tagIndex = i;
        Debug.Log(tagIndex);
        if (entertTag<=size/2)
        {
            if (status[tagIndex+1] == 0)
            {
                status[tagIndex + 1] = entertTag;
                status[tagIndex] = 0;
                movement = 4.0f;
            }
            if (tagIndex + 2 < size && status[tagIndex + 2] == 0  )
            {
                status[tagIndex + 2] = entertTag;
                status[tagIndex] = 0;
                movement = 8.0f;
            }
        }
        if (entertTag > size / 2)
        {
            if (status[tagIndex-1] == 0)
            {
                status[tagIndex -1] = entertTag;
                status[tagIndex] = 0;
                movement = -4.0f;
            }
            if (tagIndex - 2 >= 0 && status[tagIndex - 2] == 0  )
            {
                status[tagIndex - 2] = entertTag;
                status[tagIndex] = 0;
                movement = -8.0f;
            }
        }
        string tags=entertTag.ToString();
        Vector3 temp = new Vector3(movement, 0, 0);
        GameObject.FindGameObjectWithTag(tags).transform.position += temp;
        int num=0;
        for (i = size / 2; i < size; i++) if (status[i] == num) num++;
        if (num == size / 2 + 1)
        {
            GameObject.FindGameObjectWithTag("Finish").transform.GetChild(2).gameObject.SetActive(true);
            globalVarible.Instance.flag = 1;
            SceneManager.LoadScene(2);
            Debug.Log(globalVarible.Instance.points);
        }
    }

}
