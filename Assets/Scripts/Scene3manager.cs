using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene3manager : MonoBehaviour
{
    public Button Play;
    public GameObject Box, Tube, Sphere, TeaPot;
    public Material PausedMaterial, PlayMaterial;
    // Start is called before the first frame update
    public void Awake()
    {
        Play.onClick.AddListener(PlayPause);
       
    }

    public void OnEnable()
    {
        Tube.GetComponent<MeshRenderer>().material = PausedMaterial;
        Play.transform.GetChild(0).GetComponent<Text>().text = "Play";
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale =1f;
    }

    public void PlayPause()
    {
        if (Play.transform.GetChild(0).GetComponent<Text>().text == "Play")
        {
            Play.transform.GetChild(0).GetComponent<Text>().text = "Pause";
            Time.timeScale = 1f;
            Tube.GetComponent<MeshRenderer>().material = PlayMaterial;
            Box.SetActive(true);
            Sphere.SetActive(true);
        }
        else 
        {
            Play.transform.GetChild(0).GetComponent<Text>().text = "Play";
            Box.SetActive(false);
            Sphere.SetActive(false);
            Tube.GetComponent<MeshRenderer>().material = PausedMaterial;
            Time.timeScale = 0f;
        }
    }
}

