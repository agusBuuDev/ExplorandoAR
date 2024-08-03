using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip foto; // Declara la variable para el clip de sonido
    public AudioClip clic;
    public AudioClip correct;
    public AudioClip incorrect;
    void Start()
    {
        // Asigna el clip al AudioSource en el método Start
        audioSource.clip = foto;
        audioSource.clip = clic;
        audioSource.clip = correct;
        audioSource.clip = incorrect;
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar lógica de sonido o reproducción de audio aquí si es necesario
    }

    public void playFoto()
    {
        audioSource.clip = foto;
        audioSource.Play();
    }
    public void playClic()
    {
        audioSource.clip = clic;
        audioSource.Play();
    }
    public void playCorrect()
    {
        audioSource.clip = correct;
        audioSource.Play();
    }
    public void playIncorrect()
    {
        audioSource.clip = incorrect;
        audioSource.Play();
    }
}
