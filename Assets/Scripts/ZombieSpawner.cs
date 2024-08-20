using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject zombie;
    public ZombieTypeProp[] zombieTypes;
    public List<ZombieType> propList = new List<ZombieType>();

    public int zombieMax;
    public int zombiesSpawned;
    private int zombiesRemaining;
    public float zombieDelay = 5;
    public Slider progressBar;

    private void Start() {
        InvokeRepeating("SpawnZombie", 10, zombieDelay);  

        foreach(ZombieTypeProp zom in zombieTypes) {
            for (int i = 0; i < zom.probability; i++) {
                propList.Add(zom.type);
            }
        }

        progressBar.maxValue = zombieMax;
        zombiesRemaining = zombieMax;
    }

    private void Update() {
        progressBar.value = zombieMax - zombiesRemaining;
    }

    void SpawnZombie() {
        if (zombiesSpawned >= zombieMax) {
            return;
        }
        zombiesSpawned++;
        int r = Random.Range(0, spawnpoints.Length);
        GameObject myZombie = Instantiate(zombie, spawnpoints[r].position, Quaternion.identity);
        myZombie.GetComponent<Zombie>().type = propList[Random.Range(0, propList.Count)];

        zombiesRemaining--;
    }
}

[System.Serializable]
public class ZombieTypeProp {
    public ZombieType type;
    public float probability;
}