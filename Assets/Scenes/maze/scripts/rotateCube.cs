using UnityEngine;

public class rotateCube : MonoBehaviour
{
    public float speed = 150f;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
