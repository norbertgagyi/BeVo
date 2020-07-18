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
    private List<string> players = new List<string>();

    private ChallengeGenerator challengeGenerator;

    private Transform screensParent;

    [SerializeField]
    private List<GameObject> screens = new List<GameObject>();
    private GameObject currentScreen;

    private GameObject previousScreen = null;

    private void Start()
    {
        challengeGenerator = transform.GetComponent<ChallengeGenerator>();

        GetScreens();

        if(screens.Count != 0)
        {
            currentScreen = screens[0];
        }
    }

    private void GetScreens()
    {
        screensParent = GameObject.Find("Canvas").transform;

        if(screensParent != null)
        {
            foreach(Transform screen in screensParent)
            {
                if(screen != null)
                {
                    screens.Add(screen.gameObject);
                }
            }
        }
    }

    public void SwitchScreen(int index)
    {
        if(screens.Count != 0)
        {
            if(screens[index] != null)
            {
                previousScreen = currentScreen; //set here before currentScreen is assigned to
                previousScreen.SetActive(false);
                
                currentScreen = screens[index];
                currentScreen.SetActive(true);
            }
        }
    }
    
    private void GenerateChallenge(string gameMode)
    {
        Debug.Log("challenge accepted");

        challengeGenerator.GenerateChallenge(players[Random.Range(0,players.Count)], "5");
    }

}
