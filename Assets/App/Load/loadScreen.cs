using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class loadScreen : MonoBehaviour
{
    public UIManager UIManager;
    UIDocument loadScreen_doc;
    VisualElement logo;
    Label title;

    private bool isRotating = false;
    private float rotationDuration = 5.0f; // Duración de la animación en segundos
    private float targetRotation = 2500.0f; // Rotación final en grados
    private float rotationStartTime; // Tiempo de inicio de la rotación
    private bool isSceneLoaded = false; // Flag para saber si la escena se ha cargado

    void Start()
    {
        loadScreen_doc = GetComponent<UIDocument>();
        VisualElement root = loadScreen_doc.rootVisualElement;

        logo = root.Q<VisualElement>("logo");
        title = root.Query<Label>("title");
        root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

        // Iniciar la rotación cuando se inicie la pantalla
        StartRotation();
    }

    void Update()
    {
        if (isRotating)
        {
            // Calcular el progreso de la animación
            float elapsedTime = Mathf.Min(Time.time - rotationStartTime, rotationDuration);
            float t = elapsedTime / rotationDuration;

            // Aplicar la rotación gradualmente
            float currentRotation = Mathf.Lerp(0.0f, targetRotation, t);
            logo.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            // Detener la rotación al alcanzar la rotación final
            if (t >= 1.0f)
            {
                isRotating = false;

                // Iniciar la carga de la escena en una corrutina
                StartCoroutine(LoadSceneAsyncWithRotation());
            }
        }
    }

    private void StartRotation()
    {
        isRotating = true;
        rotationStartTime = Time.time;
    }

    private IEnumerator LoadSceneAsyncWithRotation()
    {
        // Continuar rotando el logo mientras carga la escena
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("app");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float rotationSpeed = 180.0f; // Velocidad de rotación en grados por segundo
            float currentRotation = targetRotation + rotationSpeed * Time.deltaTime;
            logo.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            // Si la escena se ha cargado por completo, permitir la activación de la escena
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                isSceneLoaded = true; // Marcar la escena como cargada
            }

            // Esperar un frame
            yield return null;
        }
    }

    private void OnGeometryChanged(GeometryChangedEvent evt)
    {
        float windowWidth = evt.newRect.width;
        float fontSize = windowWidth * 0.08f; // Calcula el tamaño de fuente dinámicamente en base al ancho de la ventana

        // Aplica el tamaño de fuente a tus elementos de texto
        title.style.fontSize = fontSize;
    }
}
