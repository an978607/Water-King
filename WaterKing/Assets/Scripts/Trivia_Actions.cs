using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trivia_Actions : MonoBehaviour
{
    private TriviaManager triviaManager;
    [SerializeField] Text results;

    void OnAwake()
    {
        triviaManager = gameObject.GetComponent<TriviaManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
