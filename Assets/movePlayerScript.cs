using UnityEngine;

public class movePlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private float movementSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0,0, movementSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");
        if(Input.GetKey("up"))
        {
            rb.AddForce(0,0, movementSpeed * Time.deltaTime);
            //transform.position = transform.position + new Vector3(horizontalInput,0, (verticalInput * movementSpeed) * Time.deltaTime);
        }
        else if(Input.GetKey("down"))
        {
            //transform.position = transform.position + new Vector3(horizontalInput,0, (verticalInput - movementSpeed) * Time.deltaTime);
        }
        else if(Input.GetKey("left"))
        {
            //transform.position = transform.position + new Vector3((horizontalInput - movementSpeed) * Time.deltaTime,0, verticalInput );
        }
        else if(Input.GetKey("right"))
        {
            //transform.position = transform.position + new Vector3((horizontalInput * movementSpeed) * Time.deltaTime,0, verticalInput);
        }
    }
}
