using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase;
using Firebase.Analytics;

public class FirebaseInit : MonoBehaviour
{


    //Firebase Initialization
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {

            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
               FirebaseApp app = FirebaseApp.DefaultInstance;
                Debug.Log("Firebase SDK Is initialized succesfully");
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                  Debug.LogError(String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }


    #region Button functions

    public void LogMeButton()
    {
        FirebaseAnalytics.LogEvent("LogMe_Button_Pressed");
    }

    public void PressNumberButton(int number)
    {
        FirebaseAnalytics.LogEvent("Press_Number_Button_Pressed", new Parameter[] { 
            new Parameter("ButtonNumber", number),
        });
    }

    #endregion
}
