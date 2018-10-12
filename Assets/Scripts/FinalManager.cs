using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour {

    static OutputData outputData;

    public Text winnerText;

    void Start () {
        readWinner();
    }

    public void readWinner()
    {
        AssetDatabase.ImportAsset(SaveLoad.OUTPUT_PATH);

        TextAsset data = Resources.Load<TextAsset>(SaveLoad.FINAL_INPUT_PATH);
        outputData = JsonUtility.FromJson<OutputData>(data.ToString());
        string winner = outputData.winner;

        winnerText.text = winner + " wins!!";
    }

    void Update () {
		
	}
}
