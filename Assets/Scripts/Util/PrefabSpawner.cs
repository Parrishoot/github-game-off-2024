using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public GameObject Spawn() {
        return Instantiate(prefab, transform.position, Quaternion.identity); 
    }
}
