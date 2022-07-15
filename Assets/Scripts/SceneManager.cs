using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject[] Scene;
    public Button NextButton, PreviousButton;
    private int SceneCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        PreviousButton.interactable = false;
        NextButton.interactable = true;
        PreviousButton.onClick.AddListener(delegate { EnableScene("Previous"); });
        NextButton.onClick.AddListener(delegate { EnableScene("Next"); });
    }

    public void EnableScene(string moment)
    {
        NextButton.interactable = true;
        PreviousButton.interactable = true;
        if (moment == "Next")
        {
            if (SceneCounter < Scene.Length-1)
            {
                SceneCounter++;
                DisableAndEnableScene(SceneCounter);
                if (SceneCounter == Scene.Length-1)
                {
                    NextButton.interactable = false;
                }
            }
        }
        else
        {
            if (SceneCounter > 0)
            {
                SceneCounter--;
                DisableAndEnableScene(SceneCounter);
                if (SceneCounter == 0)
                {
                    PreviousButton.interactable = false;
                }
            } 
        }

    }


    public void DisableAndEnableScene(int SceneCounter)
    {
        foreach (GameObject s in Scene)
        {
            s.gameObject.SetActive(false);
        }
        Scene[SceneCounter].gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
