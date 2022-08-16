using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Initialisation des variables de type Rigidbody
    private Rigidbody rb;
    //initialisation de 2 variables de type vector3
    public Vector3 startPosition;
    public Vector3 currentPosition;
    //Initialisation de la variable deathswitch de type booleen
    public bool deathswitch;


    void Start()
    {
        // On prend la position du gameObject associé et on l'attribue a une variable
        startPosition = GetComponent<Transform>().position;
        //print la position du gameObject associé dans la console
        Debug.Log($"{startPosition}");
        //la variable deathswitch est initialiser a false
        deathswitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Prend la position du gameObject a chaque frame et stock la valeur dans la variable currentPosition
        currentPosition = GetComponent<Transform>().position;
        //Si deathswitch est vrai, le gameObject retrouve sa position initial par la variable startPosition
        if (deathswitch == true)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // si il y a une collision avec un objet ayant le tag water, deathswitch devien true
        if (other.gameObject.CompareTag("Water"))
        {
            //Affiche un string dans la console is la condition est remplie
            Debug.Log("contact");
            //le joueur va respawn a son dernier checkpoint
            deathswitch = true;
        }
    }


    private void Respawn()
    {
        //accède au propriété (position) du gameObject et transforme sa position selon la valeur de la variable startPosition
        this.transform.position = startPosition;
        //La variable deathswitch devien false
        deathswitch = false;

    }
    
}