using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerSight : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();
        if(c != null && c != player)
        {
            player.AddTarget(c);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();
        if (c != null && c != player)
        {
            player.RemoveTarget(c);
        }
    }
}
