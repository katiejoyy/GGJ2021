using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("HiThere");
            if(Physics.Raycast(transform.position, transform.forward,out RaycastHit hitinfo, 5))
            {
                Debug.Log("You Hit");
                InteractableObject ObjectHit = hitinfo.transform.gameObject.GetComponent<InteractableObject>();
                if(ObjectHit != null)
                {
                    ObjectHit.Interact();
                }
            }
        }
        
    }

    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward*5, Color.green);
    }
}
