using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInputMenu : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public MenuScreenController screenController;
    private GameController gameController;
    private bool gameInOn = false;

    // Use this for initialization

    void OnEnable()

        
    {
        gameController = FindObjectOfType<GameController>();

        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }

    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        Debug.Log("Trigger was pressed or released");
        if (gameInOn == false)
        {
            screenController.StartGame();
            gameInOn = true;
        }

        else
        {
            Debug.Log("something else");
        }

       







}




}
