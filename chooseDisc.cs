using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEngine.SceneManagement;

public class chooseDisc : MonoBehaviour

{
    public GameObject[] discs = new GameObject[3];
   
    public string[] songTitles = new string[3];

    Color32 color; //color 32 has 4 paramaters RGBA and takes 255... just 'Color"  uses values from 0 to 1, not 0 to 255 and has 3 arguments. I could also do (233f/255f, ...,....)

    public GameObject plane; 

    public TMP_Text songText;

    public GameObject discImage;
    public Camera cam;
    public AudioClip[] sounds;

    public static int audioTrack = 0;

    public UnityEngine.UI.Button prev, next, start, play, seeResults, playagain;   

    bool startGallery = false;

    int currentImage = 0;

    public static string chosenDisc;

    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        //hide start game message
        start.gameObject.SetActive(false);
        playagain.gameObject.SetActive(false);
        seeResults.gameObject.SetActive(false);


        discImage = discs[currentImage];
        discs[0].SetActive(true);
        discs[1].SetActive(false);
        discs[2].SetActive(false);

        songText.text = songTitles[currentImage];

        this.transform.GetComponent<AudioSource>().clip = sounds[currentImage];


        prev.onClick.AddListener(() =>
        {

            currentImage = currentImage - 1;
            //Before changing the image, make sure it exists!!
            if (currentImage == 0)
            {
                discs[0].SetActive(true);
                discs[1].SetActive(false);
                discs[2].SetActive(false);
               
              


            }
            if (currentImage == 1)
            {
                discs[0].SetActive(false);
                discs[1].SetActive(true);
                discs[2].SetActive(false);
             

            }
            if (currentImage == -1)
            {
                currentImage = 2;
                discs[0].SetActive(false);
                discs[1].SetActive(false);
                discs[2].SetActive(true);
               
            }

            discImage = discs[currentImage];
            songText.text = songTitles[currentImage];

        });

        next.onClick.AddListener(() =>
        {
            currentImage = currentImage + 1;
            //sets image back the first, after clicking past the last image

            if (currentImage == 1)
            {
                discs[0].SetActive(false);
                discs[1].SetActive(true);
                discs[2].SetActive(false);
            }
            if (currentImage == 2)
            {
                discs[0].SetActive(false);
                discs[1].SetActive(false);
                discs[2].SetActive(true);

            }

            if (currentImage == discs.Length)
            {
                currentImage = 0;
                discs[0].SetActive(true);
                discs[1].SetActive(false);
                discs[2].SetActive(false);
            }
            discImage = discs[currentImage];
            songText.text = songTitles[currentImage];

        });

        play.onClick.AddListener(() => {
            //change song for each seperate CD
            start.gameObject.SetActive(true);

            if (currentImage == 0)
            {
                audioTrack = currentImage;

                this.transform.GetComponent<AudioSource>().clip = sounds[audioTrack];
                this.transform.GetComponent<AudioSource>().Play();
                
            }
            if (currentImage == 1)
            {
                audioTrack = currentImage;     

                this.transform.GetComponent<AudioSource>().clip = sounds[audioTrack];
                this.transform.GetComponent<AudioSource>().Play();
            }
            if (currentImage == 2)
            {
                audioTrack = currentImage;

                this.transform.GetComponent<AudioSource>().clip = sounds[audioTrack];
                this.transform.GetComponent<AudioSource>().Play();
            }
            if (currentImage == sounds.Length)
            {
                audioTrack = 0;
            }
        });

        start.onClick.AddListener(() => {
           // chosenDisc = discImage;

          //  Debug.Log(discImage);

            UI.GetComponent<sceneSelection>().goToMiddle();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //change panel for each seperate CD
        if (currentImage == 0)
        {

            color = new Color32(255,126, 0, 255);
            cam.backgroundColor = color;
            Debug.Log("Mars");
            PlayerPrefs.SetString("chosenDisc", "Mars won");
            PlayerPrefs.Save();

        }

        if (currentImage == 1)
        {
            color = new Color32(255, 215, 248, 255);
            cam.backgroundColor = color;
            Debug.Log("Venus");
            PlayerPrefs.SetString("chosenDisc", "Venus won");
            PlayerPrefs.Save();
        }

        if (currentImage == -1 || currentImage == 2)
        {
            color = new Color32(123, 205, 248, 255);
            cam.backgroundColor = color;
            Debug.Log("Neptune");
            PlayerPrefs.SetString("chosenDisc", "Neptune won");
            PlayerPrefs.Save();
        }


    }

   
}
