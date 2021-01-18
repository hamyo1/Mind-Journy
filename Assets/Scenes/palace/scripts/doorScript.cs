using UnityEngine;

public class doorScript : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            animator.SetBool("open",true);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}