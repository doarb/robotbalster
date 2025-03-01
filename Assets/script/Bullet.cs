using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // V�rifie si on touche un ennemi
        {

            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                
                enemyHealth.TakeDamage(); // Applique les d�g�ts
            }
            Destroy(gameObject); // D�truit la balle apr�s l'impact
        }
        Debug.Log("Collision");

    }
}
