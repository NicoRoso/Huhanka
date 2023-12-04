using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Locator : MonoBehaviour
{
    //[SerializeField] GameObject _testNumbersText;
    //[SerializeField] Transform _testDestination;
    [SerializeField] int distanceSwitch12;
    [SerializeField] int distanceSwitch23;
    [SerializeField] int distanceSwitch34;
    [SerializeField] int distanceSwitch45;

    [SerializeField] Transform _player;
    [HideInInspector]
    public Transform destination;
    float currentDistance;
    [SerializeField] LocatorStates locatorStates;
    LocatorState currentState;
    LocatorState previousState;
    AudioManager audioManager;
    [HideInInspector]
    public bool isOpeningPossible = false;
    public bool spawnerNeedCharge = false;
    private void Start()
    {
        audioManager = _player.GetComponent<AudioManager>();
    }
    public void SetLocatorDestination(Transform thisDestination)
    {
        destination = thisDestination;
    }
    private void FixedUpdate()
    {
        SetLocatorDestination(GameObject.FindObjectOfType<PlayerDestinations>().currentDestination); //�� ����� ����� ������ �� �������� PlayerDestinations � ���� �� 1 �������� � ������ destinations
        currentDistance = (_player.position - destination.position).magnitude;
        SetCurrentState();
        SetStateImageOnScreen();
        //TestSetStateValueOnScreen();
        if(currentState.number == 5 && !spawnerNeedCharge)
        {
            isOpeningPossible = true;
        }
        else
        {
            isOpeningPossible = false;
        }
        if(previousState != currentState)
        {
            OnSwitchState(currentState.number);
        }
        previousState = currentState;
    }

    LocatorState FindStateWithNumber(int num)
    {
        foreach(LocatorState state in locatorStates.states)
        {
            if(state.number == num)
            {
                return state;
            }
        }
        return FindStateWithNumber(1);
    }
    void SetCurrentState()
    {
        if (currentDistance > distanceSwitch12)
        {
            currentState = FindStateWithNumber(1);
        }
        else
        {
            if (currentDistance > distanceSwitch23)
            {
                currentState = FindStateWithNumber(2);
            }
            else
            {
                if (currentDistance > distanceSwitch34)
                {
                    currentState = FindStateWithNumber(3);
                }
                else
                {
                    if (currentDistance > distanceSwitch45)
                    {
                        currentState = FindStateWithNumber(4);
                    }
                    else
                    {
                       currentState = FindStateWithNumber(5);
                    }
                }
            }
        }
    }
    //void TestSetStateValueOnScreen()
    //{
    //    _testNumbersText.GetComponent<TextMeshProUGUI>().text = currentState.number.ToString();
    //}
    void SetStateImageOnScreen()
    {
        GetComponent<Image>().sprite = currentState.image;
    }
    public void ChangeDistances(int dist12, int dist23, int dist34, int dist45)
    {
        distanceSwitch12 = dist12;
        distanceSwitch23 = dist23;
        distanceSwitch34 = dist34;
        distanceSwitch45 = dist45;
    }

    void OnSwitchState(int state)
    {
        switch(state)
        {
            case 1:
                {
                    audioManager.SoftStop("locator2",10);
                    audioManager.SoftStop("locator3", 10);
                    audioManager.SoftStop("locator4", 10);
                    audioManager.SoftStop("locator5", 10);
                    break;
                }
            case 2:
                {
                    audioManager.Play("locator2");
                    audioManager.SoftStop("locator3", 10);
                    audioManager.SoftStop("locator4", 10);
                    audioManager.SoftStop("locator5", 10);
                    break;
                }
            case 3:
                {
                    audioManager.Play("locator3");
                    audioManager.SoftStop("locator2", 10);
                    audioManager.SoftStop("locator4", 10);
                    audioManager.SoftStop("locator5", 10);
                    break;
                }
            case 4:
                {
                    audioManager.Play("locator4");
                    audioManager.SoftStop("locator3", 10);
                    audioManager.SoftStop("locator2", 10);
                    audioManager.SoftStop("locator5", 10);
                    break;
                }
            case 5:
                {
                    audioManager.Play("locator5");
                    audioManager.SoftStop("locator3", 10);
                    audioManager.SoftStop("locator2", 10);
                    audioManager.SoftStop("locator4", 10);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
