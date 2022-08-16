using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightTrigger : MonoBehaviour
{
    //Initialisation de la variable thisLight de type GameObject
    public GameObject thisLight;
    //Initialisation de la variable saLumiere de type GameObject (Light)
    public Light salumiere;
    //Initialisation de la variable maswitch de type booleen
    private bool maswitch;

    //Au commencement de la partie
    private void Start()
    {
        //On connecte le GetComponent<Light>() à la variable saLumiere
        salumiere = GetComponent<Light>();
        //La variable maswitch est initialisée a false
        maswitch = false;
    
    }

    private void Update()
    {
        //A chaque frame, on vérifie la condition de la variable maswitch et selon sa condition, la variable salumière devien true ou false
        if (maswitch == true)
        {
            salumiere.enabled = true;
        }
        else
        {
            salumiere.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // À chaque trigger enter, si la condition est remplie, la variable maswitch devien true
        if (other.gameObject.CompareTag("Player"))
        {
            maswitch = true;
            //affiche a la console un string
            Debug.Log("contactLumiere!");
        }
    }
    // Quand le joueur quiite la zone de collision, la variable maswitch devient false
    private void OnTriggerExit(Collider other)
    {
        maswitch = false;
    }

}