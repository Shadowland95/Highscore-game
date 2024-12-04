using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;
using System.Linq;

public class HighScoreSystem : MonoBehaviour
{
    private List<string> names = new List<string> ();
    private List<float> scores = new List<float> ();

    public int maxScores = 10;

    public Transform panel;
    public TMP_Text textPreFab;

    public static HighScoreSystem instance;
    //Example usage of singleton: HighScoreSystem.instance.NewScore(3);

    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

   

    private void Start()
    {
       HighScoreData data = JsonSaveLoad.LoadHighScore();
        if (data != null)
        {
            names = data.names.ToList();
            scores = data.scores.ToList();
        }
        RefreshScoreDisplay();

    }

    private void OnDestroy()
    {
        HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
        JsonSaveLoad.SaveHighScore(data);
    }

    private void RefreshScoreDisplay()
    {
        for(int i = panel.transform.childCount - 1; i >= 0; i--) 
        {
            Destroy(panel.GetChild(i).gameObject);
        }

        //Destroy all children
        //panel

        for(int i = 0; i < scores.Count ;i++)
        {
            //Debug.Log(names[i] + "scored: " + scores[i]);
            TMP_Text text = Instantiate(textPreFab,panel);
            text.text = names[i];

            text = Instantiate (textPreFab,panel);
            text.text = scores[i].ToString();
        }
    }

    string[] possibleNames = { "asd", "serer", "dsfdsf", "sdfsd" };
    public void NewScore(float score)
    {
        NewScore(possibleNames[Random.Range(0, possibleNames.Length)], score);
    }

    public void NewScore(string name, float score)
    {
        for(int index = 0; index < scores.Count ; index ++)
        {
            if(score < scores[index])
            {
                scores.Insert(index, score);
                names.Insert(index, name);
                RefreshScoreDisplay();
                if (scores.Count > maxScores)
                {
                    scores.RemoveAt(scores.Count - 1);
                    names.RemoveAt(names.Count - 1);
                }
                return;
            }
        }

        if (scores.Count <= maxScores)
        {
            scores.Add(score);
            names.Add(name);
            RefreshScoreDisplay();
        }
    }
}
