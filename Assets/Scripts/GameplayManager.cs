using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {

    public Text question;
    public Transform answerArea;
    public GameObject buttonAnswer;

	void Start () {
        question.text = "Esto es una prueba para modificar el texto de la pregunta";
        cleanAnswerArea();
        fillAnswerArea();
	}

    private void fillAnswerArea() {
        float height = -100;
        for (int i = 0; i < 10; i++) {
            GameObject newButton = Instantiate(buttonAnswer);
            newButton.transform.parent = answerArea;

            newButton.GetComponent<RectTransform>().anchorMin= new Vector2(0, 1);
            newButton.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            newButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            newButton.GetComponent<RectTransform>().offsetMin = new Vector2(100, 0);
            newButton.GetComponent<RectTransform>().offsetMax = new Vector2(-100, 100);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
            newButton.GetComponent<Image>().enabled = true;
            newButton.GetComponent<Button>().enabled = true;
            
            newButton.GetComponentInChildren<Text>().text = "Esto es un botón de prueba";
            newButton.GetComponentInChildren<Text>().enabled = true;
            height -= 120;
        }
    }

    private void cleanAnswerArea() {
        foreach (Transform child in answerArea.transform) {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
