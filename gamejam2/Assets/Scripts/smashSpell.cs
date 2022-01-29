using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smashSpell : MonoBehaviour
{
    public GameObject smashSpellPrefabs;
    public bool ifCastSmash = true;
    public GameObject enemy;
    public int spawnTimes = 1;
    public int spawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawnSmash());
    }

    // Update is called once per frame
    void Update()
    {
        spawnSmash();
    }

    void spawnSmash()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 spawnLocation = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 10f, enemy.transform.position.z);
            Instantiate(smashSpellPrefabs, spawnLocation, Quaternion.identity);
            spawned++;
            Debug.Log(spawned);
            //yield return new WaitForSeconds(10.0f);
            
        }
    }

    public void restSmash() {
        spawned = 0;
    }
}
