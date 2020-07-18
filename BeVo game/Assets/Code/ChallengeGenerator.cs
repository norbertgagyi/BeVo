using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChallengeGenerator : MonoBehaviour
{

    //INDEXES: 1 - light, 2 - would you rather, 3 - never have i ever, 4 - xxx

    private char csvLineSeparator = '\n';

    public TextAsset csvFileLight;
    public TextAsset csvFileWYR;
    public TextAsset csvFileNHIE;
    public TextAsset csvFileXXX;

    public List<TextAsset> csvFiles = new List<TextAsset>();

    public string[] records;

    [SerializeField]
    public List<string> formattedChallenges = new List<string>();

    private void Start()
    {
        if (csvFileLight != null)
            ReadData();
    }

    private void ReadData()
    {
        if (csvFileLight.bytes.Length > 0)
            records = csvFileLight.text.Split(csvLineSeparator);
    }

    private string FormatChallenge(string challenge, string playerName, string playerName2)
    {
        if (challenge.Length > 0)
        {
            return string.Format(challenge, playerName, playerName2);
        }

        return null;
    }

    public string GenerateChallenge(string playerName, string playerName2)
    {
        if (records.Length > 0)
        {
            string selectedChallenge = records[Random.Range(0, records.Length)];

            string formattedChallenge = FormatChallenge(selectedChallenge, playerName, playerName2);

            formattedChallenges.Add(formattedChallenge);

            return formattedChallenge;
        }

        return null;
    }
}
