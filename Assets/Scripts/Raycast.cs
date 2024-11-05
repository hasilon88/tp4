using UnityEngine;

public class Raycast : MonoBehaviour
{
    
    // Lance un rayon à partir de la position actuelle du joueur.
    void Update()
    {
        FireRay();
    }

    void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;

        // Vérifie si le rayon touche un objet
        if (Physics.Raycast(ray, out hitData))
        {
            Debug.Log($"Objet: {hitData.collider.name} Distance: {hitData.distance}");
        }
    }
}
