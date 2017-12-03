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
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();


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

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        level++;
        InitGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void GameOver()
    {

        enabled = false;
    }


}
