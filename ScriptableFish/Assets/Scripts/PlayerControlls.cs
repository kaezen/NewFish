using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public float speed = 5;
    public float sensitivity = 100;
    float cameraY = 0;
    float cameraX = 0;

    public float cameraClamp = 45;
    public bool invert = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        // do camera rotation

        if (invert)
        {
            cameraY += sensitivity * Time.deltaTime * Input.GetAxis("Mouse Y");
        }
        else
        {
            cameraY += sensitivity * Time.deltaTime * Input.GetAxis("Mouse Y");
        }
        cameraX += sensitivity * Time.deltaTime * Input.GetAxis("Mouse X");

        if (cameraY > cameraClamp) cameraY = cameraClamp;
        if (cameraY < -cameraClamp) cameraY = -cameraClamp;



        transform.eulerAngles = new Vector3(cameraY, cameraX, 0);
    }
}
