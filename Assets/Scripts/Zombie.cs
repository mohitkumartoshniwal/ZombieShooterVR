using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    [Header("Zombie Health and Damage")]
    float damageOutput = 5f;


    [Header("Zombie Things")]
    public NavMeshAgent zombieAgent;
    public LayerMask playerLayer;
    public Transform LookPoint;
    public Transform playerBody;
    public Camera AttackingRayCastArea;

    [Header("Zombie Things")]
    public GameObject[] walkPoints;
    int currentZombiePosition = 0;
    [SerializeField]
    float zombieSpeed;
    [SerializeField]
    float walkingPointRadius = 2;

    [Header("Zombie Animation")]
    public Animator anim;

    [Header("Zombie Mood/Stages")]
    [SerializeField]
    float visionRadius;
    [SerializeField]
    float attackingRadius;
    bool isPlayerInVisionRadius;
    bool isPlayerInAttackingRadius;

    [Header("Zombie Attacking Var")]
    public float timeBetweenAttack;
    bool isPreviouslyAttacked;

    private void Awake()
    {
        zombieAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        isPlayerInVisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        isPlayerInAttackingRadius = Physics.CheckSphere(transform.position, attackingRadius, playerLayer);
        
        if(!isPlayerInVisionRadius  && !isPlayerInAttackingRadius)
        {
            Guard();
        }else if (isPlayerInVisionRadius && !isPlayerInAttackingRadius)
        {
            PursuePlayer();

        }else if(isPlayerInVisionRadius && isPlayerInAttackingRadius)
        {
            AttackPlayer();
        }
    }

    private void Guard()
    {
        if (Vector3.Distance(walkPoints[currentZombiePosition].transform.position, transform.position) < walkingPointRadius)
        {
            currentZombiePosition = Random.Range(0, walkPoints.Length);
            if(currentZombiePosition >= walkPoints.Length)
            {
                currentZombiePosition = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentZombiePosition].transform.position, Time.deltaTime * zombieSpeed);
        // change facing ??
        transform.LookAt(walkPoints[currentZombiePosition].transform.position);
    }

    private void PursuePlayer()
    {
        if(zombieAgent.SetDestination(playerBody.position))
        {
            anim.SetBool("Running", true);
            anim.SetBool("Walking", false);
            // are the below rqeuired??
            anim.SetBool("Attacking", false);
            anim.SetBool("Died", false);

        }
        else
        {
            anim.SetBool("Running", false);
            anim.SetBool("Walking", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Died", true);
        }
    }

    private void AttackPlayer()
    {
        zombieAgent.SetDestination(playerBody.position);
        transform.LookAt(LookPoint);
        if (!isPreviouslyAttacked)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(AttackingRayCastArea.transform.position, AttackingRayCastArea.transform.forward,out hitInfo, attackingRadius))
            {
                anim.SetBool("Running", false);
                anim.SetBool("Walking", false);
                anim.SetBool("Attacking", true);
                anim.SetBool("Died", false);

            }
            isPreviouslyAttacked = true;
            Invoke(nameof(ActiveAttacking), timeBetweenAttack);
        }
    }

    private void ActiveAttacking()
    {
        isPreviouslyAttacked = false;
    }

}


