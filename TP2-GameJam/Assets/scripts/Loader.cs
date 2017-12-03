using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {


    public GameObject gameManager;



    private void Awake()
    {
        if (GameManagerUn.instance == null)
            Instantiate(gameManager);

    }
    
}
