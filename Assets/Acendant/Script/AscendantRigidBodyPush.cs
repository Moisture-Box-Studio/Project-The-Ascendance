using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendantRigidBodyPush : MonoBehaviour
{
    public LayerMask empujadores;
    public bool puedeEmpujar;

    [Range(0.5f, 5f)] public float fuerza = 1.1f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (puedeEmpujar) EmpujarRigidBodies(hit);
    }

    private void EmpujarRigidBodies(ControllerColliderHit hit)
    {
        // Se asegura de que no choque con un cuerpo kinematico
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) return;

        // Se asegura de que el empuje solo se aplica a determinadas capas o grupos
        var bodyLayerMask = 1 << body.gameObject.layer;
        if ((bodyLayerMask & empujadores.value) == 0) return;

        // Se asegura de no empujar cuerpos debajo del jugador
        if (hit.moveDirection.y < -0.3f) return;

        // Calcula el movimiento hacia direcciones horizontales solamente 
        Vector3 empujarEnDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

        // Aplica la empuje y tiene en cuenta la fuerza
        body.AddForce(empujarEnDir * fuerza, ForceMode.Impulse);
    }
}
