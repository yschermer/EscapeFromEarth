using UnityEngine;
using System.Collections;


//https://www.youtube.com/watch?v=KZuqEyxYZCc
public class HighScores : MonoBehaviour {
    //Weburl
    const string privateCode = "maWvVRdrSUqxf2bFWaIurwE2wnRfUK7EiWhLX6is_2RA";
    const string publicCode = "56a1488a6e51b6185cf899fa";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;

    void Awake()
    {
        //Upload Highscores
        AddNewHighscore("Raymond", 50);
        AddNewHighscore("Ray", 40);
        AddNewHighscore("Raymond", 10);

        //Download alle highscores
        DownloadHighscores();
    }

   //UploadHighscores//////////////////////////////////////////
    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");

        }
        else
        {
            print("Error uploading: " + www.error);
        }

    }

    //Download Highscores/////////////////////////////////////
    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoreFromDatabase");
    }

    IEnumerator DownloadHighscoreFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);

        }
        else
        {
            print("Error Downloading: " + www.error);
        }

    }


    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(username, score);
            print(highscoreList[i].username + ": " + highscoreList[i].score);
        }

    }
}


public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}