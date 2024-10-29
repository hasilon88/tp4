using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    private Animator animator;
    //public Text enterMaze;
    public float timeRemaining = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("CanClose", true);

        GameObject textObject = GameObject.Find("EnterMaze");
        //enterMaze = textObject.GetComponent<Text>();
    
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            //enterMaze.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            animator.SetBool("CanClose", false);
            //enterMaze.text = "Bienvenu, remplissez votre mission !";
            Debug.Log("Player has entered the trigger zone!");
        }
    }
}
