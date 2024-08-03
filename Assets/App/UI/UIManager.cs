using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Audios soundManager;
    public GameObject MainMenu;
    public GameObject Sobre_ABP;
    public GameObject Sobre_Explorando;
    public GameObject Quiz;
    public GameObject RAGame;
    public GameObject Mapa;
    public GameObject Estacion;

    private GameObject currentScreen;
    private Dictionary<string, GameObject> screens = new Dictionary<string, GameObject>();

     

    private void Start(  )
    {
        soundManager = FindObjectOfType<Audios>();
        // Asignar las pantallas al diccionario
        screens.Add("MainMenu", MainMenu);
        screens.Add("Sobre_ABP", Sobre_ABP);
        screens.Add("Sobre_Explorando", Sobre_Explorando);
        screens.Add("Quiz", Quiz);
        screens.Add("RAGame", RAGame);
        screens.Add("Mapa", Mapa);
        screens.Add("Estacion", Estacion);

        // Desactivar todas las pantallas al inicio
        DeactivateAllScreens();

    // Activar la pantalla inicial (por ejemplo, MainMenu)
    ActivateScreen("MainMenu");
}

public void ActivateScreen(string screenName)
{
    if (screens.TryGetValue(screenName, out GameObject screen))
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
        }

        screen.SetActive(true);
        currentScreen = screen;
        soundManager.playClic();

    }
    else
    {
        Debug.LogWarning("Screen not found: " + screenName);
    }
}

private void DeactivateAllScreens()
{
    foreach (var screen in screens.Values)
    {
        screen.SetActive(false);
    }
}


}

