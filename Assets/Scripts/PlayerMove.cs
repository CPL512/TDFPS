using UnityEngine;
using System.Collections;

/**
 * Moves the player
 */
public class PlayerMove : MonoBehaviour {

    public float speed = 5f; //speed of player movement
    public float sensitivity = 5f; //camera sensitivity
    CharacterController player;

    public GameObject eyes;

    float moveFB;
    float moveLR;

    float rotX;
    float rotY;

    bool locked;

	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!locked) //only move and look when input not locked
        {
            moveFB = Input.GetAxis("Vertical") * speed; //get forward back motion
            moveLR = Input.GetAxis("Horizontal") * speed; //get left right motion

            rotX = Input.GetAxis("Mouse X") * sensitivity; //get x axis rotation
            rotY = Input.GetAxis("Mouse Y") * sensitivity; //get y axis rotation

            Vector3 movement = new Vector3(moveLR, 0, moveFB); //preliminary motion vector
            transform.Rotate(0, rotX, 0); //rotate player on y axis according to x rotation
            eyes.transform.Rotate(-rotY, 0, 0); //rotate eyes on x axis according to y rotation
            movement = transform.rotation * movement; //adjust motion vector according to new facing direction
            player.Move(movement * Time.deltaTime); //move player
        }
	}
    
    /**
     * Locks or unlocks player input
     */
    public void lockInput(bool stop)
    {
        locked = stop;
    }
}
