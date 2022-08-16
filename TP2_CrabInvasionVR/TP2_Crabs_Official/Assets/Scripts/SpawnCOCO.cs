using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCOCO : MonoBehaviour
{
    //Initialisation de la variable GameObject en public
  public GameObject COCO;

 // On Trigger Enter si le tag qui rentre dans la collision se nomme Player, on d�sactive le kinematic de l'objet attribu�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            COCO.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
