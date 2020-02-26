using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCount;
    public Text playerCount;

    void Awake() {
        this.stageCount.text = "/ " + this.totalItemCount.ToString();
    }

    public void GetItem(int count) {
        this.playerCount.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene("Example1_" + stage);
        }    
    }

}
