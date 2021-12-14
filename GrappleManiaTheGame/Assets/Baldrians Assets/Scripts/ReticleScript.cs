using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameObject extraReticle;
    //public Canvas canvasObject;

    //transform.SetParent(canvasObject.transform);

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f))
        {
            if (hit.transform.gameObject.CompareTag("GrappleSurface"))
            {

                //Instantiate(extraReticle.transform.SetParent (parentCanvas.transform);
            }
        }
        //else
        //{
        //    Destroy(extraReticle);
        //}
    }
}
