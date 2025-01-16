using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // This script spawns random notes in the defined interval
    // It is  attached to the Game Manager gameobject

    // Notes
    public GameObject[] notesPrefab;
    private int notesIndex;

    // For spawning the notes
    private float startDelay = 2;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning notes
        InvokeRepeating("SpawnNote", startDelay, spawnInterval);
    }

    // Spawn random notes at the defined interval
    void SpawnNote()
    {
        notesIndex = Random.Range(0, notesPrefab.Length);
        Instantiate(notesPrefab[notesIndex], notesPrefab[notesIndex].transform.position, notesPrefab[notesIndex].transform.rotation);
    }
}
