using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class SaveLoad
{

    public static string OUTPUT_PATH = "Assets/Resources/OutputData.txt";
    public static string INPUT_PATH = "InputData";
    public static string FINAL_INPUT_PATH = "OutputData";

    public static List<Question> Load() {
        AssetDatabase.ImportAsset(INPUT_PATH);

        TextAsset data = Resources.Load<TextAsset>(INPUT_PATH);
        InputData inputData = JsonUtility.FromJson<InputData>(data.ToString());
        List<Question>  questions = inputData.data;

        return questions;
    }

    public static void Save(string winner) {
        OutputData outputData = new OutputData();
        outputData.winner = winner;

        string json = JsonUtility.ToJson(outputData);

        if (json != null) {
            if (System.IO.File.Exists(OUTPUT_PATH))
            {
                System.IO.File.Delete(OUTPUT_PATH);
            }
            string path = OUTPUT_PATH;
            StreamWriter writer = new StreamWriter(path, true);
            writer.Write(json);
            writer.Close();
        }
    }
}
