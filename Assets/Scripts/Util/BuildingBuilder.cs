using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{

    private const float SCALE = 1.5f;

    private const float BUILDING_SIZE_LENGTH = 6f * SCALE;
    private const float BUILDING_BASE_HEIGHT = 2.5f * SCALE;
    private const float BUILDING_MIDDLE_HEIGHT = 2f * SCALE;
    private const float BUILDING_TOP_HEIGHT = 1f * SCALE;

    [SerializeField]
    private BoxCollider bounds;

    [SerializeField]
    private GameObject piecesParent;

    [SerializeField]
    private GameObject buildingBasePrefab;

    [SerializeField]
    private GameObject buildingMiddlePrefab;
    
    [SerializeField]
    private GameObject buildingTopPrefab;

    public void UpdateBuildingHeight() {

        // Remove all pieces
        while ( piecesParent.transform.childCount > 0) {
            DestroyImmediate(piecesParent.transform.GetChild(0).gameObject);
        }

        Instantiate(buildingBasePrefab, piecesParent.transform);

        int numMiddlePieces = GetNumberOfMiddlePieces();

        for(int i = 0; i < numMiddlePieces; i++) {
            GameObject middle = Instantiate(buildingMiddlePrefab, piecesParent.transform);
            middle.transform.localPosition = new Vector3(0, i * BUILDING_MIDDLE_HEIGHT + BUILDING_BASE_HEIGHT, 0f);
        }

        GameObject top = Instantiate(buildingTopPrefab, piecesParent.transform);
        top.transform.localPosition = new Vector3(0f, numMiddlePieces * BUILDING_MIDDLE_HEIGHT + BUILDING_BASE_HEIGHT, 0f);

        transform.localScale = new Vector3(1f, GetSize(), 1f);
    }

    private void OnDrawGizmosSelected() {
        
        if(bounds == null) {
            Debug.LogWarning("Building bounds not assigned");
        }
        
        Color drawColor = Color.red;
        drawColor.a = .5f;
        Gizmos.color = drawColor;

        float size = GetSize();
        Gizmos.DrawCube(transform.position + (size / 2) * Vector3.up, new Vector3(BUILDING_SIZE_LENGTH * 1.01f, size, BUILDING_SIZE_LENGTH * 1.01f));
    }

    private float GetSize() {
        return GetNumberOfMiddlePieces() * BUILDING_MIDDLE_HEIGHT + (BUILDING_TOP_HEIGHT + BUILDING_BASE_HEIGHT); 
    }

    private int GetNumberOfMiddlePieces() {
        return (int) Mathf.Floor(Mathf.Max(0f, GetHeight() - BUILDING_BASE_HEIGHT - BUILDING_TOP_HEIGHT) / BUILDING_MIDDLE_HEIGHT);
    }

    private float GetMinimumSize() {
        return BUILDING_BASE_HEIGHT + BUILDING_TOP_HEIGHT;
    }

    private float GetHeight() {
        return bounds.size.y * transform.localScale.y;
    }
}
