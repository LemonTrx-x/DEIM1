using UnityEngine;
using TMPro;

public class AreaTrigger : MonoBehaviour
{
    public string mensajeEntrada = "Has entrado en la zona";
    public string mensajeSalida = "Has salido de la zona";
    public TMP_Text textMeshPro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(mensajeEntrada);
            textMeshPro.text = mensajeEntrada.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(mensajeSalida);
            textMeshPro.text = mensajeSalida.ToString();
        }
    }
}