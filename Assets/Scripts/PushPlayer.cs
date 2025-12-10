using Unity.VisualScripting;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D otraBola;
    public float fuerza = 4.5f;
    public KeyCode teclaEmpuje;
    bool enContacto;

    void Update()
    {
        if (Input.GetKeyDown(teclaEmpuje) && enContacto)
        {
            Empujar();
        }
    }

    void Empujar()
    {
        Vector2 direccion = (otraBola.position - rb.position).normalized;
        otraBola.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody == otraBola)
        {
            enContacto = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody == otraBola)
        {
            enContacto = false;
        }
    }
}
