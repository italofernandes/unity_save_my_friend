using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 10f;
    public float turningSpeed = 5000f;
    public bool isEnabled;
    public int damegeAmount = 20;

    public float timeBetweenAttacks = 0.7f;
    float timer;

    bool isDead;

    static readonly string RUN_ANIMATOR_CONSTANT = "run";
    static readonly string ATTACK_ANIMATOR_CONSTANT = "attack";

    Animator anim;

    bool enemyInRange;

    GameObject enemy;

    GameObject otherElement;

    bool playerHasTheKey;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isEnabled = true;

        enemyInRange = false;

        playerHasTheKey = false;
    }

    void OnTriggerEnter(Collider other) 
    { 
        if(other.gameObject.tag.Equals("Enemy"))
        {
            enemyInRange = true;

            enemy = other.gameObject;
        }
        else 
        {
            otherElement = other.gameObject;    
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemyInRange = false;

            enemy = null;
        }
        else 
        {
            otherElement = null;
        }
    }

    // Update is called once per frame
	void Update () {
        if(isEnabled){

        timer += Time.deltaTime;

        float horizontalLook = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontalLook, 0);
        
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        //TODO Use Mecanin to blend these two animations.
        ExecuteActions(horizontal, vertical, Input.GetButton("Fire1"));

        transform.Translate(horizontal, 0, vertical);
        }
	}

    void ExecuteActions(float horizontal, float vertical, bool isAttacking) {
        if (horizontal != 0 || vertical != 0){

            anim.SetBool(RUN_ANIMATOR_CONSTANT, true);
        } else {

            anim.SetBool(RUN_ANIMATOR_CONSTANT, false); 
            
            if(isAttacking && timer >= timeBetweenAttacks){

                timer = 0;

                AnimateAttackAction();

                if (enemy != null && enemyInRange)
                {
                    EnemyHealthScript enemyHealthScript = enemy.GetComponent<EnemyHealthScript>();
                    enemyHealthScript.takeDamage(damegeAmount);
                }
                else if (otherElement.tag.Equals("BlueDoorLock"))
                {
                    DoorScript doorScript = otherElement.GetComponent<DoorScript>();
                    doorScript.OpenDoor(playerHasTheKey);
                }
            }
        }
    }

    void AnimateAttackAction() {
        anim.SetTrigger(ATTACK_ANIMATOR_CONSTANT);
    }

    public void setControllerEnabled(bool isEnabled){
        this.isEnabled  = isEnabled;
    }

    public void GivePlayerTheKey() 
    {
        playerHasTheKey = true;
    }

    public bool PlayerHasTheKey() 
    {
        return playerHasTheKey;
    }
}   
