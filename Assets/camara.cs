using UnityEngine;

public class ControlCamaraJugador : MonoBehaviour
{
    public Transform jugador;

    [Header("Configuración Cámara")]
    public float sensibilidad = 200f;
    public float distancia = 30f;
    public float altura = 14f;

    private float rotacionX = 10f;
    private float rotacionY = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Click izquierdo presionado
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidad * 0.01f;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * 0.01f;

            rotacionX -= mouseY;
            rotacionX = Mathf.Clamp(rotacionX, -30f, 60f);

            rotacionY += mouseX;

            // Rotar jugador (solo en Y)
            jugador.rotation = Quaternion.Euler(0f, rotacionY, 0f);
        }
    }

    void LateUpdate()
    {
        if (jugador == null) return;

        // Dirección de la cámara
        Quaternion rotacion = Quaternion.Euler(rotacionX, rotacionY, 0);
        Vector3 direccion = rotacion * new Vector3(0, 0, -distancia);

        // Posición final
        transform.position = jugador.position + direccion + Vector3.up * altura;

        // Mirar al jugador
        transform.LookAt(jugador.position + Vector3.up * 1.5f);
    }
}