using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlexibleTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter2D;
    public UnityEvent onTriggerExit2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter2D?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit2D?.Invoke();
    }
}

