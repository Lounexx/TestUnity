using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
    public int numberOfPlayersOnSpot;

    void Awake(){
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

   void OnTriggerEnter2D(Collider2D collider2D){
       numberOfPlayersOnSpot+=1;
       if(collider2D.CompareTag("Player") &&  numberOfPlayersOnSpot == 2 || collider2D.CompareTag("Bot") && numberOfPlayersOnSpot == 2){
           StartCoroutine(loadNextScene());
       }
   }

   void OnTriggerExit2D(Collider2D collider2D){
       if((collider2D.CompareTag("Player") || collider2D.CompareTag("Bot")) && numberOfPlayersOnSpot != 2){
           numberOfPlayersOnSpot-=1;
       }
   }

   public IEnumerator loadNextScene(){
       fadeSystem.SetTrigger("FadeIn");
       yield return new WaitForSeconds(1f);
       SceneManager.LoadScene(sceneName);
   }
}
