using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class trackRace : MonoBehaviour
{
    public GameObject UI;
    public UnityEngine.UI.Button seeResults, playagain, start;
    public GameObject mars, venus, neptune;
    public TMP_Text laps, countdown;
    AudioSource audioSource;
    string whoWon = "";
    public string[] rounds = {"0/3", "1/3", "2/3", "3/3"} ;
    int points;
    int currentLap =  0; 
    //declaring speeds
    float marsSpeed = 1.2f;
    float venusSpeed = 1.2f;
    float neptuneSpeed = 1.2f;


    //start countdown
  float timeRemaining = 4f;

    bool startRace = false;
    bool timerIsRunning = true;
    bool gameplay = true;   

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 15.21f;
        audioSource.Play();
        start.gameObject.SetActive(false);
        playagain.gameObject.SetActive(false);
        seeResults.gameObject.SetActive(false);
        laps.text = "";
       


        seeResults.onClick.AddListener(() => {
         UI.GetComponent<sceneSelection>().goToEnd();
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning == true)
        {

            if (timeRemaining > 1)
            {
                timeRemaining -= Time.deltaTime;
                int i = (int)timeRemaining;

                countdown.text = i.ToString();

            }
            else
            {
                Debug.Log("start race!");
                timeRemaining = 1;
                countdown.text = "";
                timerIsRunning = false;
                startRacing();

                // laps.text = "0/3";

            }
        }


        if (startRace == true)
        {
                //race started

                //move mars

                marsSpeed = Random.Range(-0.4f, 0.8f);
                venusSpeed = Random.Range(-0.4f, 0.8f);
                neptuneSpeed = Random.Range(-0.4f, 0.8f);

                //Get oject's position
                float marsX = mars.gameObject.transform.position.x + marsSpeed;

                Debug.Log(marsX);
                //Position comes in a Vector3
                Vector3 marsPosition = new Vector3(marsX, 100.0f, 717.3f);

                mars.transform.position = marsPosition; //assigning mars position


                if (marsX > 600.0)
                {
                PlayerPrefs.SetString("whoWon", "Mars won");
                PlayerPrefs.Save();
                Debug.Log("mars won");

                seeResults.gameObject.SetActive(true);
                startRace = false; 
          
                }

                //move venus
                float venusX = venus.gameObject.transform.position.x + venusSpeed;
                Vector3 venusPosition = new Vector3(venusX, -88.2f, 717.3f);
                venus.transform.position = venusPosition; //assigning cube position

                if (venusX > 600.0)
                {
                PlayerPrefs.SetString("whoWon", "Venus won");
                PlayerPrefs.Save();
                Debug.Log("venus won");
              
                seeResults.gameObject.SetActive(true);
                startRace = false;

              

                }

                //move neptune
                float neptuneX = venus.gameObject.transform.position.x + neptuneSpeed;
                Vector3 neptunePosition = new Vector3(neptuneX, -296.7f, 717.3f);
                neptune.transform.position = neptunePosition; //assigning third object position
                if (neptuneX > 600.0)
                {
                PlayerPrefs.SetString("whoWon", "Neptune won");
                PlayerPrefs.Save();
                Debug.Log("neptune won");
               
                seeResults.gameObject.SetActive(true);
                startRace = false;
                 }
            
           
        }
        
    }

    void startRacing()
    {
        Debug.Log("startRacing called");
        startRace = true;
    }

   /** void resetRace()
    {
        Debug.Log("RESET scalled");

        Vector3 marsPosition = new Vector3(-1122.6f, 100.0f, 717.3f);
        mars.transform.position = marsPosition; //assigning sphere position

        Vector3 venusPosition = new Vector3(-1122.6f, -88.2f, 717.3f);
        venus.transform.position = venusPosition; //assigning cube position

        Vector3 neptunePosition = new Vector3(-1122.6f, -296.7f, 717.3f);
        neptune.transform.position = neptunePosition; //assigning third object position

    

        // winning.text = "Start Race!!";
    }
   */

   /* public void assignWinner()
    {
        string winner;
       winner = whoWon;
        Debug.Log(winner);
    }
   */

  
}
