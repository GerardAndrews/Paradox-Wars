using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject slingerPrefab;
    public GameObject spearmanPrefab;
    public GameObject chariotPrefab;
    public GameObject knightPrefab;
    public GameObject horseArcherPrefab;
    public GameObject swordsmanPrefab;
    public GameObject ninjaBoxPrefab;
    public GameObject turncoatGiantPrefab;
    public GameObject musketmanPrefab;
    public GameObject grenadierPrefab;
    public GameObject PU3Prefab;
    public GameObject PU4Prefab;
    GameObject Base;
    GameObject other;


	// Use this for initialization
	void Start () {
        other = GameObject.FindGameObjectWithTag("GameController");
        Base = GameObject.FindWithTag("PBase");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnSlinger()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 9f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(slingerPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 5f;
            }
            else
            {
                GameObject UnitGO = Instantiate(slingerPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 10f;
            }
        }
    }

    public void SpawnSpearman()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 14f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(spearmanPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 7.5f;
            }
            else
            {
                GameObject UnitGO = Instantiate(spearmanPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 15f;
            }
        }
    }

    public void SpawnChariot()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 19f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(chariotPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 10f;
            }
            else
            {
                GameObject UnitGO = Instantiate(chariotPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 20f;
            }
        }
    }

    public void SpawnKnight()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 49f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(knightPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 25f;
            }
            else
            {
                GameObject UnitGO = Instantiate(knightPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 50f;
            }
        }
    }

    public void SpawnSwordsman()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 29f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(swordsmanPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 15f;
            }

            else
            {
                GameObject UnitGO = Instantiate(swordsmanPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 30f;
            }
        }
    }

    public void SpawnHorseArcher()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 34f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(horseArcherPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 17.5f;
            }

            else
            {
                GameObject UnitGO = Instantiate(horseArcherPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 35f;
            }
        }
    }

    public void SpawnNinjaBox()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 39f)
        {
            return;
        }
        else
        {
            if (other.gameObject.GetComponent<Policies>().conscription == true)
            {
                GameObject UnitGO = Instantiate(ninjaBoxPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 20f;
            }

            else
            {
                GameObject UnitGO = Instantiate(ninjaBoxPrefab, Base.transform.position, Base.transform.rotation);
                other.gameObject.GetComponent<GameController>().money -= 40f;
            }
        }
    }

    public void SpawnTurncoatGiant()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 44f || other.gameObject.GetComponent<GameController>().pOWS <= 4)
        {
            return;
        }
        else
        {
            GameObject UnitGO = Instantiate(turncoatGiantPrefab, Base.transform.position, Base.transform.rotation);
            other.gameObject.GetComponent<GameController>().money -= 45f;
            other.gameObject.GetComponent<GameController>().pOWS -= 5;
        }
    }

    public void SpawnMusketman()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 59f)
        {
            return;
        }
        else
        {
            GameObject UnitGO = Instantiate(musketmanPrefab, Base.transform.position, Base.transform.rotation);
            other.gameObject.GetComponent<GameController>().money -= 60f;
        }
    }

    public void SpawnGrenadier()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 79f)
        {
            return;
        }
        else
        {
            GameObject UnitGO = Instantiate(grenadierPrefab, Base.transform.position, Base.transform.rotation);
            other.gameObject.GetComponent<GameController>().money -= 80f;
        }
    }

    public void SpawnPU3()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 74f)
        {
            return;
        }
        else
        {
            GameObject UnitGO = Instantiate(PU3Prefab, Base.transform.position, Base.transform.rotation);
            other.gameObject.GetComponent<GameController>().money -= 75f;
        }
    }

    public void SpawnPU4()
    {
        if (other.gameObject.GetComponent<GameController>().money <= 69f)
        {
            return;
        }
        else
        {
            GameObject UnitGO = Instantiate(PU4Prefab, Base.transform.position, Base.transform.rotation);
            other.gameObject.GetComponent<GameController>().money -= 70f;
        }
    }
}
