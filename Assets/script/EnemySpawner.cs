using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi
    public Transform spawnPoint; // Point où l'ennemi va apparaître
    public float spawnInterval = 10.0f; // Temps entre chaque apparition
    

    void Start()
    {
        // Trouve un spawnPoint automatiquement si non assigné
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.Find("SpawnPoint").transform;
        }

        if (spawnPoint != null && enemyPrefab != null)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // Boucle infinie
        {
            if(KillCounter.instance != null)
            {
                if (KillCounter.instance.GetKillCount() < 100)
                {
                    yield return new WaitForSeconds(spawnInterval);
                    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                }
            }
           
        }
    }
}
