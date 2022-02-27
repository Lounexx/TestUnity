using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public float invincibilityFlashDelay = 0.2f;

    public float invincibilityDuration = 3f;

    public static PlayerHealth instance;

    void Awake(){
        if(instance != null){
            Debug.LogWarning("ERROR");
            return;
        }
        instance = this;
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);   
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            takeDamage(10);
        }
    }

    public void takeDamage(int damage){
        if(!isInvincible){
            currentHealth = currentHealth - damage;
            healthBar.setHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash(){
        while(isInvincible){
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay(){
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

}
