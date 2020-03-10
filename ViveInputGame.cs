using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInputGame : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    private QuestionAnswerManager questionAnswerManager;




    // Use this for initialization

    void OnEnable()
    {
        questionAnswerManager = FindObjectOfType<QuestionAnswerManager>();

        
        if (grabPinch != null)
        {
            grabPinch.AddOnStateDownListener(OnTriggerPressedOrReleased, inputSource);
        }
    }

    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        questionAnswerManager.SubmitAnswer();
    }

}
