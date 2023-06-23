using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointColliection : MonoBehaviour
{
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
        }
    } 
}
