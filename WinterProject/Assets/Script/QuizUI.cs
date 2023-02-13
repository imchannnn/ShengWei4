using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private List<Button> options;
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private ProcessController processController;
    [SerializeField] private Color normalCol,wrongCol,correctCol;
    [SerializeField] private Text questionText;

    private Question question;
    private bool answered;
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }
    public void SetQuesiton(Question question)
    {
        this.question = question;
        
        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }
        answered = false;
    }

    private void OnClick(Button btn)
    {
        if (processController.GameStatus == GameStatus.ANSWER)
        {
            if (!answered)
            {
                answered = true;
                bool val = quizManager.Answer(btn.name);
                if (val)
                {
                    btn.image.color = correctCol;
                }
                else
                {
                    btn.image.color=wrongCol;
                }
            }
        }
    }
}
