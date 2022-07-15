using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2Manager : MonoBehaviour
{
    public Text QuestionText;
    public string[] Questions;
    private string CorrectAnswer;
    [SerializeField]
    public Answers[] Answers;

    public Text[] AnswerTextBoxes;

    private int QuestionCount=4;

    public Toggle[] AllToggles;
    public GameObject CorrectPanel, IncorrecctPanel;

    public void OnEnable()
    {
        foreach (Toggle T in AllToggles)
        {
            T.interactable = true;
            T.onValueChanged.AddListener(delegate { ToogleAndCheck(T.gameObject.name); });
        }
        QuestionCount = Questions.Length;
        int RandomQuestionindex = Random.Range(0, QuestionCount);
        QuestionText.text = Questions[RandomQuestionindex];
        AnswerTextBoxes[0].text = Answers[RandomQuestionindex].Answer1;
        AnswerTextBoxes[1].text = Answers[RandomQuestionindex].Answer2;
        AnswerTextBoxes[2].text = Answers[RandomQuestionindex].Answer3;
        AnswerTextBoxes[3].text = Answers[RandomQuestionindex].Answer4;
        CorrectAnswer= Answers[RandomQuestionindex].CorrectAnswer;
        CorrectPanel.SetActive(false);
        IncorrecctPanel.SetActive(false);
      

    }

    public void ToogleAndCheck(string name)
    { 
        for(int i=0;i< QuestionCount; i++)
        {
            if (AllToggles[i].name == name && AnswerTextBoxes[i].text == CorrectAnswer)
            {
                CorrectPanel.SetActive(true);
            }
            else if (AllToggles[i].name != name && AnswerTextBoxes[i].text == CorrectAnswer)
            {
                IncorrecctPanel.SetActive(true);
            }
        }
        foreach (Toggle T in AllToggles)
        {
            T.interactable = false;
            T.isOn = false;
        }
    }

   
}
[System.Serializable]
public class Answers
{
    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;
    public string CorrectAnswer;
}
