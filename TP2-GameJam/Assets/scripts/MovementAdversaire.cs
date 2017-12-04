using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAdversaire : MonoBehaviour {

    public float vitesse = 1;
    private PathFinding pathfinder;
    private Grille grille;
    private Vector3 positionCible;
    private Noeud noeudDepart, noeudArriver;
    private BoardManager manager;
    private bool aggresser;
    private int pointActuel;
    private bool reverse;
    private int derniereTuile;
    int numeroAdversaire;
    Vector3 positionDepart;
    private bool enmouvement;

    // Use this for initialization
    void Start() {

        aggresser = false;

        grille = GameObject.Find("A*").GetComponent<Grille>();
        pathfinder = GameObject.Find("A*").GetComponent<PathFinding>();

        manager = GameObject.Find("GameManager(Clone)").GetComponent<BoardManager>();
        reverse = false;
        numeroAdversaire = manager.nombreAdversaires;

        //SetRoute ();
        positionDepart = transform.position;




    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.transform.tag == "Hero")
        {
            aggresser = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Hero")
        {
            aggresser = false;
        }
    }



    // Update is called once per frame
    void Update()
    {



        if (aggresser)
        {
            positionCible = GameObject.Find("Hero").transform.position;
            if (transform.position != positionCible)
            {
                noeudDepart = grille.noeudVsPoint(transform.position);
                noeudArriver = grille.noeudVsPoint(positionCible);
                if (noeudArriver.walkable && noeudDepart != noeudArriver)
                {

                    pathfinder.trouverChemin(noeudDepart, noeudArriver);
                    pointActuel = 0;
                }
            }
            if (pointActuel != grille.chemin.Count)
            {
                Vector3 target = grille.chemin[pointActuel].position;
                Vector3 direction = target - transform.position;
                if (direction.magnitude < .1)
                    pointActuel++;
                else
                    transform.position = Vector3.MoveTowards(transform.position, target, vitesse * Time.deltaTime);
            }

            /*else
            {
                if (transform.position != positionCible)
                {
                    noeudDepart = grille.noeudVsPoint(transform.position);
                    noeudArriver = grille.noeudVsPoint(positionCible);
                    if (noeudArriver.walkable && noeudDepart != noeudArriver)
                    {

                        pathfinder.trouverChemin(noeudDepart, noeudArriver);
                        pointActuel = 0;
                    }
                }
                if (pointActuel != grille.chemin.Count)
                {
                    Vector3 target = grille.chemin[pointActuel].position;
                    Vector3 direction = target - transform.position;
                    if (direction.magnitude < .1)
                        pointActuel++;
                    else
                        transform.position = Vector3.MoveTowards(transform.position, target, vitesse * Time.deltaTime);


                }
            }*/


        }
    }
}
