using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    void Start() {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => buttonCallback(button));
    }

    private void buttonCallback(Button buttonPressed) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
