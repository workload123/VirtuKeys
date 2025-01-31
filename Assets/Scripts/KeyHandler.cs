using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyHandler : MonoBehaviour
{
    // this script is attached to each key
    // if the key is pressed by a hand, it changes its color and its sound is played
    // if a correct note is hit, the score is increased (+3)

    // Unity Events for pressing the key
    public UnityEvent onPress;
    public UnityEvent onRelease;

    private GameObject presser;
    private bool isKeyPressed;

    // audio of the key
    private AudioSource audioSource;

    // for changing the key color
    public Material newKeyMaterial;
    private Material originalKeyMaterial;
    private Renderer keyRenderer;

    private float originalYPos;

    // track notes in the collider
    private List<GameObject> collidingNotes = new List<GameObject>();

    // for updating the score
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        isKeyPressed = false;

        // Components
        audioSource = GetComponent<AudioSource>();
        keyRenderer = GetComponent<Renderer>();
        originalKeyMaterial = keyRenderer.material;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        originalYPos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the key is pressed and there are notes in the collider
        // Destroy the notes and increase the score
        if (isKeyPressed && collidingNotes.Count > 0)
        {
            DestroyNotes();
            gameManager.UpdateScore(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isKeyPressed && other.CompareTag("Hands"))
        {
            // the key is moved and its color is changed if it was pressed by a hand
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, originalYPos - 0.005f, gameObject.transform.localPosition.z);
            presser = other.gameObject;
            onPress.Invoke();

            isKeyPressed = true;

            // the key's sound is played
            audioSource.Play();
        }
        else if (other.CompareTag("Note"))
        {
            // Add the note to the list of colliding notes
            if (!collidingNotes.Contains(other.gameObject))
            {
                collidingNotes.Add(other.gameObject);
            }
            Debug.Log("Note");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && other.CompareTag("Hands"))
        {
            // back to default key status
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, originalYPos, gameObject.transform.localPosition.z);
            onRelease.Invoke();
            isKeyPressed = false;
        }
        else if (other.CompareTag("Note"))
        {
            // Remove the note from the list of colliding notes
            if (collidingNotes.Contains(other.gameObject))
            {
                collidingNotes.Remove(other.gameObject);
            }
        }
    }

    public void ChangeColor()
    {
        // Check if the Renderer is present
        if (keyRenderer != null)
        {
            // Change the color of the key material
            keyRenderer.material = newKeyMaterial;
        }
        else
        {
            Debug.LogWarning("Renderer is missing on this object!");
        }
    }

    public void ResetColor()
    {
        // Check if the Renderer is present
        if (keyRenderer != null)
        {
            // Reset the color of the material
            keyRenderer.material = originalKeyMaterial;
        }
        else
        {
            Debug.LogWarning("Renderer is missing on this object!");
        }
    }

    private void DestroyNotes()
    {
        // Destroy all notes on the key press
        foreach (GameObject note in collidingNotes)
        {
            Destroy(note);
        }

        // Clear the list after destroying all notes
        collidingNotes.Clear();
    }
}
