using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

    public int maxHealth = 100;
    int damageTaken;

    Animator anim;

    bool isDead;

    static readonly string DEATH_ANIMATION_TRIGGER = "enemy_dead";

    EnemyMovementScript enemyMovementScript;

    GameObject key;


    // Use this for initialization
	void Awake () 
    {
        anim = GetComponent<Animator>();
        damageTaken = maxHealth;
        isDead = false;
            
        enemyMovementScript = GetComponent<EnemyMovementScript>();

        key = GameObject.FindGameObjectWithTag("Key");

        key.SetActive(false);
	}

    public void takeDamage(int damage) 
    {

        //Debug.Log("Dealing damage "+damage);
 
        damageTaken -= damage;

        Debug.Log("Damage Taken " + damageTaken);

        if(damageTaken <= 0 && !isDead)
        {
            killEnenmy();
        }
    }

    void killEnenmy() 
    {
        isDead = true;

        anim.SetTrigger(DEATH_ANIMATION_TRIGGER);

        enemyMovementScript.EnableMovemnt(false);

        key.SetActive(true);
    }

    public bool IsEnemyDead() 
    {
        return isDead;
    }

    public void DestroyEnemyGameObject()
    {
        Destroy(gameObject);
    }
}
