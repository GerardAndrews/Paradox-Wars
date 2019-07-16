using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eProjectile : MonoBehaviour
{

    //Speed will vary based on the unit
    public float speed;
    public Transform target;
    public float damage;
    //AudioSource Attack;
    // Use this for initialization
    void Start()
    {
        //Attack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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
            HitEnemy();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            //Attack.Play(0);
        }
    }

    void HitEnemy()
    {
        int chance = Random.Range(0, 100);
        if (chance <= 15)
        {
            target.GetComponent<Unit>().isUnconscious = true;
            target.GetComponent<Unit>().TakeDamage(damage);
            Destroy(gameObject);
        }

        else
        {
            target.GetComponent<Unit>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
