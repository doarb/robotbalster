using UnityEngine;
using TMPro;

public class PNJTextTrigger : MonoBehaviour
{
    public GameObject textCanvas; 
    public float activationDistance = 2.0f; 
    private Transform player;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        textCanvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < activationDistance)
            {
                textCanvas.SetActive(true);
                animator.SetBool("Talking", true);
            }
            else
            {
                textCanvas.SetActive(false);
                animator.SetBool("Talking", false);
            }
        }
    }
}
