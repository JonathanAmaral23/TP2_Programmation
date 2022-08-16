using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleEnergy : MonoBehaviour
{
    // initialisation des variables d'energie du chateau
    public float hp;
    //variable statique, que les crabes utilisent pour connaitre le nombre de point de vie du chateau
    public static float Energy;
    //variables qui representent le nombre maximum et minimum d'energie
    public int MaxEnergy = 50;
    public const int MinEnergy = 1;
    //booleen de dommage qui active le dommage par seconde au chateau
    //private bool domm;

    //variable de Rendering pour pouvoir faire disparaitre le chateau sans le detruire
    public Renderer rend;

    void Start()
    {
        //le booleen de dommage est a faux au commencement de la partie
        //domm = false;
        //la variable rend est connecter au component renderer
        rend = GetComponent<Renderer>();
        //le chateau est rendered des le depart
        rend.enabled = true;
        //l'energie du chateau est egale a l'energie maximale definie plus haut
        Energy = MaxEnergy;
    }

    void Update()
    {
        //La variable hp est toujours egale a l'energie et sert uniquement a etre vu dans l'inspecteur
        hp = Energy;
        //si l'energie descend en bas de l'energie minimum, le chateau devient invisible
        if (Energy < MinEnergy)
        {
            rend.enabled = false;
        }
    }

    //Quand il recoit le message ondamage, il recoit un nombre de dommage par frame pour chaque crabe qui envoit le message
   private void OnDamage(float damge)
    {
        Energy = Energy - damge;
        //Si le chateau n'a plus d'energie, il devient invisible
        if (Energy < MinEnergy)
        {
            rend.enabled = false;
        }
    }


}