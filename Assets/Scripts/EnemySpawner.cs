using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnerLeft, spawnerRight;
    public bool highLeftChance = false;
    public GameObject enemyPrefab;
    [SerializeField, Min(2)]
    int maxEnemyCount = 8;

    [SerializeField, Min(2f)]
    float spawnTime = 4.5f, enemySpeed = 7f;
    private float currentTimer = 0f;
    public GameObject[] enemies;

    void Update(){
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length < maxEnemyCount){
            currentTimer += Time.deltaTime;
        }
        
        if (currentTimer >= spawnTime){
            currentTimer = 0;
            if (!highLeftChance){
                int rand = Random.Range(0,2);
                if (rand == 0){
                    Instantiate(enemyPrefab, spawnerLeft.position, Quaternion.identity).GetComponent<EnemyManager>().speed = enemySpeed;
                }
                else Instantiate(enemyPrefab, spawnerRight.position, Quaternion.identity).GetComponent<EnemyManager>().speed = enemySpeed;
            }
            else{
                int rand = Random.Range(0,11);
                if (rand <= 7){
                    Instantiate(enemyPrefab, spawnerLeft.position, Quaternion.identity).GetComponent<EnemyManager>().speed = enemySpeed;
                }
                else Instantiate(enemyPrefab, spawnerRight.position, Quaternion.identity).GetComponent<EnemyManager>().speed = enemySpeed;
            }
        }
    }

}
