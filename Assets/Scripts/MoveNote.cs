using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{
    // this script is attached to each note prefab
    // it moves the note with the defined speed
    // if a note is missed it will be destroyed out of bounds 
    // and the score is decreased (-1)

    // travelling speed of the note
    public float noteSpeed;

    // boundary for destroying notes
    private float lowerBound = 0.1f;

    // for updating the score
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        noteSpeed = gameManager.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // move note
        transform.Translate(Vector3.back * Time.deltaTime * noteSpeed);

        if (transform.position.z < lowerBound)
        {
            // destroy the note
            Destroy(gameObject);
            gameManager.UpdateScore(-1);
        }

        // ####################
        // for cubes (hands) - only for prototyping
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject); // destroy cube
        }
    }
}
