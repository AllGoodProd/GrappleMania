using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{

    Rigidbody rb;
    CapsuleCollider collider;

    float originalHeight;
    public float reducedHeight;

    public float slideSpeed = 10f;

    bool isSliding;



    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        originalHeight = collider.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
            Sliding();

        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }

    private void Sliding()
    {
        collider.height = reducedHeight;
        rb.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        collider.height = originalHeight;
    }


}

