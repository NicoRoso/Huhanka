using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeDeath : MonoBehaviour
{
    [SerializeField]
    private float _timer;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private GameObject _canvasTime;

    [SerializeField]
    private GameObject _canvasDeath;

    [SerializeField]
    private bool isStarted;

    private void Start()
    {
        isStarted = false;
        _canvasTime.SetActive(false);
        _canvasDeath.SetActive(false);

       //_timer = 60f;

        _slider.maxValue = _timer;
        _slider.value = _timer;
    }

    private void Update()
    {
        if (isStarted)
        {
            _canvasTime.SetActive(true);
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _canvasTime.SetActive(false);
                _canvasDeath.SetActive(true);
                _timer = 0;

            }

            if (_slider.value < _slider.maxValue / 2.5f)
            {
                _slider.GetComponent<Animator>().SetTrigger("Critical");
            }
            _slider.value = _timer;
        }
    }

    public void StartTimer(bool isStart)
    {
        isStarted = isStart;
    }
}
