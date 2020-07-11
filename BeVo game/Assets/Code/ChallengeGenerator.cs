using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChallengeGenerator : MonoBehaviour
{
    private char csvLineSeparator = '\n';

    [SerializeField]
    private TextAsset csvFileLight;

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

    public string FormatChallenge(string challenge, string playerName, string numberOfSips)
    {
        if (challenge.Length > 0)
        {
            return string.Format(challenge, playerName, numberOfSips);
        }

        return null;
    }

    public string GenerateChallenge(string playerName, string numberOfSips)
    {
        if (records.Length > 0)
        {
            string selectedChallenge = records[Random.Range(0, records.Length)];

            string formattedChallenge = FormatChallenge(selectedChallenge, playerName, numberOfSips);
            formattedChallenges.Add(formattedChallenge);

            return formattedChallenge;
        }

        return null;
    }
}
