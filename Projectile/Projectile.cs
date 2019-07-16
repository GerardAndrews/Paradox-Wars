using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    //Speed will vary based on the unit
    public float speed;
    public Transform target;
    public float damage;

    // Float in calculating chance to make a unit unconscious
    // public float statusChance;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (target == null)
        {
            //Enemy is gone
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            HitTarget();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
        }
	}

    void HitTarget()
    {

        int chance = Random.Range(0, 100);
        if (chance <= 15) {
            target.GetComponent<Enemy_Unit_Movement>().isUnconscious = true;
            target.GetComponent<Enemy_Unit_Movement>().TakeDamage(damage);
            Destroy(gameObject);
        }

        else
        {
            target.GetComponent<Enemy_Unit_Movement>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
