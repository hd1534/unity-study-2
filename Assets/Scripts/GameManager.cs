using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text scoreText;

    private void Awake() {
        scoreText.text = " 0 / " + totalItemCount;
    }

    public void GetItem(int count) {
        scoreText.text = count + " / " + totalItemCount;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene("Level-" + stage);
        }
    }
    
}
