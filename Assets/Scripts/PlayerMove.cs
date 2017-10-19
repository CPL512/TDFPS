using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 5f;
    public float sensitivity = 5f;
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
        if (!locked)
        {
            moveFB = Input.GetAxis("Vertical") * speed;
            moveLR = Input.GetAxis("Horizontal") * speed;

            rotX = Input.GetAxis("Mouse X") * sensitivity;
            rotY = Input.GetAxis("Mouse Y") * sensitivity;

            Vector3 movement = new Vector3(moveLR, 0, moveFB);
            transform.Rotate(0, rotX, 0);
            eyes.transform.Rotate(-rotY, 0, 0);
            movement = transform.rotation * movement;
            player.Move(movement * Time.deltaTime);
        }
	}

    public void lockInput(bool stop)
    {
        locked = stop;
    }
}
