using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float attackRange;
    public float followRange;
    public bool alwaysFollow;
    private NavMeshAgent agent;
    public GameObject target;
    public AudioSource enemysound;
    [Header("Patrol")]
    public Transform[] points;
    private int desPoint = 0;
    public int point = 5;
    public Transform shootPoint;
    public GameObject Bullet;
    public float shootForce;
    public Animator model;
    bool walk;
    bool attack;
    bool attack2;

    private int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        death();
        SearchEnemy();
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
            model.Play("Walk");
        }
    }
    private void GotoNextPoint()
    {
        if (points.Length == 0)

            return;
        agent.destination = points[desPoint].position;
        desPoint = (desPoint + 1) % points.Length;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            life--;
        }
    }
    public void death() 
    {
        if(life < 0)
        {
            Destroy(gameObject);
        }
    }
    public void Shoot()
    {
        Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
        enemysound.Play();
    }
    private void SearchEnemy()
    {
        RaycastHit hit;
        Vector3 direction = target.transform.position - transform.position;

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.CompareTag("Player") && hit.distance <= 15f)
            {
                
                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 7f;
                transform.LookAt(target.transform.position);
                if (walk)
                {
                    model.Play("Walking");
                }
                if (hit.distance <= 7f && hit.distance > 5f)
                {
                    walk = false;
                    attack2 = false;
                    attack = true;
                    Shoot();
                    if (attack)
                    model.Play("Attack2");
                    
                }
                else if (hit.distance < 7f)
                {
                    attack = false;
                    walk = false;
                    attack2 = true;
                    Shoot();
                    if (attack2)
                    model.Play("Attack");
                } else if (hit.distance > 7f)
                {
                    walk = true;
                    attack = false; 
                    attack2 = true;
                }
            }
            else
            {
                agent.stoppingDistance = 3f;
            }
        }
    }
}
