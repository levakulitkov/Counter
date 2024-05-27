using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _interval;

    private int _value;
    private Coroutine _coroutine; 

    public event Action<int> Changed;

    public void OnClicked()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
            _coroutine = StartCoroutine(StartCounter());
    }

    private IEnumerator StartCounter()
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