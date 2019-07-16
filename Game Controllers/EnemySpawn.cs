using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject slingerPrefab;
    public GameObject spearmanPrefab;
    public GameObject chariotPrefab;
    public GameObject giantPrefab;
    public GameObject sharkPrefab;
    public GameObject btPrefab;
    public GameObject ratHeliPrefab;
    public GameObject rgPrefab;
    public GameObject reu1Prefab;
    public GameObject reu2Prefab;
    public GameObject reu3Prefab;
    public GameObject reu4Prefab;

    GameObject other;

    int index;
    GameObject Base;

    float spawnCD = 3.5f;
    public float spawnCDLeft = 2f;

    // Use this for initialization
    void Start()
    {
        Base = GameObject.FindWithTag("EBase");
        other = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //We want to spawn timer to decrease to constantly spawn
        spawnCDLeft -= Time.deltaTime;

        if (spawnCDLeft <= 0f && other.gameObject.GetComponent<GameController>().enemyPOWS <= 14)
        {
            SpawnDecision();
            spawnCDLeft = spawnCD;
        }

        if (spawnCDLeft <= 0f && other.gameObject.GetComponent<GameController>().enemyPOWS >= 15
            && other.gameObject.GetComponent<GameController>().enemyPOWS <= 34)
        {
            SpawnDecisionMedieval();
            spawnCDLeft = spawnCD;
        }

        if (spawnCDLeft <= 0f && other.gameObject.GetComponent<GameController>().enemyPOWS >= 35)
        {
            SpawnDecisionRen();
            spawnCDLeft = spawnCD;
        }
    }

    void SpawnDecision()
    {
        int randNum = Random.Range(1, 4);
        if (randNum == 1)
        {
            SpawnGiraffe();
        }
        else if (randNum == 2)
        {
            SpawnSwordArm();
        }
        else
        {
            SpawnSharkwheel();
        }
    }

    void SpawnDecisionMedieval()
    {
        int randNum = Random.Range(1, 9);
        //Debug.Log(randNum);

       if (randNum == 1)
        {
            SpawnGiraffe();
        }
        
       else if (randNum == 2)
        {
            SpawnSwordArm();
        }
       else if (randNum == 3)
        {
            SpawnSharkwheel();
        }
       else if (randNum == 4)
        {
            SpawnGiant();
        }
       else if (randNum == 5)
        {
            SpawnShark();
        }
       else if (randNum == 6)
        {
            SpawnbrainTank();
        }
        else if (randNum == 7)
        {
            SpawnRatCopter();
        }
        else
        {
            SpawnRocketGuy();
        }
    }

    void SpawnDecisionRen()
    {
        int randNum = Random.Range(1, 13);
        Debug.Log(randNum);

        if (randNum == 1)
         {
             SpawnGiraffe();
         }

        else if (randNum == 2)
        {
            SpawnSwordArm();
        }

        else if (randNum == 3)
        {
            SpawnSharkwheel();
        }

        else if (randNum == 4)
        {
            SpawnGiant();
        }

        else if (randNum == 5)
        {
            SpawnShark();
        }

        else if (randNum == 6)
        {
            SpawnbrainTank();
        }

        else if (randNum == 7)
        {
            SpawnRatCopter();
        }

        else if (randNum == 8)
        {
            SpawnRocketGuy();
        }

        else if (randNum == 9)
        {
            SpawnREU1();
        }

        else if (randNum == 10)
        {
            SpawnREU2();
        }

        else if (randNum == 11)
        {
            SpawnREU3();
        }

        else
        {
            SpawnREU4();
        }
    }

    public void SpawnGiraffe()
    {
        GameObject UnitGO = Instantiate(slingerPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnSwordArm()
    {
        GameObject UnitGO = Instantiate(spearmanPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnSharkwheel()
    {
        GameObject UnitGO = Instantiate(chariotPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnGiant()
    {
        GameObject UnitGO = Instantiate(giantPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnShark()
    {
        GameObject UnitGO = Instantiate(sharkPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnbrainTank()
    {
        GameObject UnitGO = Instantiate(btPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnRatCopter()
    {
        GameObject UnitGO = Instantiate(ratHeliPrefab, Base.transform.position, Base.transform.rotation);
    }

    public void SpawnRocketGuy()
    {
        GameObject UnitGO = Instantiate(rgPrefab, Base.transform.position, Base.transform.rotation);
    }
    public void SpawnREU1()
    {
        GameObject UnitGO = Instantiate(reu1Prefab, Base.transform.position, Base.transform.rotation);
    }
    public void SpawnREU2()
    {
        GameObject UnitGO = Instantiate(reu2Prefab, Base.transform.position, Base.transform.rotation);
    }
    public void SpawnREU3()
    {
        GameObject UnitGO = Instantiate(reu3Prefab, Base.transform.position, Base.transform.rotation);
    }
    public void SpawnREU4()
    {
        GameObject UnitGO = Instantiate(reu4Prefab, Base.transform.position, Base.transform.rotation);
    }
}
