using UnityEngine;

public class change_color : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    public Material[] material;
    Renderer rend;
    public string tagName="";
    public bool a=true;

    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<Renderer>();
        rend.enabled=true;
        rend.sharedMaterial=material[1];
        if(gameObject.tag=="1"||gameObject.tag=="4"||gameObject.tag=="5")
        {
            a=false;
            rend.sharedMaterial=material[0];
        }
        else
        {
            rend.sharedMaterial=material[1];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void change()
    {
        if(a)
        {
            rend.sharedMaterial=material[0]; 
        }
        else
        {
            rend.sharedMaterial=material[1]; 
        }
        a=!a;
    }
    void OnCollisionEnter(Collision col)
    {
        
        if(gameObject.tag=="2")tagName=gameObject.tag;
        if(col.gameObject.tag=="Player")
        {
            Debug.Log("The tag for this GameObject is" + gameObject.tag);
            canvas.gameObject.SetActive(true);
            canvas2.gameObject.SetActive(true); 
        }
        
    }

    void OnCollisionExit(Collision col)
    {
        canvas.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(false);
        tagName="";
        /*if(a)
        {
            rend.sharedMaterial=material[1];
        }
        else
        {
            rend.sharedMaterial=material[0];
        } */   
    }



}
