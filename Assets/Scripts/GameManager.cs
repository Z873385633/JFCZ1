using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    private Transform startPoint;
    private Transform spawnPoint;
    private Pin currentPin;
    public GameObject pinPrefab;
    private bool isGameOver = false;
    private int score = 0;
    public Text scoreText;

	// Use this for initialization
	void Start () {

        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        SpawnPin();
    }
	
	// Update is called once per frame
	 public void Update () {
        if (isGameOver) return;
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            scoreText.text =score.ToString();
            currentPin.StartFly();
            SpawnPin();
        }

	}
    void SpawnPin()
    {
    currentPin=GameObject.Instantiate(pinPrefab,spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    public void GameOver()
    {
        if (isGameOver) return;
        GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;
        isGameOver = true;
    }
}
