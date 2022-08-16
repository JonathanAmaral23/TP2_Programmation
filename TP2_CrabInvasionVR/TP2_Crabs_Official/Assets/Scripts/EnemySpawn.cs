using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //initiation d'une variable enemies, position X, postition Y et nombre d'ennemies
    public GameObject enemies;
    public int xPos;
    public int zPos;
    public int enemyCount;

    //initialisation de variables x, y et z qui sert de point central relatif autour duquel les crabes vont apparaitre
    public int relativeX;
    public int relativeZ;
    public int relativeY;

    //temps entre chaque apparition de crabe
    public float SpawnTime;

    void Start()
    {

        //Initiation d'une coroutine qui reprend tant que la condition de l'enumerator Enemy drop n'est pas remplie

        StartCoroutine(EnemyDrop());

    }

    //Enumerator enemyDrop, Tant que enemyCount est plus petit que 10, le enumerator creer des instances du game object store dans enemies dans un range random de 2 vecteurs
    //3. de 4 a 18 et de 1 a 13. le enumerator yield un retour defini par la variable SpawnTime puis incremente le enemy count.
    IEnumerator EnemyDrop()
    {
        //Tant que le nombre d'ennemis est inférieur à 10
        while (enemyCount < 10)
        {

            //trouve une valeur aleatoire pour la position x et y
            xPos = Random.Range(10, 35);
            zPos = Random.Range(15, 45);

            //instancie un ennemi qui apparaitra au coordonnees dicter par les variables aleatoires et les variables de position relatives
            Instantiate(enemies, new Vector3((relativeX + xPos), relativeY, (relativeZ + zPos)), Quaternion.Euler(0, 0, 0));
            //attendre le nombre de seconde defini dans SpawnTime
            yield return new WaitForSeconds(SpawnTime);
            //incrementation du nombre d'ennemis
            enemyCount += 1;

        }
    }

}
