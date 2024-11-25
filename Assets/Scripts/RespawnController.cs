using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [field:SerializeField]
    public Transform RespawnLocation { get; set; }

    [SerializeField]
    private GameObject respawnGameObject;

    public virtual Vector3 GetRespawnPosition() {
        return RespawnLocation.position;
    }

    public void Start() {
        SceneTransitionManager.Instance.OnTransitionOutFinished += Respawn;
    }

    public virtual void Respawn() {
        respawnGameObject.transform.position = GetRespawnPosition();
    }

    void OnDestroy() {
        SceneTransitionManager.Instance.OnTransitionOutFinished -= Respawn;
    }
}
