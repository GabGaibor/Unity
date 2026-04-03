using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 15f;
    public float fuerzaSalto = 7f;

    private Rigidbody rb;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.forward * movimientoZ + transform.right * movimientoX;
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    // Detectar si está en el suelo
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}