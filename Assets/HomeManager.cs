using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeManager : MonoBehaviour
{
    public AudioClip suaraTombol;
    AudioSource aS;
    public GameObject mute, unmute, musik, tutor1UI, tutor2UI, next;
    public int tutor, videoStory, videoOpening;
    public Button storyButton;
    // Start is called before the first frame update
    void Start()
    {
        videoOpening = PlayerPrefs.GetInt("videoOpening");

        if(videoOpening == 0)
        {
            storyButton.interactable = false;
        }

        if (videoOpening == 1)
        {
            storyButton.interactable = true;
        }

        aS = gameObject.GetComponent<AudioSource>();
        videoStory = PlayerPrefs.GetInt("videoStory");
    }

    // Update is called once per frame
    void Update()
    {
        if (tutor == 1)
        {
            next.SetActive(true);
            tutor1UI.SetActive(true);
        }
        if (tutor == 2)
        {
            tutor2UI.SetActive(true);
            tutor1UI.SetActive(false);
        }
        if(tutor == 0)
        {
            tutor1UI.SetActive(false);
            tutor2UI.SetActive(false);
            next.SetActive(false);
        }
    }

    public void StartGame()
    {
        aS.PlayOneShot(suaraTombol);
        aS.PlayOneShot(suaraTombol);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        aS.PlayOneShot(suaraTombol);
        Application.Quit();
    }
    public void Story()
    {
        videoStory = 1;
        PlayerPrefs.SetInt("videoStory", 1);
        SceneManager.LoadScene("MainMenu");
    }
    public void Mute()
    {
        aS.PlayOneShot(suaraTombol);
        mute.SetActive(false);
        unmute.SetActive(true);
        musik.SetActive(false);
    }
    public void Unmute()
    {
        aS.PlayOneShot(suaraTombol);
        mute.SetActive(true);
        unmute.SetActive(false);
        musik.SetActive(true);
    }

    public void Tutor()
    {
        tutor++;

        if(tutor == 3)
        {
            tutor = 0;
        }
    }
}
