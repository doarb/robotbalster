using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void TakeDamage()
    {
        if (KillCounter.instance != null)
        {
            KillCounter.instance.AddKill();
        }
        Destroy(gameObject); // Détruit l'objet quand il est touché
    }
}
