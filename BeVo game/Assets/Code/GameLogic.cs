using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private List<Text> challengeTextItems = new List<Text>();

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

        if (screensParent != null)
        {
            foreach (Transform screen in screensParent)
            {
                if (screen != null)
                {
                    screens.Add(screen.gameObject);
                    screen.gameObject.SetActive(false); //set them all in the first place to inactive in case some are left active by mistake
                }
            }
        }
        else return;

        screens[0].gameObject.SetActive(true); //set the first screen visible in case it's not already
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

    public void BackOneScreen()
    {
        if(screens.Count != 0)
        {
            if(previousScreen != null)
            {
                GameObject temp = currentScreen; //3 cup method

                currentScreen = previousScreen;
                currentScreen.SetActive(true);
                
                previousScreen = temp;
                previousScreen.SetActive(false);
            }
        }
    }
    
    public void GenerateChallenge(int index)
    {
        if (challengeTextItems.Count != 0)
        {
            if (challengeTextItems[index] != null)
            {
                challengeTextItems[index].text = challengeGenerator.GenerateChallenge(players[Random.Range(0, players.Count)], players[Random.Range(0, players.Count)]);
            }
        }
    }

}
