using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager manager;
    public int score = 0;
    public float jumpPower;
    bool isJump;

    AudioSource sound;
    Rigidbody rigid;

    // Start is called before the first frame update
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
        isJump = false;
    }

    private void Update() {
        if (!isJump && Input.GetButtonDown("Jump")) {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isJump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        Vector3 vec = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );

        rigid.AddForce(vec, ForceMode.Impulse);  // 힘주기

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Floor")
            isJump = false;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            score++;
            sound.Play();
            manager.GetItem(score);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Finish") {
            if (score == manager.totalItemCount) {
                // Next Level
                SceneManager.LoadScene("Level-" + (manager.stage + 1));
            }
            else {
                // Restart
                SceneManager.LoadScene("Level-" + manager.stage);
            }
        }
    }
}
