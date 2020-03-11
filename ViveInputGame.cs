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
    //public SteamVR_Action_Vector2 trackpadAction;
    public SteamVR_Action_Boolean snapLeft;
    public SteamVR_Action_Boolean snapRight;
    public AnswerHighlighter answerHighlighter;




    // Use this for initialization

    void OnEnable()
    {
        questionAnswerManager = FindObjectOfType<QuestionAnswerManager>();
        //Vector2 trackpadValue = trackpadAction.GetAxis(SteamVR_Input_Sources.Any);
        
        if (grabPinch != null)
        {
            grabPinch.AddOnStateDownListener(OnTriggerPressedOrReleased, inputSource);
        }
       
        if (snapLeft != null)
        {
            snapLeft.AddOnStateDownListener(OnSnapLeftPressed,SteamVR_Input_Sources.RightHand);
        }
        if (snapRight != null)
        {
            snapRight.AddOnStateDownListener(OnSnapRightPressed, SteamVR_Input_Sources.RightHand);
        }


    }

  

    private void OnSnapRightPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("SNapRightPressed");
        answerHighlighter.changeToggleID(1);
    }

    private void OnSnapLeftPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("SNapLeftPressed");
        answerHighlighter.changeToggleID(-1);
    }

    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        questionAnswerManager.SubmitAnswer();
        answerHighlighter.SelectToggle(3);
    }

    

}
