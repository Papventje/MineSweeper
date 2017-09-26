using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartWithButton : MonoBehaviour {

    [SerializeField]
    private Button restartButton;

    void Start()
    {
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(RestartLevel);
    }

	void RestartLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
