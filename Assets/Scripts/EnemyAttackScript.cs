using UnityEngine;
using System.Collections;

public class EnemyAttackScript : MonoBehaviour {

    public float timeBetweenAttacks;
    public int attackDemage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;
    EnemyHealthScript enemyHealthScript;

    static readonly string PLAYER_IS_DEAD = "player_dead";

	// Use this for initialization
	void Awake () 
    {
        player = GameObject.FindGameObjectWithTag("Hero23");
        playerHealth = player.GetComponent<PlayerHealth>();

        anim = GetComponent<Animator>();

        enemyHealthScript = GetComponent<EnemyHealthScript>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player){
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange){
            Attack();
        }

        if(playerHealth.currentHealth <= 0){
            anim.SetTrigger(PLAYER_IS_DEAD);
        }
	}

    void Attack() 
    {
        timer = 0;

        if(playerHealth.currentHealth > 0 && !enemyHealthScript.IsEnemyDead())
        {
            playerHealth.TakeDamage(attackDemage);
        }
    }
}
