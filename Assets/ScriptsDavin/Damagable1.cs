using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable1 : MonoBehaviour
{
    public UnityEvent onDamage;
    public void Hurt()
    {
        onDamage.Invoke();
    }
}
