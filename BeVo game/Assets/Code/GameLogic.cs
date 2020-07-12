using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum GameMode{
        Light,
        NeverHaveIEver,
        XXX
    }

    [SerializeField]
    List<string> players = new List<string>();

    ChallengeGenerator challengeGenerator;

    private void Start()
    {
        challengeGenerator = transform.GetComponent<ChallengeGenerator>();
    }
    
    public void GenerateChallenge(string gameMode)
    {
        Debug.Log("challenge accepted");

        challengeGenerator.GenerateChallenge(players[Random.Range(0,players.Count)], "5");
    }

    public string Dothething()
    {
        Debug.Log("pizzicatto");
        return "pizzicatto";
    }

}
