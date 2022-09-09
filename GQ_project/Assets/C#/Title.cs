using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject ui;

    [SerializeField]
    private AudioClip se;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Tutorial()
    {
        ui.SetActive(true);
    }

    public void StartGame()
    {
        AudioSource.PlayClipAtPoint(se, transform.position);
        Invoke("NextScene", 0.9f);
    }

    void NextScene()
    {
        FadeManager.FadeOut("Playground");
    }
}