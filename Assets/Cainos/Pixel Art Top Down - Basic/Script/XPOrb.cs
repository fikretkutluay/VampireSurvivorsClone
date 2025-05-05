using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           XPManager xp = other.GetComponent<XPManager>();
           if (xp != null)
           {
               xp.AddXP(xpAmount);
               Destroy(gameObject);
           }
        }
    }
}
