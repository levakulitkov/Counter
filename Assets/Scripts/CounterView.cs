using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _counter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnChanged;
    }

    private void OnChanged(int value)
    {
        _text.text = value.ToString();
    }
}