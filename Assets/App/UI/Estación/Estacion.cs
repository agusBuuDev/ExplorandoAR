using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class estacion : MonoBehaviour
{
     public UIManager UIManager; // Agrega una referencia al UIManager
     public Quiz Quiz;
     public Sprite kelenken;
     public Sprite maiten;
     public Sprite coihue;
     public Sprite higuera;
     public Sprite nahuelito;
     public Sprite taller;
     

    UIDocument doc_estacion;   
    Label titulo_est;
    Label descripcion;
    VisualElement imagen;
    VisualElement contenidos_btn;
    VisualElement desafio_btn;
    VisualElement explora_btn;
    Button volver;
    Button mapa;
    
    int num_est;



    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        Quiz = FindObjectOfType<Quiz>();
       
    }

    // Update is called once per frame
    void OnEnable()
    {
         num_est = Quiz.CurrentEstacion;
         doc_estacion = GetComponent<UIDocument>();
        VisualElement root = doc_estacion.rootVisualElement;

        
        titulo_est= root.Query<Label>("titulo_est");
        descripcion= root.Query<Label>("descripcion");
        imagen= root.Query<VisualElement>("imagen");
        contenidos_btn= root.Query<VisualElement>("contenidos_btn");
        desafio_btn= root.Query<VisualElement>("desafio_btn");
        explora_btn= root.Query<VisualElement>("explora_btn");
        
        volver= root.Query<Button>("volver");
        mapa= root.Query<Button>("mapa");
        
        root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
        desafio_btn.RegisterCallback<ClickEvent>(evt => ira_quiz());
        explora_btn.RegisterCallback<ClickEvent>(ira_RA);
        contenidos_btn.RegisterCallback<ClickEvent>(ira_contenido);
        volver.RegisterCallback<ClickEvent>(ira_home);
        mapa.RegisterCallback<ClickEvent>(ira_mapa);
        
        // carga de contenido según la estación
        
        CambiarTituloSegunEstacion();
        CambiarDescripcionSegunEstacion();
        CambiarImagenSegunEstacion();
       

    }
    void OnDisable()
    {
        desafio_btn.UnregisterCallback<ClickEvent>(evt => ira_quiz());
        explora_btn.UnregisterCallback<ClickEvent>(ira_RA);
        contenidos_btn.UnregisterCallback<ClickEvent>(ira_contenido);
        volver.UnregisterCallback<ClickEvent>(ira_home);
        mapa.UnregisterCallback<ClickEvent>(ira_mapa);
    }

     private void OnGeometryChanged(GeometryChangedEvent evt)
{
    float windowWidth = evt.newRect.width;
    float tituloSize = windowWidth * 0.08f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana
    float titulo_estSize = windowWidth * 0.09f;
    float descripcionSize = windowWidth * 0.04f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana
    
    
    // Aplica el tamaño de fuente a tus elementos de texto
   
    
    titulo_est.style.fontSize = titulo_estSize;
    descripcion.style.fontSize = descripcionSize;
   


 





}
    public void ira_quiz () {
    UIManager.ActivateScreen("Quiz");

    }
    void ira_home(ClickEvent evt){
               UIManager.ActivateScreen("MainMenu");

    }
    void ira_mapa(ClickEvent evt){
               UIManager.ActivateScreen("Mapa");

    }
    void ira_RA(ClickEvent evt){
               UIManager.ActivateScreen("RAGame");

    }
    void ira_contenido(ClickEvent evt){
               string contentURL = "https://pruebas.koisolucionesweb.com/est_"; 
    Application.OpenURL(contentURL);

    }

    //Funciones de carga de contenido para la estación

    void CambiarTituloSegunEstacion(){
    switch (num_est){
        case 1:
            titulo_est.text = "El bosque de maitenes";
            break;
        case 2:
            titulo_est.text = "Tronco coihue fósil";
            break;
        case 3:
            titulo_est.text = "Kelenken y megaterio";
            break;
        case 4:
            titulo_est.text = "La Higuera, lugar de encuentro";
            break;
        case 5:
            titulo_est.text = "El gran mito del Nahuelito";
            break;
        case 6:
            titulo_est.text = "Taller del museo";
            break;
       
        default:
            titulo_est.text = "error - estación no disponible";
            break;
    }
}
  void CambiarDescripcionSegunEstacion(){
    descripcion.style.whiteSpace = WhiteSpace.Normal;

    switch (num_est){
        case 1:
            descripcion.text = "El Maitén, un árbol siempreverde de hasta 20 m de altura, destaca por su elegancia y ramas delgadas. Su tronco es recto y la copa ancha. Es cultivado por su aceite rico en carotenos y polifenoles. Sus hojas son pequeñas, elípticas, de borde aserrado y verde claro. Las flores, de color amarillo amarronado y verde con líneas púrpuras, pueden ser masculinas, femeninas o hermafroditas. Florece de noviembre a enero.";
            break;
        case 2:
            descripcion.text = "El tronco de coihue petrificado: un asombroso fósil que muestra la forma original del antiguo árbol, reemplazado por minerales a lo largo del tiempo. Su color oscuro y textura revelan procesos geológicos de millones de años. ";
            break;
        case 3:
            descripcion.text = "Kelenken, conocido como el 'Ave del Terror', fue un gigantesco pájaro prehistórico que habitó en Sudamérica durante el Eoceno. Con un cráneo de 70 cm y una envergadura de alas de 5 metros, era un depredador formidable. Se alimentaba de pequeños mamíferos y aves. Su tamaño y anatomía lo convierten en una fascinante criatura del pasado.";
            break;
        case 4:
            descripcion.text = "un árbol emblemático de gran tamaño y copa extensa. Su longevidad y amplio dosel brindan sombra y refugio a la fauna. Sus ramas aéreas se asemejan a raíces, creando una estructura única. Cultivada y apreciada por su fruto dulce y nutritivo. Una presencia imponente en el paisaje, símbolo de resistencia y conexión con la naturaleza.";
            break;
        case 5:
            descripcion.text = "El mito del Nahuelito es una fascinante leyenda que ha perdurado a lo largo del tiempo en la región de los lagos de la Patagonia argentina. Se le describe como un ser similar a un plesiosaurio, con un largo cuello y grandes aletas. Se dice que habita en las profundidades del lago Nahuel Huapi y ha sido avistado en varias ocasiones a lo largo de la historia.";
            break;
        case 6:
            descripcion.text = "Ubicado en San Carlos de Bariloche, Argentina, este taller es el corazón de la investigación y restauración de fósiles prehistóricos. Aquí, paleontólogos y expertos trabajan minuciosamente para desentrañar los secretos del pasado, reconstruyendo esqueletos de criaturas antiguas como el Kelenken y el megaterio.";
            break;
       
        default:
            descripcion.text = "error - estación no disponible";
            break;
    }
}
 
   void CambiarImagenSegunEstacion(){
    switch (num_est){
        case 1:
            imagen.style.backgroundImage = maiten.texture;
            break;
        case 2:
            imagen.style.backgroundImage = coihue.texture;
            break;
        case 3:
            imagen.style.backgroundImage = kelenken.texture;
            break;
        case 4:
            imagen.style.backgroundImage = higuera.texture;
            break;
        case 5:
            imagen.style.backgroundImage = nahuelito.texture;
            break;
        case 6:
            imagen.style.backgroundImage = taller.texture;
            break;
       
        default:
            titulo_est.text = "error - estación no disponible";
            break;
    }
}


}