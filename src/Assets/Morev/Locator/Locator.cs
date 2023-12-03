using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Locator : MonoBehaviour
{
    [SerializeField] GameObject _testNumbersText;
    //[SerializeField] Transform _testDestination;
    [SerializeField] GameObject _image;

    [SerializeField] int distanceSwitch12;
    [SerializeField] int distanceSwitch23;
    [SerializeField] int distanceSwitch34;
    [SerializeField] int distanceSwitch45;

    [SerializeField] Transform _player;
    public Transform destination;
    float currentDistance;
    [SerializeField] LocatorStates locatorStates;
    LocatorState currentState;
    public bool isOpeningPossible = false;
    private void Start()
    {
        //SetLocatorDestination(_testDestination);
    }
    public void SetLocatorDestination(Transform thisDestination)
    {
        destination = thisDestination;
    }
    private void FixedUpdate()
    {
        SetLocatorDestination(GameObject.FindObjectOfType<PlayerDestinations>().currentDestination);
        currentDistance = (_player.position - destination.position).magnitude;
        SetCurrentState();
        //SetStateImageOnScreen();
        TestSetStateValueOnScreen();
        if(currentState.number == 5)
        {
            isOpeningPossible = true;
        }
        else
        {
            isOpeningPossible = false;
        }
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
    void TestSetStateValueOnScreen()
    {
        _testNumbersText.GetComponent<TextMeshProUGUI>().text = currentState.number.ToString();
    }
    void SetStateImageOnScreen()
    {
        _image.GetComponent<Image>().sprite = currentState.image;
    }
    void SetSoundOfThisState()
    {
        // переключение звуковых вариаций локатора
    }
    public void ChangeDistances(int dist12, int dist23, int dist34, int dist45)
    {
        distanceSwitch12 = dist12;
        distanceSwitch23 = dist23;
        distanceSwitch34 = dist34;
        distanceSwitch45 = dist45;
    }
}
