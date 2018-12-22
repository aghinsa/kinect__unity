using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rg;
    public float speed;
    public int score;
    public Text scoreText;
	// Use this for initialization
	void Start () 
    {
        rg = GetComponent<Rigidbody>();
        score = 0;
        updateScore();
	 }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal= Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rg.AddForce(movement * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
            {
            other.gameObject.SetActive(false);
            score += 1;
            updateScore();
            }
    }
    void updateScore()
    {
        scoreText.text = "Score : " + score.ToString();


    }
}
