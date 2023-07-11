using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendantInputs : MonoBehaviour
{
    [Header("RigidBody")]
    Rigidbody cuerpo;

    [Header("Movimiento")]
    public bool salto = false;
    public float fuerzaDeSalto = 5f;
    public float velocidadFrontal = 10f;
    public float velocidadLateral = 10f;

    [Header("Rotación")]
    public float rotacionHorizontal = 2.0f;
    public float rotacionVertical = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Saltar();
        Movimiento();
        RotacionDeCamara();
    }

    public void Saltar()
    {
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;

            if (salto == true)
            {
                cuerpo.AddForce(transform.up * (fuerzaDeSalto * 50));
            }
        }
    }

    public void Movimiento()
    {
        float movimientoFrontal = Input.GetAxis("Vertical") * velocidadFrontal;
        float movimientoLateral = Input.GetAxis("Horizontal") * velocidadLateral;

        movimientoFrontal *= Time.deltaTime;
        movimientoLateral *= Time.deltaTime;

        transform.Translate(0, 0, movimientoFrontal);
        transform.Translate(movimientoLateral, 0, 0);
    }

    public void RotacionDeCamara()
    {
        float rotacionEnX = rotacionHorizontal * Input.GetAxis("Mouse X");
        float rotacionEnY = rotacionVertical * Input.GetAxis("Mouse Y");

        transform.Rotate(rotacionEnY, rotacionEnX, 0);
    }
}
