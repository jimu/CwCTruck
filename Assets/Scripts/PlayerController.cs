using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 0.25f;
    public float acceleration = 5f;
    public float handbreakDecelleration = 12f;
    public float turnSpeed = 30f;

    GameObject fpsCounterPanel = null;

    private void Awake()
    {
        fpsCounterPanel = GameObject.FindGameObjectWithTag("FPS");
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        speed += verticalInput * Time.deltaTime * acceleration;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * turnSpeed);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.P))
            Time.timeScale = Time.timeScale > 0f ? 0f : 1f;
        if (Input.GetKeyDown(KeyCode.F))
            fpsCounterPanel.SetActive(!fpsCounterPanel.activeSelf);

        // slow forward or backward velocity
        if (Input.GetKey(KeyCode.Space))
        {
            float deceleration = Mathf.Min(handbreakDecelleration * Time.deltaTime, Mathf.Abs(speed));
            speed += speed < 0f ? deceleration : -deceleration;
        }


    }
}
