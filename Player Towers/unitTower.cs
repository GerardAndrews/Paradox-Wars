using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class unitTower : MonoBehaviour {

    //Prepare the projectile for the tower
    public GameObject projectilePrefab;

    //Cooldown and fire timer
    public float fireCD = 2;
    public float fireCDLeft = 0;

    public float range;

    //Setup our enemies list
    GameObject[] enemies = null;
    GameObject closest;

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
    public AudioSource attackProjectile;

    public float cost;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        ConfigureEnemyList();

        // First the tower must find the closest position of the enemy
        FindClosestEnemy();

        //Keep track of how close the target is
        Vector3 dir = closest.transform.position - this.transform.position;

        //Once in range
        if (dir.magnitude <= range)
        {
            //Start Shooting Cooldown
            fireCDLeft -= Time.deltaTime;
            if (fireCDLeft <= 0)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        GameObject rockGO = Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
        Projectile br = rockGO.GetComponent<Projectile>();
        attackProjectile.Play();
        if (closest == null)
        {
            Destroy(rockGO);
        }
        br.target = closest.transform;
        fireCDLeft = fireCD;
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

    void ConfigureEnemyList()
    {
        // Look for enemies
        giraffes = GameObject.FindGameObjectsWithTag("Giraffe");
        swordArms = GameObject.FindGameObjectsWithTag("SwordArm");
        twoEnemies = giraffes.Concat(swordArms).ToArray();
        flyingPigs = GameObject.FindGameObjectsWithTag("FlyingPig");
        threeEnemies = twoEnemies.Concat(flyingPigs).ToArray();
        giants = GameObject.FindGameObjectsWithTag("Giant");
        fourEnemies = threeEnemies.Concat(giants).ToArray();
        sharkWheels = GameObject.FindGameObjectsWithTag("Sharkwheel");
        fiveEnemies = fourEnemies.Concat(sharkWheels).ToArray();
        brainTanks = GameObject.FindGameObjectsWithTag("Brain Tank");
        sixEnemies = fiveEnemies.Concat(brainTanks).ToArray();
        ratHelis = GameObject.FindGameObjectsWithTag("Helicopter Rat");
        sevenEnemies = sixEnemies.Concat(ratHelis).ToArray();
        rocketGuys = GameObject.FindGameObjectsWithTag("Rocket Guy");
        eightEnemies = sevenEnemies.Concat(rocketGuys).ToArray();
        REU1 = GameObject.FindGameObjectsWithTag("REU1");
        nineEnemies = eightEnemies.Concat(ratHelis).ToArray();
        REU2 = GameObject.FindGameObjectsWithTag("REU2");
        tenEnemies = nineEnemies.Concat(ratHelis).ToArray();
        REU3 = GameObject.FindGameObjectsWithTag("REU3 ");
        elevenEnemies = tenEnemies.Concat(ratHelis).ToArray();
        REU4 = GameObject.FindGameObjectsWithTag("REU4");
        //Combine mutiple tags into a super list
        enemies = elevenEnemies.Concat(REU4).ToArray();
    }
}
