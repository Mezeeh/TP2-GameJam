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
    //private int derniereTuile;
    int numeroAdversaire;
    public Vector3 positionDepart;
    //private bool enmouvement;
    bool retourAttaque;
    public Noeud noeudAvantAttaque;
    public Vector3 posAvantAttaque;
    public Noeud noeudDestination;
    bool premiereFois;
    bool enChemin;
    // Use this for initialization
    void Start() {

        enChemin = true;
        aggresser = false;
        retourAttaque = false;
        grille = GameObject.Find("A*").GetComponent<Grille>();
        pathfinder = GameObject.Find("A*").GetComponent<PathFinding>();

        manager = GameObject.Find("GameManager(Clone)").GetComponent<BoardManager>();
        reverse = false;
        numeroAdversaire = manager.nombreAdversaires;

        //SetRoute ();
        positionDepart = transform.position;
        premiereFois = true;



    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.transform.tag == "Hero")
        {
            aggresser = true;
            retourAttaque = false;
            premiereFois = true;
            enChemin = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Hero")
        {
            aggresser = false;
            retourAttaque = true;
            enChemin = true;

            //Debug.Log(aggresser.ToString() + retourAttaque.ToString() + enChemin.ToString());
            
        }
    }



    // Update is called once per frame
    void Update()
    {



        if (aggresser)/************************************************************************/
        {
            /*if(premiereFois)
            {
                noeudAvantAttaque = grille.noeudVsPoint(transform.position);
                posAvantAttaque = transform.position;
                premiereFois = false;
            }*/
            
                
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

            /********************************************************/
            
        }

        /*if (!aggresser && !enChemin && retourAttaque) /***************************************************************************
        {
            positionCible = posAvantAttaque;
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
                        

        
        /*if (enChemin && !aggresser && !retourAttaque)/***************************************************************************
        {
            positionCible = manager.positionsTabs[numeroAdversaire - 1];
            if (transform.position != positionCible)
            {
                noeudDepart = grille.noeudVsPoint(transform.position);
                noeudArriver = grille.noeudVsPoint(manager.positionsTabs[numeroAdversaire -1 ]);
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
