// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     [HideInInspector]
//     public Rigidbody2D rb;
//     [HideInInspector]
//     public CircleCollider2D col;

//     [HideInInspector]
//     public Vector3 HumanPos{ get { return transform.position}}

//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         col = GetComponent<CircleCollider2D>();
//     } 

//     public void Push (Vector3 force)
//     {
//         rb.AddForce (force, ForceMode2D.Impulse);
//     }

//     public void ActivateRb()
//     {
//         rb.isKinematic = false;
//     }

//     public void DesactivateRb()
//     {
//         rb.velocity = Vector3.Zero;
//         rb.angularVelocity = 0f;
//         rb.isKinematic = true;
//     }
// }
