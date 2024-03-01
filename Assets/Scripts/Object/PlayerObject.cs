using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    void Awake()
    {
        AddInput();
    }
    
    private void OnDestroy()
    {
        RemoveInput();
    }

    public void AddInput()
    {
        BaseInputManager.Instance.SetCheckInput(true);
        BaseEventManager.Instance.AddEventListener<KeyCode>("OnGetKeyDown",OnGetKeyDown);
    }

    public void RemoveInput()
    {
        BaseEventManager.Instance.RemoveEventListener<KeyCode>("OnGetKeyDown",OnGetKeyDown);
    }

    private void OnGetKeyDown(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.W:
                break;
            case KeyCode.S:
                break;
            case KeyCode.A:
                break;
            case KeyCode.D:
                break;
            case KeyCode.Space:
                break;
            case KeyCode.J:
                break;
            case KeyCode.K:
                break;
            case KeyCode.L:
                break;
        }
    }
}