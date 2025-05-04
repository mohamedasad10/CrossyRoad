// This script is attached to the terrain generator which generates the different segments of the game

using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    // Array to store the three segment prefabs
    public GameObject[] segmentPrefabs;  // Prefabs for all three segments (e.g., Segment 1, Segment 2, Segment 3)
    public int numberOfSegments = 20;  // Total number of segments to generate

    private float currentZ = 0f;  // Current Z position for segment placement

    void Start()
    {
        GenerateSegments();
    }

    void GenerateSegments()
    {
        // Loop through to generate all segments
        for (int i = 0; i < numberOfSegments; i++)
        {
            // Randomly select a segment prefab from the array (Segment 1, Segment 2, or Segment 3)
            int prefabIndex = Random.Range(0, segmentPrefabs.Length);  // Randomly select between 0, 1, and 2
            GameObject prefabToUse = segmentPrefabs[prefabIndex];

            // Dynamically calculate the segment length (Z-axis) of the selected prefab
            float segmentLength = GetPrefabLengthZ(prefabToUse);

            // Calculate the spawn position based on the current Z value
            Vector3 spawnPos = new Vector3(0, 0, currentZ);

            // Instantiate the selected prefab at the calculated position
            Instantiate(prefabToUse, spawnPos, Quaternion.identity);

            // Update the current Z value for the next segment's spawn position
            currentZ += segmentLength;
        }
    }

    // Dynamically calculates the prefab length in the Z direction
    float GetPrefabLengthZ(GameObject prefab)
    {
        // Temporarily instantiate the prefab to measure its bounds
        GameObject temp = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        Renderer[] renderers = temp.GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
        {
            Debug.LogWarning("No Renderers found in prefab.");
            Destroy(temp);
            return 1f; // Fallback
        }

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer r in renderers)
            bounds.Encapsulate(r.bounds);

        float lengthZ = bounds.size.z;

        Destroy(temp); // Clean up the temporary prefab
        return lengthZ;
    }
}
