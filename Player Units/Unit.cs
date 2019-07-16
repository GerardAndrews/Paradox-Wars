using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Unit : MonoBehaviour
{
    // Ready their stats
    public float speed;
    public float health;
    public float range;

    // Prepare Projectile and Cooldown between shots
    public GameObject rockPrefab;
    public GameObject antiBasePrefab;

    public float fireCD = 2;
    public float fireCDLeft = 0;

    // Prepare a super lsit
    GameObject[] enemies = null;
    GameObject closest;

    // Setup all states for the unit
    bool attackMode;
    bool assaultMode;
    bool attackingBase;

    // Setup the base
    GameObject eBase;
    GameObject other;

    // Prepare all sublists
    GameObject[] giraffes;
    GameObject[] flyingPigs;
    GameObject[] swordArms;
    GameObject[] twoEnemies;
    GameObject[] giants;
    GameObject[] rocketGuys;
    GameObject[] sharkWheels;
    GameObject[] brainTanks;
    GameObject[] ratHelis;
    GameObject[] REU1;
    GameObject[] REU2;
    GameObject[] REU3;
    GameObject[] REU4;
    GameObject[] threeEnemies;
    GameObject[] fourEnemies;
    GameObject[] fiveEnemies;
    GameObject[] sixEnemies;
    GameObject[] sevenEnemies;
    GameObject[] eightEnemies;
    GameObject[] nineEnemies;
    GameObject[] tenEnemies;
    GameObject[] elevenEnemies;

    // Setup the unit animator
    public Animator anim;

    // Bool to check if they are unconscious
    public bool isUnconscious;
    float statusCD;
    float statusTimer;

    Vector3 bDir;


    void Start()
    {
        eBase = GameObject.FindGameObjectWithTag("EBase");

        other = GameObject.FindGameObjectWithTag("GameController");


        assaultMode = true;
        attackMode = false;
        anim.SetBool("Moving", true);
        anim.SetBool("Attacking", false);
        attackingBase = false;

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
                if (eBase == null)
                {
                    attackingBase = false;
                    assaultMode = true;
                    anim.SetBool("Moving", true);
                    anim.SetBool("Attacking", false);
                }

                else
                {
                    //Throw antiBase projectile when the cooldown hits 0
                    attackBase();
                }
            }
        }

        // If a unit is unconscious they cannot do anything for a certain amount of time
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
        if (other.gameObject.GetComponent<Policies>().eliteTraining == true)
        {
            health = 40;
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
        ConfigureEnemyList();

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
                    //BUG: placing unitCheck here teleports unit to base

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
        Projectile br = rockGO.GetComponent<Projectile>();
        if (closest == null)
        {
            assaultMode = true;
            attackMode = false;
            attackingBase = false;
            anim.SetBool("Moving", true);
            anim.SetBool("Attacking", false);
            Destroy(rockGO);
        }
        br.target = closest.transform;
        fireCDLeft = fireCD;

    }

    //This function is have a unit fire projectiles at the base
    void attackBase()
    {
        GameObject antiBaseGO = Instantiate(antiBasePrefab, this.transform.position, this.transform.rotation);
        Anti_Base_Projectile b = antiBaseGO.GetComponent<Anti_Base_Projectile>();
        b.target = eBase.transform;
        fireCDLeft = fireCD;

    }

    //We need a function where any unit takes damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (isUnconscious == true)
            {
                other.gameObject.GetComponent<GameController>().enemyPOWS += 1;
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
    }

    void ConfigureEnemyList()
    {
        // Look for enemies
        giraffes = GameObject.FindGameObjectsWithTag("Giraffe");// 1
        swordArms = GameObject.FindGameObjectsWithTag("SwordArm"); // 2
        twoEnemies = giraffes.Concat(swordArms).ToArray(); 
        flyingPigs = GameObject.FindGameObjectsWithTag("FlyingPig");// 3
        threeEnemies = twoEnemies.Concat(flyingPigs).ToArray();
        giants = GameObject.FindGameObjectsWithTag("Giant");// 4
        fourEnemies = threeEnemies.Concat(giants).ToArray();
        sharkWheels = GameObject.FindGameObjectsWithTag("Sharkwheel");// 5
        fiveEnemies = fourEnemies.Concat(sharkWheels).ToArray();
        brainTanks = GameObject.FindGameObjectsWithTag("Brain Tank"); // 6
        sixEnemies = fiveEnemies.Concat(brainTanks).ToArray();
        ratHelis = GameObject.FindGameObjectsWithTag("Helicopter Rat"); // 7
        sevenEnemies = sixEnemies.Concat(ratHelis).ToArray();
        rocketGuys = GameObject.FindGameObjectsWithTag("Rocket Guy"); // 8
        eightEnemies = sevenEnemies.Concat(rocketGuys).ToArray();
        REU1 = GameObject.FindGameObjectsWithTag("REU1"); // 9
        nineEnemies = eightEnemies.Concat(ratHelis).ToArray();
        REU2 = GameObject.FindGameObjectsWithTag("REU2"); // 10
        tenEnemies = nineEnemies.Concat(ratHelis).ToArray();
        REU3 = GameObject.FindGameObjectsWithTag("REU3 "); // 11
        elevenEnemies = tenEnemies.Concat(ratHelis).ToArray();
        REU4 = GameObject.FindGameObjectsWithTag("REU4"); // 12
        //Combine mutiple tags into a super list
        enemies = elevenEnemies.Concat(REU4).ToArray();
    }
}
