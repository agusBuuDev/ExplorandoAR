using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Mapa : MonoBehaviour
{
    public UIManager UIManager; // Agrega una referencia al UIManager
    public Quiz Quiz;


    string[] KEYS = {
    "A1B2C", "D3E4F", "G5H6I", "J7K8L", "M9N0O", "P1Q2R", "S3T4U", "V5W6X", "Y7Z8D", "E9F0G",
    "H1I2J", "K3L4M", "N5O6P", "Q7R8S", "T9U0V", "W1X2Y", "Z3A4B", "C5D6E", "F7G8H", "I9J0K",
    "L1M2N", "O3P4Q", "R5S6T", "U7V8W", "X9Y0Z", "A1B2C", "D3E4F", "G5H6I", "J7K8L", "M9N0O",
    "P1Q2R", "S3T4U", "V5W6X", "Y7Z8D", "E9F0G", "H1I2J", "K3L4M", "N5O6P", "Q7R8S", "T9U0V",
    "W1X2Y", "Z3A4B", "C5D6E", "F7G8H", "I9J0K", "L1M2N", "O3P4Q", "R5S6T", "U7V8W", "X9Y0Z"
    };

    


    UIDocument doc_Mapa;


    VisualElement vis_Mapa;
    Button est_1;
    Button est_2;
    Button est_3;
    Button est_4;
    Button est_5;
    Button est_6;
    Button est_7;
    Button home;
    Label puntos;
    VisualElement modal;
    VisualElement close;
    Label reset;
    bool aux;
    Label mensaje;
    string code;
    string winnerCode;
    public Sprite tick;
    



    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        Quiz = FindObjectOfType<Quiz>();
        aux = false;
        


    }
    private void Update()
    {
        // Actualiza el Text Label con los puntos actuales desde la clase Quiz
       
       puntos.text = Quiz.Puntos.ToString();
           



        if (Quiz.Puntos >= 60)
        {
            est_7.style.display = DisplayStyle.Flex;

        }
        if (Quiz.Puntos >= 60 && aux == false)
        {
            reset.style.display = DisplayStyle.None;
            mensaje.text = "¡Felicitaciones! Completaste los 60 puntos y desbloqueaste la estación ganadora. ¡Visitala para obtener tu código ganador!";            
            modal.style.display = DisplayStyle.Flex;
            code = KEYS[UnityEngine.Random.Range(0, 50)];
            aux = true;
        }
    }

    void OnEnable()
    {
        
        
        if (Quiz.Puntos >= 60)
        {
            est_7.style.display = DisplayStyle.Flex;
            modal.style.display = DisplayStyle.Flex;

        }
        doc_Mapa = GetComponent<UIDocument>();
        VisualElement root = doc_Mapa.rootVisualElement;
        vis_Mapa = root.Query<VisualElement>("Mapa");
        est_1 = root.Query<Button>("est_1");
        est_2 = root.Query<Button>("est_2");
        est_3 = root.Query<Button>("est_3");
        est_4 = root.Query<Button>("est_4");
        est_5 = root.Query<Button>("est_5");
        est_6 = root.Query<Button>("est_6");
        est_7 = root.Query<Button>("est_7");
        home = root.Query<Button>("volver");
        puntos = root.Query<Label>("puntos");
        modal = root.Query<VisualElement>("modal");
        close = root.Query<VisualElement>("close");
        mensaje = root.Query<Label>("msj");
        reset = root.Query<Label>("reset");

        //Mapa botones de las estaciones
        est_1.RegisterCallback<ClickEvent, int>(abrir_EST, 1);
        est_2.RegisterCallback<ClickEvent, int>(abrir_EST, 2);
        est_3.RegisterCallback<ClickEvent, int>(abrir_EST, 3);
        est_4.RegisterCallback<ClickEvent, int>(abrir_EST, 4);
        est_5.RegisterCallback<ClickEvent, int>(abrir_EST, 5);
        est_6.RegisterCallback<ClickEvent, int>(abrir_EST, 6);
        est_7.RegisterCallback<ClickEvent>(C_ganador);

        home.RegisterCallback<ClickEvent>(ira_home);
        close.RegisterCallback<ClickEvent>(Close);
        reset.RegisterCallback<ClickEvent>(Reset_plpref);
        cargar_estaciones();
        root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
        
        
    }
    void OnDisable()
    {
        est_1.UnregisterCallback<ClickEvent, int>(abrir_EST);
        est_2.UnregisterCallback<ClickEvent, int>(abrir_EST);
        est_3.UnregisterCallback<ClickEvent, int>(abrir_EST);
        est_4.UnregisterCallback<ClickEvent, int>(abrir_EST);
        est_5.UnregisterCallback<ClickEvent, int>(abrir_EST);
        est_6.UnregisterCallback<ClickEvent, int>(abrir_EST);
        est_7.UnregisterCallback<ClickEvent>(C_ganador);

        home.UnregisterCallback<ClickEvent>(ira_home);
        close.UnregisterCallback<ClickEvent>(Close);
    }
    // Métodos de funciones de los botones


    void C_ganador(ClickEvent evt)
    {

        mensaje.text = "Felicitaciones, tu código ganador es: \n" + code;
        
        reset.style.display = DisplayStyle.Flex;
        modal.style.display = DisplayStyle.Flex;

    }

    void Close(ClickEvent evt)
    {
        modal.style.display = DisplayStyle.None;
        UIManager.ActivateScreen("Mapa");

    }
    void abrir_RAGame(ClickEvent evt)
    {
        UIManager.ActivateScreen("RAGame");

    }

    void abrir_EST(ClickEvent evt, int est)
    {
        Quiz.CurrentEstacion = est;
        UIManager.ActivateScreen("Estacion");
    }

    void ira_home(ClickEvent evt)
    {
        UIManager.ActivateScreen("MainMenu");

    }
     
    void Reset_plpref (ClickEvent evt){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        UIManager.ActivateScreen("Quiz");
        UIManager.ActivateScreen("MainMenu");

    }
    

void cargar_estaciones()
{         
        if (PlayerPrefs.GetInt("est1", 0) == 1)
        {
            est_1.style.backgroundImage = new StyleBackground(tick.texture);
        }
        if (PlayerPrefs.GetInt("est2", 0) == 1)
        {
            est_2.style.backgroundImage = new StyleBackground(tick.texture);
        }
        if (PlayerPrefs.GetInt("est3", 0) == 1)
        {
            est_3.style.backgroundImage = new StyleBackground(tick.texture);
        }
        if (PlayerPrefs.GetInt("est4", 0) == 1)
        {
            est_4.style.backgroundImage = new StyleBackground(tick.texture);
        }
        if (PlayerPrefs.GetInt("est5", 0) == 1)
        {
            est_5.style.backgroundImage = new StyleBackground(tick.texture);
        }
        if (PlayerPrefs.GetInt("est6", 0) == 1)
        {
            est_6.style.backgroundImage = new StyleBackground(tick.texture);
        }
    
}

private void OnGeometryChanged(GeometryChangedEvent evt)
    {
        float windowWidth = evt.newRect.width;
        float fontSize = windowWidth * 0.05f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana
         
        // Aplica el tamaño de fuente a tus elementos de texto

        mensaje.style.fontSize = fontSize;     
        reset.style.fontSize = fontSize;  
        puntos.style.fontSize = fontSize;



        // ...
    }







}


