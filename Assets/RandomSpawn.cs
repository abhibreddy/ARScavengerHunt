using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class RandomSpawn : MonoBehaviour
{
    public List<GameObject> shapeObjects; // List of shape objects (cube, pyramid, sphere, cylinder)
    public List<Material> colors; // List of materials representing different colors
    public ARPlaneManager planeManager; // Reference to the AR Plane Manager
    public int objCounter;

    void Start()
    {
        planeManager.planesChanged += OnPlanesChanged; // Subscribe to the planes changed event
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            // Check if the plane is valid (subsumed by null) and horizontal
            if (plane.subsumedBy == null && plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
            {
                // Randomly spawn a shape object on the detected horizontal plane
                for(int i = 0; i < objCounter; i++)
                    SpawnRandomObject(plane);
            }
        }
    }

    void SpawnRandomObject(ARPlane plane)
    {
        // Randomly select a shape object
        GameObject selectedObject = shapeObjects[Random.Range(0, shapeObjects.Count)];

        // Instantiate the selected object on the detected plane
        GameObject spawnedObject = Instantiate(selectedObject, GetRandomPositionOnPlane(plane), Quaternion.identity);

        // Randomly select a color material
        /*Material selectedColor = colors[Random.Range(0, colors.Count)];

        // Assign the selected color material to the object's renderer
        Renderer[] renderers = spawnedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = selectedColor;
        }
        */
    }

    Vector3 GetRandomPositionOnPlane(ARPlane plane)
    {
        // Calculate a random position within the bounds of the detected plane
        Vector2 planeSize = plane.size;
        Vector3 planeCenter = plane.center;
        Vector3 randomPosition = planeCenter + new Vector3(Random.Range(-planeSize.x / 2, planeSize.x / 2), 0f, Random.Range(-planeSize.y / 2, planeSize.y / 2));

        return randomPosition;
    }
}