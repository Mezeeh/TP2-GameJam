using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class BoardManager : MonoBehaviour {

    [Serializable]

    public class Count
    {
        public int maximum;
        public int minimum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns;
    public int rows;
    public Count coneCount = new Count(3, 5);

    public Count adversairesCount = new Count(2, 3);
    public GameObject terrain;
    public GameObject but;
    public GameObject cone;
    public GameObject adversaires;
    GameObject cible;
    Vector3 positionCible;
    //public GameObject[] floorTitles;
    //public GameObject[] murDeCone;
    //public GameObject[] outerWallTitles;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        
        gridPositions.Clear();

        for(float x = -2.73f; x < columns - 1; x++)
        {
            for(float y = -1.86f; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        GameObject instance = Instantiate(terrain, new Vector3(0, 0, 0f), Quaternion.identity);
        instance.transform.SetParent(boardHolder);

        /*for(int x = -1; x < columns + 1; x++)
        {
            for(int y = -1; y < rows + 1; y++)
            {
               // GameObject toInstantiate = floorTitles[Random.Range(0, floorTitles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    //toInstantiate = outerWallTitles[Random.Range(0, outerWallTitles.Length)];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0f),Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);

            }
        }*/


    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;


    }

    void LayoutObjectAtRandom(GameObject objetSpawn, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            
            cible = Instantiate(objetSpawn, randomPosition, Quaternion.identity);
            if(objetSpawn == adversaires)
            {
                positionCible = cible.transform.position;
            }
            
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(cone, coneCount.minimum, coneCount.maximum);
        LayoutObjectAtRandom(adversaires, adversairesCount.minimum, adversairesCount.maximum);
        Instantiate(but, new Vector3(4.377f,-0.036f,0f), Quaternion.identity);
    }


        





	
}
