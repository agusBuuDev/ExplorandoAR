using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using System;




public class RAGame : MonoBehaviour
{
    public UIManager UIManager; // Agrega una referencia al UIManager
    public Audios soundManager;

    UIDocument doc_RAGame;   
    VisualElement vis_RAGame;
        Button foto;
        Button home;
        Button mapa;
         //string albumName = "ExplorandoAR"; 
        //public string carpetaDeCapturas = "Fotos"; 

    
    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        soundManager = FindObjectOfType<Audios>();
    }
    void OnEnable()
    {
        doc_RAGame = GetComponent<UIDocument>();
        VisualElement root = doc_RAGame.rootVisualElement;
            

        vis_RAGame = root.Query<VisualElement>("RAGame");
        foto = root.Query<Button>("foto");
        home = root.Query<Button>("volver");
        mapa = root.Query<Button>("mapa");

        home.RegisterCallback<ClickEvent>(ira_home);
        mapa.RegisterCallback<ClickEvent>(ira_mapa);
        foto.RegisterCallback<ClickEvent>(ClickShare);
            
        

        //funciones de los botones en RAGame


    }
    void OnDisable()
    {
        home.UnregisterCallback<ClickEvent>(ira_home);
        mapa.UnregisterCallback<ClickEvent>(ira_mapa);
        foto.UnregisterCallback<ClickEvent>(ClickShare);
    }

    // Métodos de funciones de los botones
    void ira_home(ClickEvent evt){
               UIManager.ActivateScreen("MainMenu");

    }
    void ira_mapa(ClickEvent evt){
               UIManager.ActivateScreen("Mapa");

    }
     
         public void ClickShare(ClickEvent evt)
    {
    home.style.display = DisplayStyle.None;
    mapa.style.display = DisplayStyle.None;
    foto.style.display = DisplayStyle.None;
        StartCoroutine(TakeSSAndShare());
    }

   private IEnumerator TakeSSAndShare()
    {
        soundManager.playFoto();
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();
        string path = GetAndroidExternalStoragePath();
        string filePath = Path.Combine(path , "Tanks" + timeStamp + ".png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());
        Debug.Log("Se guardó en " + filePath);

        // Actualizar la galería de fotos
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", "android.intent.action.MEDIA_SCANNER_SCAN_FILE");
        AndroidJavaObject objFile = new AndroidJavaObject("java.io.File", filePath);
        AndroidJavaObject objUri = classUri.CallStatic<AndroidJavaObject>("fromFile", objFile);
        objIntent.Call<AndroidJavaObject>("setData", objUri);
        objActivity.Call("sendBroadcast", objIntent);

        // Destruir la textura
        Destroy(ss);

        home.style.display = DisplayStyle.Flex;
        mapa.style.display = DisplayStyle.Flex;
        foto.style.display = DisplayStyle.Flex;
    }
    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory", 
            jc.GetStatic<string>("DIRECTORY_DCIM"))
            .Call<string>("getAbsolutePath");
        return path;
    }
}


   /*  public void TomarYGuardarCaptura(ClickEvent evt)
{
    // Asegurarse de que la carpeta de capturas exista, si no, crearla
    if (!Directory.Exists(carpetaDeCapturas))
    {
        Directory.CreateDirectory(carpetaDeCapturas);
    }

    // Ocultar los botones
    home.style.display = DisplayStyle.None;
    mapa.style.display = DisplayStyle.None;
    foto.style.display = DisplayStyle.None;

  
   //Hora y fecha
    DateTime fechaHoraActual = DateTime.Now;
    string formatoFechaHora = "yyyyMMddHHmmss";
    string fechaHoraFormateada = fechaHoraActual.ToString(formatoFechaHora);
    //nombre del archivo
    string rutaCompleta = System.IO.Path.Combine(carpetaDeCapturas, "captura_" + fechaHoraFormateada + ".png");

    // Toma la captura de pantalla y guárdala en la ubicación especificada
    
    ScreenCapture.CaptureScreenshot(rutaCompleta);
    Debug.Log("Captura de pantalla tomada y guardada en " + rutaCompleta);

    // Invocar la función para tomar la captura después de un retraso de 1 segundo
    Invoke("TomarCapturaDespuesDeRetraso", 1.0f);
    soundManager.playFoto();
}
private void TomarCapturaDespuesDeRetraso()
{   

    // Mostrar nuevamente los botones
    home.style.display = DisplayStyle.Flex;
    mapa.style.display = DisplayStyle.Flex;
    foto.style.display = DisplayStyle.Flex;
}  */

    
    

