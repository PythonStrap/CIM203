using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Drawing;
    

public class positionWinner : MonoBehaviour
{
    public GameObject mars, venus, neptune;  

    public TMP_Text whoWon, face;

    public UnityEngine.UI.Button start, seeResults;

    public Camera cam;

    Color32 color;

    public AudioClip[] sounds;

    public static int audioTrack = 0;

    ArrayList place = new ArrayList () { };



    // Start is called before the first frame update
    void Start()
    {
        start.gameObject.SetActive(false);
        seeResults.gameObject.SetActive(false);
        string character = PlayerPrefs.GetString("chosenDisc");
        string winner = PlayerPrefs.GetString("whoWon");

        place.Add("Mars won");
        place.Add("Venus won");
        place.Add("Neptune won");

     
        for (int i = 0; i < place.Count; i++)
        {
            Debug.Log(winner);

          

            if (character != winner)
            {
                face.text = ":(";
                face.color = new Color32(255, 0, 0, 255);
            }

            if(character == winner)
            { 
                face.text = ":)";
                face.color = new Color32(0, 138, 64, 255);
            }

            if (winner == place[0].ToString()) 
            {
                audioTrack = 0;
                this.transform.GetComponent<AudioSource>().clip = sounds[audioTrack];
                this.transform.GetComponent<AudioSource>().Play();

                color = new Color32(255, 126, 0, 255);
                cam.backgroundColor = color;

                //original position of mars
                float marsY = mars.gameObject.transform.position.y;
                Vector3 marsPosition = new Vector3(-1.55f, marsY, -4.42f);
                mars.transform.position = marsPosition;

                //original position of venus
                float venusY = venus.gameObject.transform.position.y;
                Vector3 venusPosition = new Vector3(0.54f, venusY, -4.42f);
                venus.transform.position = venusPosition;

                //original position of neptune
                float neptuneY = neptune.gameObject.transform.position.y;
                Vector3 neptunePosition = new Vector3(-3.65f, neptuneY, -4.42f);
                neptune.transform.position = neptunePosition;
               

                whoWon.text = "Mars won";

                break;
            }
           
            if (winner == place[1].ToString())
            {
               
                audioTrack = 1;
                this.transform.GetComponent<AudioSource>().clip = sounds[audioTrack];
                this.transform.GetComponent<AudioSource>().Play();

                color = new Color32(255, 215, 248, 255);
                cam.backgroundColor = color;

                //original position of mars
                float marsY = mars.gameObject.transform.position.y;
                Vector3 marsPosition = new Vector3(0.54f, marsY, -4.42f);
                mars.transform.position = marsPosition;

                //original position of venus
                float venusY = venus.gameObject.transform.position.y;
                Vector3 venusPosition = new Vector3(-1.55f, venusY, -4.42f);
                venus.transform.position = venusPosition;

                //original position of neptune
                float neptuneY = neptune.gameObject.transform.position.y;
                Vector3 neptunePosition = new Vector3(-3.65f, neptuneY, -4.42f);
                neptune.transform.position = neptunePosition;
               

                whoWon.text = "Venus won";

                break;
            }
           

            if (winner == place[2].ToString())
            {
                audioTrack = 2;
                this.transform.GetComponent<AudioSource>().clip = sounds[audioTrack];
                this.transform.GetComponent<AudioSource>().Play();

                color = new Color32(123, 205, 248, 255);
                cam.backgroundColor = color;

                //original position of mars
                float marsY = mars.gameObject.transform.position.y;
                Vector3 marsPosition = new Vector3(-3.65f, marsY, -4.42f);
                mars.transform.position = marsPosition;

                //original position of venus
                float venusY = venus.gameObject.transform.position.y;
                Vector3 venusPosition = new Vector3(0.54f, venusY, -4.42f);
                venus.transform.position = venusPosition;

                //original position of neptune
                float neptuneY = neptune.gameObject.transform.position.y;
                Vector3 neptunePosition = new Vector3(-1.55f, neptuneY, -4.42f);
                neptune.transform.position = neptunePosition;
              
                whoWon.text = "Neptune won";
                break;

            }
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
