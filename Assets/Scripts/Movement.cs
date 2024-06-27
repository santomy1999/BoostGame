using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float thrustFactor = 100f;
    [SerializeField] float rotationFactor = 100f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.W))
        {
            body.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateObject(rotationFactor);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateObject(-rotationFactor);
        }
    }
    private void RotateObject(float factor)
    {
        body.freezeRotation = true;
        transform.Rotate(Vector3.forward * factor * Time.deltaTime);
        body.freezeRotation = false;
    }
}
