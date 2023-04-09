using UnityEngine;
using UnityEngine.AI;

namespace EnemyScripts
{
    public class EnemyNavMeshController : MonoBehaviour
    {
        public Transform player;

        private NavMeshAgent agent;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            agent.SetDestination(player.position);
        }
    }
}
