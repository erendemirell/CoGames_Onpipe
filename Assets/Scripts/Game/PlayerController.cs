using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isCollidedCylinder = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cylinder")
        {
            isCollidedCylinder = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Cylinder")
        {
            isCollidedCylinder = false;
        }
    }
}
