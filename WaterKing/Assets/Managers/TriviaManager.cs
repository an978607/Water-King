using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour
{
    private GameObject triviaDatabaseObject;
    private GameObject fuelGameObject;
    private Fuel fuel;
    private PlayerDataManager playerDataManager;
    private TriviaDatabase triviaDatabase;
    private GameObject triviaUIContent;
    private GameObject triviaQuestionObject;
    private GameObject triviaAnswer1Object;
    private GameObject triviaAnswer2Object;
    private GameObject triviaAnswer3Object;
    private GameObject triviaAnswer4Object;
    [SerializeField] private GameObject triviaResult;
    private Trivia trivia;

    private void Awake()
    {
        playerDataManager = gameObject.GetComponent<PlayerDataManager>();
        fuelGameObject = GameObject.FindGameObjectWithTag("Fuel");
        if (fuelGameObject == null)
        {
            Debug.LogError("TriviaManager: Unable to find Fuel object");
            return;
        }

        fuel = fuelGameObject.GetComponent<Fuel>();

        triviaDatabaseObject = GameObject.FindGameObjectWithTag("TriviaDatabase");

        if (triviaDatabaseObject == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaDatabase object");
            return;
        }

        triviaDatabase = triviaDatabaseObject.GetComponent<TriviaDatabase>();

        triviaUIContent = GameObject.FindGameObjectWithTag("TriviaUIContent");
        if (triviaUIContent == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaUIContent object");
            return;
        }

        triviaQuestionObject = GameObject.FindGameObjectWithTag("TriviaQuestion");
        if (triviaQuestionObject == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaQuestion object");
            return;
        }

        triviaAnswer1Object = GameObject.FindGameObjectWithTag("TriviaAnswer1");
        if (triviaAnswer1Object == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaAnswer1 object");
            return;
        }

        triviaAnswer2Object = GameObject.FindGameObjectWithTag("TriviaAnswer2");
        if (triviaAnswer2Object == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaAnswer2 object");
            return;
        }

        triviaAnswer3Object = GameObject.FindGameObjectWithTag("TriviaAnswer3");
        if (triviaAnswer3Object == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaAnswer3 object");
            return;
        }

        triviaAnswer4Object = GameObject.FindGameObjectWithTag("TriviaAnswer4");
        if (triviaAnswer4Object == null)
        {
            Debug.LogError("TriviaManager: Unable to find TriviaAnswer4 object");
            return;
        }

        UpdateUIWithTriviaQuestion();
    }
    
    public void CheckIfAnswerIsCorrect(int answerNum)
    {
        triviaResult.SetActive(true);
        if (trivia.GetCorrectAnswer() == trivia.AnswerList[answerNum - 1])
        {
            Debug.Log(trivia.GetCorrectAnswer());
            Debug.Log(trivia.AnswerList[answerNum - 1]);
            triviaResult.GetComponentInChildren<Text>().text = "Correct";
            fuel.AddEnergy(1);
        }
        else
        {
            triviaResult.GetComponentInChildren<Text>().text = "Wrong Answer";
        }
    }

    public void UpdateUIWithTriviaQuestion()
    {
        if (triviaDatabase.triviaListClass == null || triviaDatabase.triviaListClass.list == null)
        {
            Debug.LogError("TriviaManager: triviaListClass null when updating UI with trivia question");
            return;
        }

        List<Trivia> trivias = (triviaDatabase.triviaListClass.list);

        trivia = SelectTriviaQuestionFromList(trivias);

        triviaQuestionObject.GetComponent<Text>().text = trivia.question;

        trivia.AnswerList.Add(trivia.answer1);
        trivia.AnswerList.Add(trivia.answer2);
        trivia.AnswerList.Add(trivia.answer3);
        trivia.AnswerList.Add(trivia.answer4);

        if (trivia.AnswerList.Count < 4)
        {
            Debug.LogError("TriviaManager: Not enough answers in trivia answer list");
            return;
        }

        triviaAnswer1Object.GetComponentInChildren<Text>().text = trivia.AnswerList[0];
        triviaAnswer2Object.GetComponentInChildren<Text>().text = trivia.AnswerList[1];
        triviaAnswer3Object.GetComponentInChildren<Text>().text = trivia.AnswerList[2];
        triviaAnswer4Object.GetComponentInChildren<Text>().text = trivia.AnswerList[3];
    }

    private Trivia SelectTriviaQuestionFromList(List<Trivia> trivias)
    {
        int randomIndex = Random.Range(0, trivias.Count);
        return trivias[randomIndex];
    }
}
