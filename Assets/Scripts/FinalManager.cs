﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour {

    static OutputData outputData;
    static string WINS = " gana!!";

    public Text winnerText;

    void Start () {
        ReadWinner();
    }

    public void ReadWinner()
    {
        AssetDatabase.ImportAsset(SaveLoad.OUTPUT_PATH);

        TextAsset data = Resources.Load<TextAsset>(SaveLoad.FINAL_INPUT_PATH);
        outputData = JsonUtility.FromJson<OutputData>(data.ToString());
        string winner = outputData.winner;

        winnerText.text = winner + WINS;
    }

    void Update () {
		
	}
}
