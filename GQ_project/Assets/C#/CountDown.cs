using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timeText;
    public Text countdownText;

    float totalTime;
    float retime = 60f;
    float countDown = 4f;
    float StageTime = 60f;
    int count;
    int pre = 4;
    int i = 0;

    private GameObject[] tagObjects;

    [SerializeField]
    private AudioClip se;

    [SerializeField]
    private AudioClip crear;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        tagObjects = GameObject.FindGameObjectsWithTag("Grass");

        if (tagObjects.Length == 0)
        {
            countdownText.text = "Crear!!";
            if (i == 0)
            {
                AudioSource.PlayClipAtPoint(crear, transform.position);
                i++;
            }
            Invoke("LoadTitle", 3.5f);

        }
        else
        {

            if (retime <= 0)
            {
                //I‚í‚è
                countdownText.text = "Failed!!";
                Invoke("LoadTitle", 1.5f);
            }
            else
            {
                if (countDown >= 0)
                {
                    countDown -= Time.deltaTime;
                    count = (int)countDown;
                    if (pre != count)
                    {
                        countdownText.text = "   " + count.ToString();
                        AudioSource.PlayClipAtPoint(se, transform.position);
                        pre = count;
                    }
                }

                if (countDown <= 1)
                {
                    countdownText.text = "Start!!";
                    totalTime -= Time.deltaTime;
                    retime = StageTime + totalTime;
                    timeText.text = "Time:" + retime.ToString("f1");
                }

                if (countDown <= 0)
                {
                    countdownText.text = "";
                }
            }
        }
    }
    void LoadTitle()
    {
        FadeManager.FadeOut("Title");
    }
}
