﻿using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DataEditor : EditorWindow
{
    private Vector2 scrollPos;

    private bool isShowNewVehicle = false;
    private bool isShowNewObstacle = false;
    private bool isShowNewItem = false;
    private bool isShowNewTrivia = false;
    private bool isShowNewEvent = false;

    // Vehicle group fields
    private string vehicleNameText = "";
    private string vehicleDescriptionText = "";
    private int vehiclePrice = 0;
    private Sprite vehicleSprite;
    private bool isVehicleUnlocked = false;
    private float vehicleSpeed = 0.0f;

    // Obstacle group fields
    private string obstacleNameText = "";
    private int obstacleHitPoints = 0;
    private bool isItemUnlocked = false;

    // Item group fields
    private string itemNameText = "";
    private string itemDescriptionText = "";
    private int itemPrice = 0;

    // Trivia group fields
    private string triviaQuestionText = "";
    private int numberOfTriviaAnswers = 0;
    private int triviaCorrectAnswer = 0;
    private int triviaReward = 0;
    private List<string> triviaAnswerList = new List<string>();

    // Event group fields
    private string eventNameText = "";
    private string eventDescriptionText = "";
    private int eventPrice = 0;
    private bool isEventUnlocked = false;

    [MenuItem("Window / Data Editor")]

    public static void ShowWindow()
    {
        GetWindow(typeof(DataEditor));
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        // Vehicle Group
        isShowNewVehicle = EditorGUILayout.BeginFoldoutHeaderGroup(isShowNewVehicle, "New Vehicle");
        EditorGUI.indentLevel++;
        if (isShowNewVehicle)
        {
            vehicleNameText = EditorGUILayout.TextField("Name:", vehicleNameText);
            vehicleDescriptionText = EditorGUILayout.TextField("Description:", itemDescriptionText);
            vehiclePrice = EditorGUILayout.IntField("Price:", vehiclePrice);
            vehicleSprite = (Sprite)EditorGUILayout.ObjectField("Sprite:", vehicleSprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
            isVehicleUnlocked = EditorGUILayout.Toggle("Unlocked:", isVehicleUnlocked);
            vehicleSpeed = EditorGUILayout.Slider("Speed", vehicleSpeed, 0, 100);

            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);

            if (GUILayout.Button("Add", GUILayout.Width(100), GUILayout.Height(30)))
            {
                VehicleDatabase.Vehicles vehicles = VehicleDatabase.Vehicles.GetInstance();
                vehicles.list.Add(new Vehicle(vehicles.list.Count, isVehicleUnlocked, vehicleSpeed, vehicleNameText, vehicleDescriptionText, vehiclePrice));
                Serialization.Serialize(vehicles);
                vehicleNameText = "";
                vehicleDescriptionText = "";
                vehiclePrice = 0;
                vehicleSprite = null;
                isVehicleUnlocked = false;
                vehicleSpeed = 0;
                Debug.Log("Serialized Obstacle");
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(7);
        }

        Rect rect1 = EditorGUILayout.BeginHorizontal();
        Handles.color = Color.black;
        Handles.DrawLine(new Vector2(rect1.x - 15, rect1.y), new Vector2(rect1.width + 15, rect1.y));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();

        // Obstacle Group
        isShowNewObstacle = EditorGUILayout.BeginFoldoutHeaderGroup(isShowNewObstacle, "New Obstacle");

        if (isShowNewObstacle)
        {
            obstacleNameText = EditorGUILayout.TextField("Name:", obstacleNameText);
            obstacleHitPoints = EditorGUILayout.IntSlider("Hit Points", obstacleHitPoints, 0, 100);

            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);

            if (GUILayout.Button("Add", GUILayout.Width(100), GUILayout.Height(30)))
            {
                ObstacleDatabase.Obstacles obstacles = ObstacleDatabase.Obstacles.GetInstance();
                obstacles.list.Add(new Obstacle(obstacles.list.Count, obstacleNameText, obstacleHitPoints));
                Serialization.Serialize(obstacles);
                obstacleNameText = "";
                obstacleHitPoints = 0;
                Debug.Log("Serialized Obstacle");
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(7);
        }

        Rect rect2 = EditorGUILayout.BeginHorizontal();
        Handles.color = Color.black;
        Handles.DrawLine(new Vector2(rect2.x - 15, rect2.y), new Vector2(rect2.width + 15, rect2.y));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();

        // Item Group
        isShowNewItem = EditorGUILayout.BeginFoldoutHeaderGroup(isShowNewItem, "New Item");

        if (isShowNewItem)
        {
            itemNameText = EditorGUILayout.TextField("Name:", itemNameText);
            itemDescriptionText = EditorGUILayout.TextField("Description:", itemDescriptionText);
            itemPrice = EditorGUILayout.IntField("Price:", itemPrice);
            isItemUnlocked = EditorGUILayout.Toggle("Unlocked:", isItemUnlocked);

            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);

            if (GUILayout.Button("Add", GUILayout.Width(100), GUILayout.Height(30)))
            {
                ItemDatabase.Items items = ItemDatabase.Items.GetInstance();
                items.list.Add(new Item(items.list.Count, isItemUnlocked, itemNameText, itemDescriptionText, itemPrice));
                Serialization.Serialize(items);
                itemNameText = "";
                itemDescriptionText = "";
                itemPrice = 0;
                isItemUnlocked = false;
                Debug.Log("Serialized Items");
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(7);
        }

        Rect rect3 = EditorGUILayout.BeginHorizontal();
        Handles.color = Color.black;
        Handles.DrawLine(new Vector2(rect3.x - 15, rect3.y), new Vector2(rect3.width + 15, rect3.y));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();

        // Trivia Group
        isShowNewTrivia = EditorGUILayout.BeginFoldoutHeaderGroup(isShowNewTrivia, "New Trivia");

        if (isShowNewTrivia)
        {
            triviaQuestionText = EditorGUILayout.TextField("Question:", triviaQuestionText);
            numberOfTriviaAnswers = EditorGUILayout.IntField("Number of Answers:", numberOfTriviaAnswers);
            
            if (numberOfTriviaAnswers != triviaAnswerList.Count)
            {
                if (numberOfTriviaAnswers < 0)
                {
                    numberOfTriviaAnswers = 0;
                }

                triviaAnswerList = new List<string>(numberOfTriviaAnswers);
            }

            EditorGUI.indentLevel += 3;

            for (int i = 0; i < numberOfTriviaAnswers; i++)
            {
                if (triviaAnswerList.Count < numberOfTriviaAnswers)
                {
                    triviaAnswerList.Add("");
                }
      
                triviaAnswerList[i] = EditorGUILayout.TextField("Answer " + i, triviaAnswerList[i]);
            }

            EditorGUI.indentLevel -= 3;

            triviaCorrectAnswer = EditorGUILayout.IntField("Correct Answer:", triviaCorrectAnswer);
            if (triviaCorrectAnswer < 0)
            {
                triviaCorrectAnswer = 0;
            }
            if (triviaCorrectAnswer >= numberOfTriviaAnswers)
            {
                triviaCorrectAnswer = numberOfTriviaAnswers - 1;
            }

            triviaReward = EditorGUILayout.IntField("Reward:", triviaReward);

            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);
            if (GUILayout.Button("Add", GUILayout.Width(100), GUILayout.Height(30)))
            {
                TriviaDatabase.TriviaListClass triviaListClass = TriviaDatabase.TriviaListClass.GetInstance();
                triviaListClass.list.Add(new Trivia(triviaListClass.list.Count, triviaQuestionText, triviaAnswerList, triviaCorrectAnswer, triviaReward));
                Serialization.Serialize(triviaListClass);
                triviaQuestionText = "";
                numberOfTriviaAnswers = 0;
                triviaCorrectAnswer = 0;
                triviaReward = 0;
                Debug.Log("Serialized Trivia");
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(7);
        }

        Rect rect4 = EditorGUILayout.BeginHorizontal();
        Handles.color = Color.black;
        Handles.DrawLine(new Vector2(rect4.x - 15, rect4.y), new Vector2(rect4.width + 15, rect4.y));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();

        // Event Group
        isShowNewEvent = EditorGUILayout.BeginFoldoutHeaderGroup(isShowNewEvent, "New Event");

        if (isShowNewEvent)
        {
            eventNameText = EditorGUILayout.TextField("Name:", eventNameText);
            eventDescriptionText = EditorGUILayout.TextField("Description:", eventDescriptionText);
            eventPrice = EditorGUILayout.IntField("Price:", eventPrice);
            isEventUnlocked = EditorGUILayout.Toggle("Unlocked:", isEventUnlocked);

            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);

            if (GUILayout.Button("Add", GUILayout.Width(100), GUILayout.Height(30)))
            {
                EventDatabase.Events events = EventDatabase.Events.GetInstance();
                events.list.Add(new Event(events.list.Count, isEventUnlocked, eventNameText, eventDescriptionText, eventPrice));
                Serialization.Serialize(events);
                eventNameText = "";
                eventDescriptionText = "";
                eventPrice = 0;
                isEventUnlocked = false;
                Debug.Log("Serialized Events");
            }

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(7);
        }

        Rect rect5 = EditorGUILayout.BeginHorizontal();
        Handles.color = Color.black;
        Handles.DrawLine(new Vector2(rect5.x - 15, rect5.y), new Vector2(rect5.width + 15, rect5.y));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

    private void OnInspectorUpdate()
    {

        Repaint();
    }
}