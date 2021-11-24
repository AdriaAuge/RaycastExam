using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastController : MonoBehaviour
{
    public Text timerText;
    private int time;

    private float pauseTime;
    private float nextTime;

    private float range = 10f;

    private void Start()
    {
        pauseTime = 1f;
        nextTime = 0;
        
        time = 5;
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * range, Color.green); 
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, range))
            {
                var selection = hit.transform;

                if(selection.CompareTag("Cube1"))
                {
                    Timer1();
                }

                if(selection.CompareTag("Sphere"))
                {
                    Timer2();
                }

                if(selection.CompareTag("Cube2"))
                {
                    Timer3();
                }
            }
        }
    }
    
    //ESCENA 1
    private void Timer1()
    {
        nextTime = Time.time + pauseTime;
        time--;
        timerText.text = time.ToString();

        if (time != 5)
        {
            StartCoroutine("Timer_1");
        }

        if (time == 0)
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    private IEnumerator Timer_1()
    {
        yield return new WaitForSeconds(1);
        Timer1();
    }

    //ESCENA 2
    private void Timer2()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + pauseTime;
            time--;
            timerText.text = time.ToString();

            if (time != 5)
            {
                StartCoroutine("Timer_2");
            }

            if (time == 0)
            {
                SceneManager.LoadScene("Scene2");
            }
        }
    }

    private IEnumerator Timer_2()
    {
        yield return new WaitForSeconds(1);
        Timer2();
    }

    //ESCENA 3
    private void Timer3()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + pauseTime;
            time--;
            timerText.text = time.ToString();

            if (time != 5)
            {
                StartCoroutine("Timer_3");
            }

            if (time == 0)
            {
                SceneManager.LoadScene("Scene3");
            }
        }
    }

    private IEnumerator Timer_3()
    {
        yield return new WaitForSeconds(1);
        Timer3();
    }
}
