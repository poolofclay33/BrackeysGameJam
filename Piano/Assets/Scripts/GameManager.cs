using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public AudioSource theMusic;

    public bool startPlaying;

    public Notes _but;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public TMP_Text _scoreTxt;
    public TMP_Text _multiTxt;

    public int currentMulti;
    public int multiTracker;
    public int[] multiThreshold;

	// Use this for initialization
	void Start () {
        instance = this;

        _scoreTxt.text = "Score: 0";
        currentMulti = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                _but.hasStarted = true;

                theMusic.Play();
            }
        }
	}

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMulti - 1 < multiThreshold.Length)
        {
            multiTracker++;

            if (multiThreshold[currentMulti - 1] <= multiTracker)
            {
                multiTracker = 0;
                currentMulti++;
            }
        }

        _multiTxt.text = "Multiplier: x" + currentMulti;

        currentScore += scorePerNote * currentMulti;
        _scoreTxt.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log(":(");

        currentMulti = 1;
        multiTracker = 0;
        _multiTxt.text = "Multiplier: x" + currentMulti;
    }
}
