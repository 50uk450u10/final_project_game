using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgerCloseScript : MonoBehaviour
{
    [SerializeField] HydraHeadScript hydra;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hydra.swing.Invoke();
    }
}
