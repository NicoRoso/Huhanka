using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private float _timer;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private GameObject _canvasTime;

    [SerializeField]
    private GameObject _canvasEnd;

    [SerializeField]
    private bool isStarted;

    private void Start()
    {
        isStarted = false;
        _canvasTime.SetActive(false);
        _canvasEnd.SetActive(false);


        _slider.maxValue = _timer;
        _slider.value = _timer;
    }

    private void Update()
    {
        if (isStarted)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _canvasTime.SetActive(false);
                _canvasEnd.SetActive(true);
                _timer = 0;
            }

            if (_slider.value < _slider.maxValue / 2.5f)
            {
                _slider.GetComponent<Animator>().SetTrigger("Critical");
            }
            _slider.value = _timer;
        }
    }

    public void StartTimerToEnd(bool isStart, float seconds)
    {
        isStarted = isStart;
        _timer = seconds;
        _slider.maxValue = seconds;

        _canvasTime.SetActive(isStart);
    }
}
