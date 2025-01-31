using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // this script is attached to each note prefab
    // if a note is missed it will be destroyed out of bounds 
    // and the score is decreased (-1)

    // boundary for destroying notes
    private float lowerBound = -1;

    // for updating the score
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
