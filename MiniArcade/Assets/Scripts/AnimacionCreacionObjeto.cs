using UnityEngine;  // Importamos UnityEngine para usar GameObjects y LeanTween

public class AnimacionCreacionObjeto : MonoBehaviour
{
    private GameObject circuloVisual;  // Objeto visual que representa el círculo bajo los objetos seleccionados
    private LTDescr tweenAnimacion;  // Variable para almacenar la animación de LeanTween
    private GameObject objetoActual;  // Objeto actualmente seleccionado

    [SerializeField] private GameObject sombra;
    private GameObject sombraActual;

    void Start()
    {
        sombraActual = Instantiate(sombra, Vector3.zero, Quaternion.identity);
        sombraActual.SetActive(false);
        LeanTween.scale(sombraActual, new Vector3(2f, sombraActual.transform.localScale.y, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine).setLoopPingPong();
    }

    void Update()
    {
        // Si el círculo está activo y hay un objeto seleccionado, actualizar su posición
        if (objetoActual != null && sombraActual != null)
        {
            sombraActual.transform.position = new Vector3(objetoActual.transform.position.x, 0.0f, objetoActual.transform.position.z);
        }
    }

   
    // Muestra el círculo debajo del objeto seleccionado y reinicia la animación.

    // <param name="objeto">El objeto seleccionado</param>
    public void MostrarCirculo(GameObject objeto)
    {
        objetoActual = objeto;

        sombraActual.SetActive(true);

        // Guardar referencia del objeto seleccionado
        Debug.Log("Círculo activado debajo del objeto: " + objeto.name);
    }

    // Oculta el círculo cuando el objeto se deselecciona.
 
    public void OcultarCirculo()
    {
        sombraActual.SetActive(false);
    }
}
