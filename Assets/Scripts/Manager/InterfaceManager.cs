using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Button joinPlayerOne;
    [SerializeField]
    private Button joinPlayerTwo;

    //TODO: Add PlayerTwoButton reference - DONE

    [SerializeField]
    private SplitKeyboardPlayerInputManager playerInputManager;
    // Start is called before the first frame update
    void Start()
    {
        joinPlayerOne.onClick.AddListener(() => JoinPlayerOne());
        //TODO Listen for player two click event - DONE
        joinPlayerTwo.onClick.AddListener(() => JoinPlayerTwo());
    }

    private void JoinPlayerOne()
    {
        playerInputManager.JoinPlayer(0, "Keyboard&Mouse");
        //TODO flip text to say "Leave Player One" - DONE
        //TODO on click after player has joined, remove player
        joinPlayerOne.GetComponentInChildren<Text>().text = "Leave Player One";
        joinPlayerOne.onClick.RemoveAllListeners();
        joinPlayerOne.onClick.AddListener(() => LeavePlayerOne());
    }

    private void LeavePlayerOne()
    {
        //playerInputManager.LeavePlayer(0);
        GameObject.Find("PlayerInputManager").GetComponent<SplitKeyboardPlayerInputManager>().LeavePlayer(0);
        joinPlayerOne.GetComponentInChildren<Text>().text = "Join Player One";
        joinPlayerOne.onClick.RemoveAllListeners();
        joinPlayerOne.onClick.AddListener(() => JoinPlayerOne());
    }

    private void JoinPlayerTwo()
    {
        playerInputManager.JoinPlayer(1, "PlayerTwo");
        joinPlayerTwo.GetComponentInChildren<Text>().text = "Leave Player Two";
        joinPlayerTwo.onClick.RemoveAllListeners();
        joinPlayerTwo.onClick.AddListener(() => LeavePlayerTwo());
    }

    private void LeavePlayerTwo()
    {
        GameObject.Find("PlayerInputManager").GetComponent<SplitKeyboardPlayerInputManager>().LeavePlayer(1);
        joinPlayerTwo.GetComponentInChildren<Text>().text = "Join Player Two";
        joinPlayerTwo.onClick.RemoveAllListeners();
        joinPlayerTwo.onClick.AddListener(() => JoinPlayerTwo());
    }

    //TODO Invoke JoinPlayer passing a playerIndex value and targeting a control scheme - DONE
    //TODO flip text after player has joined to say "Leave Player Two" - DONE
    //TODO on click after player has joined, remove player - DONE
}
