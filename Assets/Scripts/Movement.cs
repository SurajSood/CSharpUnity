using System.Collections;
using System.Collections.Generic;
using UnityEngine; //namespace, MonoBehaviour content is in here

public class Movement : MonoBehaviour 
//inheriting, Movement deriving from MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb; //rb used in tutorials
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) //returns as true
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            //Debug.Log("Pressed SPACE - Thrusting");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            //Debug.Log("Rotating Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            //Debug.Log("Rotating Right");
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }
}
