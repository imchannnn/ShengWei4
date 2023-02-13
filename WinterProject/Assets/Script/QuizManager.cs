using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizDataScriptable quizData;
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private ProcessController processController;


    private List<Question> questions;
    private Question selectedQuestion;


    public void StartSetting()
    {
        questions = new List<Question>();
        for (int i = 0; i < quizData.questions.Count; i++)
        {
            questions.Add(quizData.questions[i]);
        }
        SelectQuestion();
    }

    void SelectQuestion()
    {
        int val = UnityEngine.Random.Range(0, questions.Count);
        selectedQuestion = questions[val];
        quizUI.SetQuesiton(selectedQuestion);
        questions.RemoveAt(val);
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;
        processController.GameStatus = GameStatus.BATTLE;
        if (answered == selectedQuestion.correctAns)
        {
            correctAns = true;
            processController.Battle(true);
        }
        else
        {
            correctAns = false;
            processController.Battle(false);
        }

        if (questions.Count > 0)
        {
            Invoke("SelectQuestion", 0.4f);
        }
        else
        {
            for (int i = 0; i < quizData.questions.Count; i++)
            {
                questions.Add(quizData.questions[i]);
            }
            Invoke("SelectQuestion", 0.4f);
        }
        return correctAns;
    }

    public void TimeIsOver()
    {
        if (questions.Count > 0)
        {
            Invoke("SelectQuestion", 0.4f);
        }
        else
        {
            for (int i = 0; i < quizData.questions.Count; i++)
            {
                questions.Add(quizData.questions[i]);
            }
            Invoke("SelectQuestion", 0.4f);
        }
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public List<string> options;
    public string correctAns;
}
