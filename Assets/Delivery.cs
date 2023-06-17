using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
  [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
  [SerializeField] float destroyDelay =0.2f;

  
  bool isPicked=false;

  SpriteRenderer spriteRenderer;
  
  private void Start() 
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }
  public void OnCollisionEnter2D(Collision2D other)
{
    Debug.Log("Push em up push em up");
  }
  public void OnTriggerEnter2D(Collider2D other) 
  {
    
   if(other.tag == "Package" && !isPicked)
   {
    Debug.Log("Package picked up");
    isPicked=true;
    spriteRenderer.color=hasPackageColor;
    Destroy(other.gameObject,destroyDelay);
   }
  if( other.tag=="Customer" && isPicked){
    Debug.Log("Package delivered");
    spriteRenderer.color=noPackageColor;
    isPicked=false;
   }
  }
}
