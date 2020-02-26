using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audio;

    bool isJump;
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;

    void Awake() {
        this.isJump = false;
        this.rigid = GetComponent<Rigidbody>();
        this.audio = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && !isJump) {
            isJump = true;
            this.rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }


    // Update is called once per frame
    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        this.rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Floor") {
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Item") {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        } else if(other.tag == "Finish") {
            if(itemCount == manager.totalItemCount) {
                //Game Clear
                SceneManager.LoadScene("Example1_" + (manager.stage + 1).ToString());
                Debug.Log("다먹음");
            } else {
                //Restart
                SceneManager.LoadScene("Example1_" + manager.stage.ToString());
                Debug.Log("남았엉");
            }
        }
    }
}
