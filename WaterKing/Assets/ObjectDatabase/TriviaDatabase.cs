using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaDatabase : MonoBehaviour
{
    private static GameObject triviaDatabaseObject;
    public TriviaListClass triviaListClass;

    private void Awake()
    {
        triviaDatabaseObject = GameObject.FindGameObjectWithTag("TriviaDatabase");
        BuildDatabase();
    }

    public static GameObject GetTriviaDatabaseObject() => triviaDatabaseObject;

    private void BuildDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetTrivias() + "}";
        triviaListClass.list = Deserialization.DeserializeTrivia(json);
    }

    [System.Serializable]
    public class TriviaListClass
    {
        private static TriviaListClass triviaListClassInstance = null;
        public List<Trivia> list;
        public static TriviaListClass GetInstance() => triviaListClassInstance = (triviaListClassInstance != null) ? triviaListClassInstance : new TriviaListClass();

        private TriviaListClass()
        {
            list = new List<Trivia>();
        }
    }
}
