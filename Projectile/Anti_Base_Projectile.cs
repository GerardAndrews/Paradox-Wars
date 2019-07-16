using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_Base_Projectile : MonoBehaviour
{
    //Speed will vary based on the unit
    public float speed;
    public Transform target;
    public float damage;
    //AudioSource antiBaseThrow;

    // Use this for initialization
    void Start()
    {
        //antiBaseThrow = GetComponent<AudioSource>();
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
            HitTarget();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            //antiBaseThrow.Play(0);
        }
    }

    void HitTarget()
    {
        target.GetComponent<Enemy_Base>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
