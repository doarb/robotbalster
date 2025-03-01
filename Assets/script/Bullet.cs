using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Vérifie si on touche un ennemi
        {

            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                
                enemyHealth.TakeDamage(); // Applique les dégâts
            }
            Destroy(gameObject); // Détruit la balle après l'impact
        }
        Debug.Log("Collision");

    }
}
