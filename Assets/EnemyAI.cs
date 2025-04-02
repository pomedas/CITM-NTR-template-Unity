using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    Health healthPlayer; 
    NavMeshAgent agent;
    EnemyStats enemyStats;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<ThirdPersonController>().gameObject;
        healthPlayer = player.GetComponent<Health>();
        enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        if (player != null)
            agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            healthPlayer.TakeDamage(enemyStats.damage);
        }
    }

}

