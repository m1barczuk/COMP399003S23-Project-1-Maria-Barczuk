using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SphereMove : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseObject;
    private bool countdown;
    private float timer;
    public GameObject exitObject;
    void Start()
    {
        score = 0;
        countdown = false;
        timer = 0;
    }
    void Update()
    {
        float speed = 10f * Time.deltaTime;
        float horizMove = Input.GetAxisRaw("Horizontal") * speed;
        float vertMove = Input.GetAxisRaw("Vertical") * speed;
        transform.position += new Vector3(horizMove, 0, vertMove);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            countdown = true;
        }
        if(countdown)
        {
            if(timer < 3)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
                exitObject.SetActive(false);
            }
            else
            {
                exitObject.SetActive(true);
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        float newX = Random.Range(-12,12);
        float newZ = Random.Range(-5,5);
        other.transform.position = new Vector3(newX, 0, newZ);
        score++;
        scoreText.text = "Score: " + score;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Still in the Trigger.");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited the Trigger.");
    }
}
