using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_Unit_Movement : MonoBehaviour
{

    //We need to see if enemies are on the map

    public float speed;
    public float health;
    public float range;

    public float moneyValue;


    //Prepare Projectile and Cooldown between shots
    public GameObject rockPrefab;
    public GameObject antiBasePrefab;

    public float fireCD = 2;
    public float fireCDLeft = 0;

    GameObject[] enemies = null;
    GameObject closest;

    bool attackMode;
    bool assaultMode;
    bool attackingBase;

    //Setup Gameobject lists
    GameObject[] slingers;
    GameObject[] chariots;
    GameObject[] twoEnemies;
    GameObject[] spearmen;
    GameObject[] threeEnemies;
    GameObject[] knights;
    GameObject[] fourEnemies;
    GameObject[] horse_archers;
    GameObject[] fiveEnemies;
    GameObject[] ninjas;
    GameObject[] sixEnemies;
    GameObject[] swordmen;
    GameObject[] sevenEnemies;
    GameObject[] tGiants;
    GameObject[] eightEnemies;
    GameObject[] musketmen;
    GameObject[] nineEnemies;
    GameObject[] grenadiers;
    GameObject[] tenEnemies;
    GameObject[] PU3;
    GameObject[] elevenEnemies;
    GameObject[] PU4;

    GameObject other;

    GameObject eBase;
    Vector3 bDir;

    // Setup the animator
    public Animator anim;

    // Bool to check if they are unconscious
    public bool isUnconscious;
    float statusCD;
    float statusTimer;

    void Start()
    {
        //Dead = GetComponent<AudioSource>();

        other = GameObject.FindGameObjectWithTag("GameController");

        eBase = GameObject.FindGameObjectWithTag("PBase");

        assaultMode = true;
        anim.SetBool("Moving", true);
        anim.SetBool("Attacking", false);
        // anim.SetBool("Moving", true);
        // anim.SetBool("Moving", false);
        attackMode = false;
        attackingBase = false;

        isUnconscious = false;

        statusCD = 2.0f;
        statusTimer = 2.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //Look for units constantly
        unitCheck();

        //Check if a unit is preparing to attack
        if (attackMode)
        {
            FindClosestEnemy();
            Vector3 dir = closest.transform.position - this.transform.position;
            // Unit must stop in place
            transform.position = this.transform.position;

            //Cooldown decreases
            fireCDLeft -= Time.deltaTime;

            if (fireCDLeft <= 0)
            {
                if (dir.magnitude >= range)
                {
                    attackMode = false;
                    assaultMode = true;
                    anim.SetBool("Moving", true);
                    anim.SetBool("Attacking", false);
                    unitCheck();
                }
                //Throw projectile when the cooldown hits 0
                else
                {
                    Attack(closest);
                }
            }
        }

        if (attackingBase)
        {
            transform.position = this.transform.position;

            //Cooldown decreases
            fireCDLeft -= Time.deltaTime;

            if (fireCDLeft <= 0)
            {
                //Base Destroyed?
                if (eBase == null)
                {
                    //Stay here
                    transform.position = this.transform.position;
                }

                else
                {
                    //Throw antiBase projectile when the cooldown hits 0
                    attackBase();
                }
            }
        }

        if (isUnconscious == true)
        {
            transform.position = this.transform.position;
            assaultMode = false;
            attackingBase = false;
            attackMode = false;

            anim.SetBool("Moving", false);
            anim.SetBool("Attacking", false);

            statusCD -= Time.deltaTime;
            // Regain Consciousness and move again
            if (statusCD <= 0)
            {
                isUnconscious = false;
                anim.SetBool("Moving", true);
                anim.SetBool("Attacking", false);
                assaultMode = true;
                unitCheck();
                statusCD = statusTimer;
            }

        }

    }
    public GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        // return the coords for the nearest enemy;
        return closest;
    }

    public void unitCheck()
    {
        configureEnemyList();

        // If there is at least 1 enemy on the map
        if (enemies.Length >= 1)
        {
            // Find the nearest target to move to
            FindClosestEnemy();
            Vector3 dir = closest.transform.position - this.transform.position;
            if (assaultMode)
            {
                // Go to that enemy
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, step);

                // If it's in attacking range
                if (dir.magnitude <= range)
                {
                    //Get ready to attack
                    attackMode = true;
                    assaultMode = false;
                    attackingBase = false;

                    anim.SetBool("Moving", false);
                    anim.SetBool("Attacking", true);

                }

                else
                {
                    // No point in getting ready to attack
                    assaultMode = true;
                    attackMode = false;
                    attackingBase = false;

                    anim.SetBool("Moving", true);
                    anim.SetBool("Attacking", false);
                    FindClosestEnemy();
                    

                }
            }
        }


        // No Enemies!?
        else
        {
            // Go to the enemy base
            baseCheck();
        }
    }

    void baseCheck()
    {
        if (assaultMode)
        {
            float step = speed * Time.deltaTime;
            Vector3 bDir = eBase.transform.position - this.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, eBase.transform.position, step);

            if (bDir.magnitude <= range)
            {
                attackingBase = true;
                assaultMode = false;
                attackMode = false;

                anim.SetBool("Moving", false);
                anim.SetBool("Attacking", true);
            }
        }

    }

    //This function fires projectiles at any unit
    void Attack(GameObject closest)
    {
        GameObject rockGO = Instantiate(rockPrefab, this.transform.position, this.transform.rotation);
        eProjectile br = rockGO.GetComponent<eProjectile>();
        if (closest == null)
        {
            anim.SetBool("Moving", true);
            anim.SetBool("Attacking", false);

            assaultMode = true;
            attackMode = false;
            attackingBase = false;
            Destroy(rockGO);
        }
        br.target = closest.transform;
        fireCDLeft = fireCD;

    }

    //This function is have a unit fire projectiles at the base
    void attackBase()
    {
        GameObject antiBaseGO = Instantiate(antiBasePrefab, this.transform.position, this.transform.rotation);
        eAnti_Base_Projectile b = antiBaseGO.GetComponent<eAnti_Base_Projectile>();
        b.target = eBase.transform;
        fireCDLeft = fireCD;

    }

    //We need a function where any unit takes damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) { 
            if (isUnconscious == true)
            {
                other.gameObject.GetComponent<GameController>().pOWS += 1;
                Die();
            }
            else
            {
                Die();
            }
    }
}

    public void Die()
    {
        Destroy(gameObject);
        other.gameObject.GetComponent<GameController>().money += moneyValue;
    }

    void configureEnemyList()
    {
        slingers = GameObject.FindGameObjectsWithTag("Slinger");
        spearmen = GameObject.FindGameObjectsWithTag("Spearman");
        twoEnemies = slingers.Concat(spearmen).ToArray(); // 2 Enemies
        chariots = GameObject.FindGameObjectsWithTag("Chariot");
        threeEnemies = twoEnemies.Concat(chariots).ToArray(); // 3 enemies
        knights = GameObject.FindGameObjectsWithTag("Knight");
        fourEnemies = threeEnemies.Concat(knights).ToArray(); // 4 Enemies
        horse_archers = GameObject.FindGameObjectsWithTag("Horse Archer");
        fiveEnemies = fourEnemies.Concat(horse_archers).ToArray(); // 5 Enemies
        ninjas = GameObject.FindGameObjectsWithTag("NinjaBox");
        sixEnemies = fiveEnemies.Concat(ninjas).ToArray(); // 6 Enemies
        swordmen = GameObject.FindGameObjectsWithTag("Swordman");
        sevenEnemies = sixEnemies.Concat(swordmen).ToArray(); // 7 Enemies
        tGiants = GameObject.FindGameObjectsWithTag("TGiant");
        eightEnemies = sevenEnemies.Concat(tGiants).ToArray();// 8 Enemies
        musketmen = GameObject.FindGameObjectsWithTag("Musketman");
        nineEnemies = eightEnemies.Concat(musketmen).ToArray(); // 9 Enemies
        grenadiers = GameObject.FindGameObjectsWithTag("Grenadier");
        tenEnemies = nineEnemies.Concat(grenadiers).ToArray(); // 10 Enemies
        PU3 = GameObject.FindGameObjectsWithTag("PU3");
        elevenEnemies = tenEnemies.Concat(PU3).ToArray(); // 11 Enemies
        PU4 = GameObject.FindGameObjectsWithTag("PU4");
        enemies = elevenEnemies.Concat(PU4).ToArray(); // 12 Enemies
    }
}
