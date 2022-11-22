using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator animator;

    private GameObject target;
    public float attackRange = 1.8f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldMove = !animator.GetBool("Dying") && Vector3.Distance(transform.position, target.transform.position) > attackRange;
        animator.SetBool("Moving", shouldMove);
        animator.SetBool("Attacking", !shouldMove);
        agent.destination = shouldMove ? target.transform.position : transform.position;
    }
    
    private void OnAnimatorMove()
    {
        transform.position = agent.nextPosition;
    }
    
    public void Kill()
    {
        animator.SetBool("Dying", true);
        Destroy(gameObject, 4f);
    }
}
