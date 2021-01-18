using UnityEngine;
using UnityEngine.SceneManagement;

public class goToFrog : MonoBehaviour
{
    public GameObject mes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(globalVarible.Instance.points>=50)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            mes.gameObject.SetActive(true);
        }
        
    }
    public void realisedButton()
    {
        mes.gameObject.SetActive(false);
    }
}
