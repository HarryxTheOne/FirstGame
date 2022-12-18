using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{


    // Steuerung
    public float speed = 10f; // Die Geschwindigkeit des Spielers
    public float acceleration = 10f; // Die Beschleunigung des Spielers
    public float brakeTime = 0.5f; // Die Bremszeit des Spielers
    private float currentSpeed; // Die aktuelle Geschwindigkeit des Spielers
    private Vector2 direction; // Die Richtung, in die sich der Spieler bewegt
    private Rigidbody2D rb;  // Der Rigidbody des Spielers

    private void Start()
    {

        //Steuerung
        rb = GetComponent<Rigidbody2D>(); // Den Rigidbody des Spielers abrufen
    }

    private void Update()
    {

        // Steuerung
        // Die Bewegungsrichtung aus den Eingaben des Spielers abrufen
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        direction = new Vector2(horizontalInput, verticalInput);

        // Die Geschwindigkeit des Spielers erhöhen, wenn er sich bewegt
        if (direction.sqrMagnitude > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        // Die Geschwindigkeit des Spielers verringern, wenn er sich nicht bewegt
        else
        {
            currentSpeed -= acceleration * Time.deltaTime * brakeTime;
        }

        // Die Geschwindigkeit des Spielers auf einen maximalen Wert beschränken
        currentSpeed = Mathf.Clamp(currentSpeed, 0, speed);
    }

    private void FixedUpdate()
    {
        // Steuerung
        // Den Rigidbody des Spielers entsprechend der Geschwindigkeit und Richtung bewegen
        rb.MovePosition(rb.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

}