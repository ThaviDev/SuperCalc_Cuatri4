using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRaycastShooter : MonoBehaviour
{
    float shootCooldown;
    [SerializeField] Camera cam;
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

        // https://www.youtube.com/watch?v=aaYfoe9i5lY How to Raycast Using Mouse
        // Dibuja el rayo en la escena para referencia
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);

    }
    //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html

    void FixedUpdate()
    {
        // Input del mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Input.GetMouseButtonDown(0) && shootCooldown <= 0)
        {
            if (Physics.Raycast(ray, out hit, 50))
            {
                print("There is something in front of the object! " + hit.transform.gameObject.name);

                /*
                var myButton = hit.transform.gameObject.GetComponent<My3DButton>();
                if (myButton != null) {
                    print(myButton.bChar);
                } */
                // https://stackoverflow.com/questions/76684994/how-to-get-a-component-from-a-raycast-hit-in-unity
                if (hit.transform.gameObject.TryGetComponent(out My3DButton btn))
                {
                    btn.MyButtonPressed();
                    //print(btn.bChar);
                }
            }
            shootCooldown = 0.2f;
        }
    }
}
