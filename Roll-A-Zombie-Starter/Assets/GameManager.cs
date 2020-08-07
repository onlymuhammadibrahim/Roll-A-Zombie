using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;
    private int selectedZombiePosition = 0;
    public Text scoreText;
    private int score = 0;
    
	// Use this for initialization
	void Start () {
        SelectZombie(selectedZombie);
        scoreText.text = "Score : " + score;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("left"))
        {
            GetZombieLeft();
        }
        if (Input.GetKeyDown("right"))
        {
            GetZombieRight();   
        }
        if (Input.GetKeyDown("up"))
        {
            PushUP();
        }

    }

    void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedSize;
    }

    void GetZombieLeft()
    {
        if (selectedZombiePosition == 0)
        {
            SelectZombie(zombies[3]);
            selectedZombiePosition = 3;
        }
        else
        {
            SelectZombie(zombies[selectedZombiePosition - 1]);
            selectedZombiePosition -= 1;
        }
    }

    void GetZombieRight()
    {
        if (selectedZombiePosition == 3)
        {
            SelectZombie(zombies[0]);
            selectedZombiePosition = 0;
        }
        else
        {
            SelectZombie(zombies[selectedZombiePosition + 1]);
            selectedZombiePosition += 1;
        }
    }

    void PushUP()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10,ForceMode.Impulse);
    }

    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score : " + score;
    }

}
