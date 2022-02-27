using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player") || collider2D.CompareTag("Bot ")){
            Destroy(objectToDestroy);
        }
    }

    
}
