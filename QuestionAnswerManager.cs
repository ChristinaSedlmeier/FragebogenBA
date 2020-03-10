using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;


public class QuestionAnswerManager : MonoBehaviour
{
    public GameObject[] questionGroupArr;
    public QAClass07[] qaArray;
    public GameObject AnswerPanel;
    private GameController gameController;
    private int Counter = 0;
    private DataController dataController;

    // Start is called before the first frame update
    void Start()
    {
        qaArray = new QAClass07[questionGroupArr.Length];
        gameController = FindObjectOfType<GameController>();
        dataController = FindObjectOfType<DataController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitAnswer()
    {
  
       if(Counter < questionGroupArr.Length - 1) { 
            qaArray[Counter] = ReadQuestionAndAnswer(questionGroupArr[Counter]);
            Counter++;
            gameController.AnswerButtonClicked();
       }
       else
        {
            qaArray[Counter] = ReadQuestionAndAnswer(questionGroupArr[Counter]);
            dataController.saveData(qaArray);
            gameController.AnswerButtonClicked();
            Counter = 1;

        }
         
    }

    QAClass07 ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass07 result = new QAClass07();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = q.GetComponent<Text>().text;

        if (a.GetComponent<ToggleGroup>() != null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    break;
                }
            }
        }



       
        return result;
    }


}

[System.Serializable]
public class QAClass07
{
    public string Question;
    public string Answer;
}
