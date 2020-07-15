using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 0.25f;
    public float accelleration = 5f;
    public float turnSpeed = 30f;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        speed += verticalInput * Time.deltaTime * accelleration;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * turnSpeed);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.P))
            Time.timeScale = Time.timeScale > 0f ? 0f : 1f;
    }
}
