using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Quiz : MonoBehaviour
{
    public UIManager UIManager;
    public Audios soundManager;

    private static int currentEstacion;

    public static int CurrentEstacion
    {
        get { return currentEstacion; }
        set { currentEstacion = value; }
    }

    private static int PuntosT;
    public static int Puntos
    {
        get { return PuntosT; }
        set { PuntosT = value; }
    }
    public int[] control_preguntas = {0, 0, 0, 0, 0, 0, 0};

    UIDocument doc_Quiz;
    VisualElement QUIZ;
    Button home;
    Button mapa;
    Pregunta pregunta_visible;
    Label pregunta;
    List<Pregunta> preguntas;
    VisualElement opciones;
    VisualElement FEEDBACK;
    VisualElement Modal;
    VisualElement Close;
    Label feed;

    private void Awake(){
        PuntosT= PlayerPrefs.GetInt("puntos", 0);
        control_preguntas[1]=PlayerPrefs.GetInt("est1", 0);
        control_preguntas[2]=PlayerPrefs.GetInt("est2", 0);
        control_preguntas[3]=PlayerPrefs.GetInt("est3", 0);
        control_preguntas[4]=PlayerPrefs.GetInt("est4", 0);
        control_preguntas[5]=PlayerPrefs.GetInt("est5", 0);
        control_preguntas[6]=PlayerPrefs.GetInt("est6", 0);
        Debug.Log("Puntos Guardados: "+PuntosT+" Array de estaciones: "+control_preguntas[0]+control_preguntas[1]+control_preguntas[2]+control_preguntas[3]+control_preguntas[4]+control_preguntas[5]);

        

    }

    private void OnEnable()
    {
        PuntosT= PlayerPrefs.GetInt("puntos", 0);
        control_preguntas[1]=PlayerPrefs.GetInt("est1", 0);
        control_preguntas[2]=PlayerPrefs.GetInt("est2", 0);
        control_preguntas[3]=PlayerPrefs.GetInt("est3", 0);
        control_preguntas[4]=PlayerPrefs.GetInt("est4", 0);
        control_preguntas[5]=PlayerPrefs.GetInt("est5", 0);
        control_preguntas[6]=PlayerPrefs.GetInt("est6", 0);

        UIManager = FindObjectOfType<UIManager>();
        soundManager = FindObjectOfType<Audios>();
        //preguntas

        preguntas = new List<Pregunta>();


        // Estación 1
        preguntas.Add(new Pregunta("¿Bariloche fue cálido, parecía un bosque tropical?", new List<string>() { "NO", "Si" }, 1, 1));
        preguntas.Add(new Pregunta("¿Bariloche en el pasado tenía grandes glaciales?", new List<string>() { "Si", "No" }, 0, 1));
        preguntas.Add(new Pregunta("¿Bariloche estuvo cubierto por el mar?", new List<string>() { "No", "Si" }, 1, 1));

        // Estación 2
        preguntas.Add(new Pregunta("¿Cómo se llamaba este árbol?", new List<string>() { "Nothofagus", "Araucaria", "Pino", "Palma" }, 0, 2));
        preguntas.Add(new Pregunta("¿Cuándo estuvo vivo?", new List<string>() { "Está vivo ahora", "En el Mioceno hace 15 millones de años", "Vivió con los dinosaurios hace 201.4 millones de años" }, 1, 2));
        preguntas.Add(new Pregunta("¿Cuánto medía de alto?", new List<string>() { "25 mts", "5 mt", "1 m", "220 mt" }, 0, 2));

        // Estación 3
        preguntas.Add(new Pregunta("¿Dónde se encontró el fósil del cráneo de Kelenken que está en el museo?", new List<string>() { "Comallo", "Bariloche", "San Carlos de Bariloche", "San Carlos de Bariloche en el Cerro Catedral" }, 0, 3));
        preguntas.Add(new Pregunta("¿El Kelenken y el Megaterio vivieron juntos?", new List<string>() { "No, el Kelenken vivió con los dinosaurios ", "Si, en el cuaternario, en la edad de hielo ", "Si, vivieron juntos en el jurasico ", "No, el megaterios vivo en el jurasico " }, 1, 3));
        preguntas.Add(new Pregunta("¿Cuánto pesaba?", new List<string>() { "18 kg", "6 kg", "16 toneladas", "2,6 toneladas" }, 0, 3));

        // Estación 4
        preguntas.Add(new Pregunta("¿Cuándo se fundó la Asociación Paleontológica Bariloche?", new List<string>() { "El 30 de mayo de 2015", "El 29 de abril de 2007", "El 29 de abril de 1977", "El 3 de enero de 1986" }, 2, 4));
        preguntas.Add(new Pregunta("¿Qué significa APB?", new List<string>() { "Asociación Paleontológica Bariloche", "Asociación Para Bariloche", "Asociación de Paleontólogos de Bariloche", "Asociación Para Buscar Fósiles" }, 0, 4));
        preguntas.Add(new Pregunta("¿Qué hace la Asociación paleontológica Bariloche?", new List<string>() { "Preserva, exhibe y resguarda el patrimonio paleontológico local y regional", "Difunde el conocimiento y patrimonio paleontológico local y regional a la comunidad", "Crea y mantiene el Museo Paleontológico Bariloche", "Todas las anteriores" }, 0, 4));

        // Estación 5
        preguntas.Add(new Pregunta("Si el Nahuelito existiera, ¿a qué reptil marino se parecería?", new List<string>() { "Carnotaurus", "Dinosaurio", "Plesiosaurio", "Megaterio" }, 2, 5));
        preguntas.Add(new Pregunta("¿El Ictiosaurio es un dinosaurio?", new List<string>() { "No", "Sí" }, 0, 5));
        preguntas.Add(new Pregunta("¿Cuál de los siguientes es un reptil marino?", new List<string>() { "Ictiosaurio" }, 0, 5));

        // Estación 6
        preguntas.Add(new Pregunta("¿Cómo se llaman las personas que dibujan o hacen escultura de los fósiles?", new List<string>() { "Paleoartistas", "Dibujantes", "Técnicos", "Investigadores" }, 0, 6));
        preguntas.Add(new Pregunta("¿Qué estudia un paleontólogo?", new List<string>() { "Diferentes tipos de fósiles", "Los huesos", "Los dinosaurios", "Los coprolitos" }, 0, 6));
        preguntas.Add(new Pregunta("¿Qué es un fósil?", new List<string>() { "Son huesos preservados en el registro fósil", "Son plantas preservadas en el registro fósil", "Son huellas preservadas en el registro fósil", "Todos los anteriores" }, 0, 6));
        preguntas.Add(new Pregunta("¿Quiénes trabajan con los paleontólogos limpiando y/o restaurando fósiles en el laboratorio y buscando fósiles en el campo?", new List<string>() { "Los y las técnicos de campo" }, 0, 6));

        //fin preguntas
        doc_Quiz = GetComponent<UIDocument>();
        VisualElement root = doc_Quiz.rootVisualElement;
        // ajustar el tamaño de las fuentes según la pantalla: 
        root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

        home = root.Query<Button>("volver");
        mapa = root.Query<Button>("mapa");
        pregunta = root.Query<Label>("pregunta");
        opciones = root.Query<VisualElement>("opciones");
        FEEDBACK = root.Query<VisualElement>("FEEDBACK");
        Modal = root.Query<VisualElement>("modal");
        Close = root.Query<VisualElement>("close");
        feed = root.Query<Label>("feed");

        pregunta_visible = ObtenerPreguntaAleatoria(currentEstacion, preguntas);
        if (pregunta_visible!= null){
        pregunta.text = pregunta_visible.texto;
        UpdateCurrentQuestion(pregunta_visible, opciones);

        home.RegisterCallback<ClickEvent>(IrAHome);
        mapa.RegisterCallback<ClickEvent>(IrAMapa);
        Close.RegisterCallback<ClickEvent>(Closef);
        }
    }
    void OnDisable()
    {
        home.UnregisterCallback<ClickEvent>(IrAHome);
        mapa.UnregisterCallback<ClickEvent>(IrAMapa);
        Close.UnregisterCallback<ClickEvent>(Closef);
    }
   

    // Métodos de funciones de los botones
    private void IrAHome(ClickEvent evt)
    {
        UIManager.ActivateScreen("MainMenu");
    }

    private void IrAMapa(ClickEvent evt)
    {
        UIManager.ActivateScreen("Mapa");
    }

    private void Closef(ClickEvent evt)
    {
        FEEDBACK.style.display = DisplayStyle.None;
        Modal.style.display = DisplayStyle.None;
        UIManager.ActivateScreen("Mapa");
    }

    Pregunta ObtenerPreguntaAleatoria(int numeroEstacion, List<Pregunta> preguntas)
    {
        Debug.Log("Quiz estación" + CurrentEstacion + "num recibido"+ numeroEstacion);
        
         List<Pregunta> preguntasEstacion = new List<Pregunta>();

        foreach (Pregunta pregunta in preguntas)
        {
            if (pregunta.estacion == numeroEstacion)
            {
                preguntasEstacion.Add(pregunta);
            }
        }

        if (preguntasEstacion.Count > 0)
        {
            int indiceAleatorio = Random.Range(0, preguntasEstacion.Count);
            Pregunta preguntaVisible = preguntasEstacion[indiceAleatorio];
            return preguntaVisible;
        }

        return null; // Si no se encuentran preguntas para la estación, se retorna null o puedes manejarlo de otra manera según tus necesidades
    
    } 
    private void UpdateCurrentQuestion(Pregunta preguntaVisible, VisualElement container)
    {
        int opcionIndex = 0;
        if (preguntaVisible != null)
        {
            // Actualizar el texto de la etiqueta pregunta
            pregunta.text = preguntaVisible.texto;

            // Eliminar todos los elementos hijos del contenedor existentes
            container.Clear();

            // Crear y agregar los botones de opciones
            foreach (string opcion in preguntaVisible.opciones)
            {
                Button botonOpcion = new Button();
                botonOpcion.text = opcion;
                botonOpcion.name = opcionIndex.ToString();


                // Asignar una clase al botón
                botonOpcion.AddToClassList("opcion-button");
                botonOpcion.AddToClassList("main");

                // Asignar un callback al botón para manejar la selección de la opción
                botonOpcion.clicked += () =>
                {


                    if (preguntaVisible.respuestaCorrecta.ToString() == botonOpcion.name)
                    {
                        if (control_preguntas[CurrentEstacion]==0){
                        PuntosT += 10;                        
                        control_preguntas[CurrentEstacion]=1;
                        PlayerPrefs.SetInt("puntos", PuntosT);
                        string estacion="est"+CurrentEstacion;
                        PlayerPrefs.SetInt(estacion, 1);
                        Debug.Log("puntaje guardado: "+PuntosT+" estación marcada: "+ estacion);
                        PlayerPrefs.Save();
                        
                        }
                        Debug.Log("corr. punt" + PuntosT + "selec" + botonOpcion.name + "corr " + preguntaVisible.respuestaCorrecta.ToString());
                        feed.text = "¡Correcto!";                     
                        soundManager.playCorrect();
                        FEEDBACK.style.display = DisplayStyle.Flex;
                        Modal.style.display = DisplayStyle.Flex;
                        Close.style.display = DisplayStyle.Flex;
                        

                    }
                    else
                    {
                        FEEDBACK.style.display = DisplayStyle.Flex;
                        Modal.style.display = DisplayStyle.Flex;
                        Close.style.display = DisplayStyle.Flex;
                        feed.text = "No exactamente ... Intenta nuevamente";
                        soundManager.playIncorrect();
                                               
                        Debug.Log("Respuesta , incorrecta " + PuntosT + "la opcion seleccionada fue " + botonOpcion.name + "la correcta era " + preguntaVisible.respuestaCorrecta.ToString());
                    }

                    Debug.Log("Opción seleccionada: " + opcion);
                    //UIManager.ActivateScreen("Mapa");
                };

                // Agregar el botón de opción al contenedor
                container.Add(botonOpcion);
                opcionIndex++; // Incrementar el índice para el próximo botón
            }
        }
        else
        {
            pregunta.text = "No hay preguntas disponibles.";
        }
    }
    //ajustar los tamaños de las fuentes al tamaño de la pantalla:
    private void OnGeometryChanged(GeometryChangedEvent evt)
    {
        float windowWidth = evt.newRect.width;
        float fontSize = windowWidth * 0.06f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana
        float sizePregunta=windowWidth * 0.075f; 

        // Aplica el tamaño de fuente a tus elementos de texto

        pregunta.style.fontSize = sizePregunta;
        feed.style.fontSize = fontSize;
        foreach (Button botonOpcion in opciones.Children())
        {
            botonOpcion.style.fontSize = fontSize;
        }




        // ...
    }

  


   

}


public class Pregunta
{
    public string texto;
    public List<string> opciones;
    public int respuestaCorrecta;
    public int estacion;
    public int index;

    public Pregunta(string texto, List<string> opciones, int respuestaCorrecta, int estacion)
    {
        this.texto = texto;
        this.opciones = opciones;
        this.respuestaCorrecta = respuestaCorrecta;
        this.estacion = estacion;
    }



}



