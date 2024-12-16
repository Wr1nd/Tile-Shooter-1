using System;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   public GameObject player;

   public bool flip;
   public bool grounded;
   public LayerMask groundLayer;
   public float groundDistance;
   public float speed;
   //one
   private void Update()
   {
      Vector3 scale = transform.localScale;
      
      RaycastHit2D hit = Physics2D.Raycast( transform.position, Vector2.down,groundDistance,groundLayer);
      grounded = hit.collider != null;
      
      if (player.transform.position.x < transform.position.x)
      {
         scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
         transform.Translate(speed * Time.deltaTime, 0, 0);
      }
      else
      {
         scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
         transform.Translate(speed * Time.deltaTime, 0, 0);
      }
      
      transform.localScale = scale;
   }
}
