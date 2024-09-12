using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRaycastShooter : MonoBehaviour
{
    float shootCooldown;
    void Start()
    {
        
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        //print(shootCooldown);
    }
    //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Input.GetMouseButtonDown(0) && shootCooldown <= 0)
        {
            if (Physics.Raycast(transform.position, fwd, out hit, 50))
            {
                print("There is something in front of the object! " + hit.transform.gameObject);

                var myButton = hit.transform.gameObject.GetComponent<My3DButton>();
                if (myButton != null) {
                    print(myButton.bChar);
                }
            }
            shootCooldown = 1;
        }
    }
}
