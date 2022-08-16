using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Behavior_Crab : MonoBehaviour
{
    //intitialisation des variables

    //variable de NavMeshAgent qui represente le crabe en tant qu'agent actif
    private NavMeshAgent _agent;
    //variable d'animation
    private Animation anim;

    //vector3 qui donne la position des crabes et de la cible
    public Vector3 crab_position;
    public Vector3 target_position;
    //variables de type float du treshold et de la distance presente entre le crab et sa cible
    private float threshold;
    private float currentDistance;

    //variable contenant le nombre de dommage par frame que le crabe inflige
    public float Damage;
    //variable du rigidbody
    private Rigidbody rb;
    //variable statique venant du script CastleEnergy qui store le nombre de point de vie du chateau
    private float CastleHp = CastleEnergy.Energy;

    //point de vie du crabe
    private float CrabHP;
    //variable du maximum de point de vie du crabe
    public const float MaxHp = 2;
    //variable du minimum de point de vie du crabe
    private const float MinHp = 1;

    void Start()
    {
        //nombre de dommage du crabe par frame
        Damage = 0.002f;

        //A chaque frame la position du crabe est updater dans cette variable
        crab_position = this.transform.position;

        //La variable store le transfrm.position de l'objet s'appelant Mytarget
        target_position = GameObject.Find("MyTarget").transform.position;

        //la variable anim est lier au component animation
        anim = GetComponent<Animation>();

        //la variable _agent est lier au component NavMeshAgent
        _agent = GetComponent<NavMeshAgent>();

        //cette variable est initialiser a 4 unite, cest la distance a laquelle les crabes s'arretent pour attaquer
        threshold = 2.0f;

        //cette variable est initialiser au maximum de point de vie possible du crabe
        CrabHP = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //A chaque frame la position du crabe est updater dans cette variable
        crab_position = this.transform.position;

        //La variable store le transform.position de l'objet s'appelant Mytarget
        target_position = GameObject.Find("MyTarget").transform.position;

        //la distance entre la position du crabe et son objectif est constamment mise a jour
        currentDistance = Vector3.Distance(crab_position, target_position);

        //Etant donne que le prefab du crab est 180 degree a l'envers, cette ligne de code corrige la rotation du crabe
        this.transform.rotation = Quaternion.LookRotation(transform.position - target_position);

        //A chaque frame, la variable CastleHp va voir combien d'energie il reste au chateau en accedant a la variable statique
        CastleHp = CastleEnergy.Energy;

        //si la distance entre le crabe et son objectif est superieure a celle etablie dans threshold, le crab marche
        if (currentDistance > threshold)
        {
            Walk();
        }
        //Sinon, il regarde si le chateau a des points de vie, si le chateau est encore "vivant", il arrete d'avancer et l'attaque
        //si le chateau est deja detruit, il n'attaque plus et reste en position d'attente devant le chateau
        else
        {
            if (CastleHp > 0)
            {
                Attack();
            }
            else
            {
                Stand();
            }
        }

        //Si le crabe n'a plus de point de vie, il est detruit
        if (CrabHP < MinHp)
        {

            Destroy(this.gameObject);
        }

    }

    //dans la fonction walk, l'agent de navmesh se dirige vers sa destination en jouant l'animation walk
    private void Walk()
    {
        _agent.destination = target_position;
        anim.Play("walk");
    }

    //dans la fonction attack, l'agent de navmesh s'arrete et joue l'animation attack1
    private void Attack()
    {
        _agent.isStopped = true;
        anim.Play("attack1");
    }

    //dans la fonction stand, l'agent de navmesh s'arrete et joue l'animation stand
    private void Stand()
    {
        _agent.isStopped = true;
        anim.Play("stand");
    }

    //Lorsqu'il entre en collision avec un objet dont le tag est weapon, le crabe perd 1 point de vie
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("weapon"))
        {
            CrabHP -= 1;
        }
    }

    //A chaque frame, tant qu'il est dans la zone de collision de l'objet ayant pour tag Target, il envoit un message au chateau activan les dommages par frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            other.gameObject.SendMessage("OnDamage", Damage);
        }

    }
}
