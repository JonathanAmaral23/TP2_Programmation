using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCOCO : MonoBehaviour
{
    //Initialisation de la variable GameObject en public
  public GameObject COCO;

 // On Trigger Enter si le tag qui rentre dans la collision se nomme Player, on désactive le kinematic de l'objet attribué
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            COCO.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
