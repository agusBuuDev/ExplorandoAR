using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Sobre_Explorando : MonoBehaviour
{
    public UIManager UIManager; // Agrega una referencia al UIManager
    UIDocument doc_Sobre_Explorando;
    VisualElement vis_Sobre_Explorando;
    
    Label texto;
    

    Button home;
    Button mapa;

    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    void OnEnable()
    {
        doc_Sobre_Explorando = GetComponent<UIDocument>();
        VisualElement root = doc_Sobre_Explorando.rootVisualElement;        
        vis_Sobre_Explorando = root.Query<VisualElement>("Sobre_Explorando");
        home = root.Query<Button>("volver");
        mapa = root.Query<Button>("mapa");
        
        texto= root.Query<Label>("texto");
        


        root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

        home.RegisterCallback<ClickEvent>(ira_home);
        mapa.RegisterCallback<ClickEvent>(ira_mapa);
       
    }
 void OnDisable()
    {
        home.UnregisterCallback<ClickEvent>(ira_home);
        mapa.UnregisterCallback<ClickEvent>(ira_mapa);
    }
    // Métodos de funciones de los botones
   void ira_home(ClickEvent evt){
               UIManager.ActivateScreen("MainMenu");

    }
    void ira_mapa(ClickEvent evt){
               UIManager.ActivateScreen("Mapa");

    }

    //ajustar los tamaños de las fuentes al tamaño de la pantalla:
    private void OnGeometryChanged(GeometryChangedEvent evt)
{
    float windowWidth = evt.newRect.width;
    float fontSizeC = windowWidth * 0.065f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana

    // Aplica el tamaño de fuente a tus elementos de texto
   
   texto.style.fontSize = fontSizeC;
    

}
   
}

