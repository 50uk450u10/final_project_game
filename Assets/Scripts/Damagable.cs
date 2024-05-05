using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField] UnityEvent onDamage;
    public void Hurt()
    {
        onDamage?.Invoke();
    }
}
