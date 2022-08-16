using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelPlaySound : MonoBehaviour
{
    //Initialisation du gameObject de type AudioSource
    public AudioSource pelle;

    // La variable pelle est connectée à audioSource
    void Start()
    {
        pelle = GetComponent<AudioSource>();

    }

  

  
    //En entrant en collision, le son attribuer au gameObject s'active
    private void OnCollisionEnter(Collision collision)
    {
        pelle.Play();

    }

    //En entrant en collision de type trigger, le son attribuer au gameObject s'active
    private void OnTriggerEnter(Collider other)
    {
        pelle.Play();
    }
}
