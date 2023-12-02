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

    private void Start()
    {
        _canvasTime.SetActive(true);
        _canvasDeath.SetActive(false);

       //_timer = 60f;

        _slider.maxValue = _timer;
        _slider.value = _timer;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _canvasTime.SetActive(false);
            _canvasDeath.SetActive(true);
            
        }

        _slider.value = _timer;
    }
}
