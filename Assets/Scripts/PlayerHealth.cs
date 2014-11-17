using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    static readonly string DEAD_ANIMATION_TRIGGER = "dead";

    Animator anim;
    PlayerController playerController;
    
    EnemyMovementScript enemyMovScript;

    GameObject enemy;

    bool isDead;

	// Use this for initialization
	void  Awake () {
	     anim = GetComponent<Animator>();
         playerController = GetComponent<PlayerController>();

         enemy = GameObject.FindGameObjectWithTag("Enemy");
         enemyMovScript = enemy.GetComponent<EnemyMovementScript>();

         currentHealth = startingHealth;
	}
	
    public void TakeDamage (int amount){

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead){
            KillPalyer();
        }
    }

    void KillPalyer() {
        isDead = true;

        anim.SetTrigger(DEAD_ANIMATION_TRIGGER);

        playerController.setControllerEnabled(false);

        enemyMovScript.EnableMovemnt(false);
    }
}
