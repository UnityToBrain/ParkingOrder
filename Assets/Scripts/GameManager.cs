using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public int countTracks,numberOfMoves;
    public bool victorybool, losebool;
    void Start()
    {
        if (gameManagerInstance == null)
            gameManagerInstance = this;

        countTracks = GameObject.FindGameObjectsWithTag("path").Length;

        numberOfMoves = countTracks + 5;

    }

    public void Victory()
    {
        if (countTracks.Equals(0) && !losebool)
        {
            victorybool = true;
            Debug.Log("You Win!");
        }
    }

    public void Lose()
    {
        if (losebool | numberOfMoves.Equals(0) && !victorybool)
        {
            Debug.Log("You Lose!");
        }
    }
}
