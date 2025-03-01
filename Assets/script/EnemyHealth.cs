using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void TakeDamage()
    {
        if (KillCounter.instance != null)
        {
            KillCounter.instance.AddKill();
        }
        Destroy(gameObject); // D�truit l'objet quand il est touch�
    }
}
