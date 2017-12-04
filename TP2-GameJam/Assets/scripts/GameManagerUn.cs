using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerUn : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public int vie = 3;
    public int pointsJoueur = 0;
    public static GameManagerUn instance = null;
    public BoardManager boardScript;
    private bool doingSetup = true;                         //Boolean to check if we're setting up board, prevent Player from moving during setup.
    public Vector3 positionCible;

    private int level = 1;
    // Use this for initialization
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
        if(GestionLevel.level < 5)
        {
            DontDestroyOnLoad(gameObject);
        }
        
        boardScript = GetComponent<BoardManager>();
        //InitGame();
        positionCible = boardScript.positionCible;


    }

    void InitGame()
    {

        doingSetup = true;

        boardScript.SetupScene(level);

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        
    }*/

    private void OnLevelWasLoaded(int index)
    {
        level++;
		GestionLevel.touchable = true;
		GestionLevel.marquer = false;
		InitGame();
    }

   

    public void GameOver()
    {

        enabled = false;
    }


}
