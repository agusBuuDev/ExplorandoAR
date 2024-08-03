using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MainMenu : MonoBehaviour
{

    public UIManager UIManager; // Agrega una referencia al UIManager
    
    UIDocument doc_MainMenu;
    VisualElement MAIN;
        Button sobre_abp;
        Button sobre_explorando;
        Button mapa;
        Button explorar;
        Button facebook;
        Button instagram;
        Button mail;
     
   
 private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        
    }
    void OnEnable()
    {
        doc_MainMenu = GetComponent<UIDocument>();
        VisualElement root = doc_MainMenu.rootVisualElement;
        
            MAIN = root.Query<VisualElement>("MAIN");
            sobre_abp = root.Query<Button>("sobre_abp");
            sobre_explorando = root.Query<Button>("sobre_explorando");
            mapa = root.Query<Button>("mapa");
            explorar = root.Query<Button>("explorar");
            facebook = root.Query<Button>("facebook");
            instagram = root.Query<Button>("instagram");
            mail = root.Query<Button>("mail");

            // ajustar el tamaño de las fuentes según la pantalla: 

        root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);


             // Funciones de los botones en la pantalla MAIN
       
        facebook.RegisterCallback<ClickEvent>(abrir_facebook);
        instagram.RegisterCallback<ClickEvent>(abrir_instagram);
        mail.RegisterCallback<ClickEvent>(abrir_mail);
        sobre_abp.RegisterCallback<ClickEvent>(abrir_Sobre_ABP);
        sobre_explorando.RegisterCallback<ClickEvent>(abrir_Sobre_Explorando);
        mapa.RegisterCallback<ClickEvent>(abrir_Mapa);
        explorar.RegisterCallback<ClickEvent>(abrir_RAGame);

        
          }

          void OnDisable()
          {
        facebook.UnregisterCallback<ClickEvent>(abrir_facebook);
        instagram.UnregisterCallback<ClickEvent>(abrir_instagram);
        mail.UnregisterCallback<ClickEvent>(abrir_mail);
        sobre_abp.UnregisterCallback<ClickEvent>(abrir_Sobre_ABP);
        sobre_explorando.UnregisterCallback<ClickEvent>(abrir_Sobre_Explorando);
        mapa.UnregisterCallback<ClickEvent>(abrir_Mapa);
        explorar.UnregisterCallback<ClickEvent>(abrir_RAGame);
          }
    void abrir_facebook(ClickEvent evt){
    string facebookURL = "https://www.facebook.com/museopalentologico"; // URL de la página de Facebook
    Application.OpenURL(facebookURL);
    }

    void abrir_instagram(ClickEvent evt){
    string instagramURL = "https://www.instagram.com/museoapb"; // Reemplaza con la URL de tu perfil de Instagram
    Application.OpenURL(instagramURL);

    }

    void abrir_mail(ClickEvent evt){
    string gmailURL = "mailto:museoapb@gmail.com"; // Reemplaza con tu dirección de correo electrónico de Gmail
    Application.OpenURL(gmailURL);
    }

    void abrir_Sobre_ABP(ClickEvent evt){
        UIManager.ActivateScreen("Sobre_ABP");
    }
    
     void abrir_Sobre_Explorando(ClickEvent evt){
        UIManager.ActivateScreen("Sobre_Explorando");
    }
    void abrir_Mapa(ClickEvent evt){
        UIManager.ActivateScreen("Mapa");
    }
    void abrir_RAGame(ClickEvent evt){
        UIManager.ActivateScreen("RAGame");
    }

    //ajustar los tamaños de las fuentes al tamaño de la pantalla:
    private void OnGeometryChanged(GeometryChangedEvent evt)
{
    float windowWidth = evt.newRect.width;
    float fontSize = windowWidth * 0.06f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana

    // Aplica el tamaño de fuente a tus elementos de texto
   
    sobre_abp.style.fontSize = fontSize; 
    sobre_explorando.style.fontSize = fontSize;
    mapa.style.fontSize = fontSize; 
    explorar.style.fontSize = fontSize; 
    // ...
}



}

