using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private Button _button;

    private int _value;
    private Coroutine _coroutine; 

    public event Action<int> Changed;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(Run());
        }
    }

    private IEnumerator Run()
    {
        var wait = new WaitForSeconds(_interval);

        while (enabled) 
        {
            yield return wait;

            _value++;

            Changed.Invoke(_value);
        }
    }
}