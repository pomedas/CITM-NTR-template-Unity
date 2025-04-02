using UnityEngine;
using UnityEngine.AI;
public class EnemyStats : MonoBehaviour
{
    public float health;
    public float damage;
    public float moveSpeed;

    NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Apply();
    }

    public void Apply()
    {
        navMeshAgent.speed = moveSpeed;
    }
}

