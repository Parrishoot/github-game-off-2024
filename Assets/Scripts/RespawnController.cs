using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [field:SerializeField]
    public Transform RespawnLocation { get; set; }

    [SerializeField]
    private GameObject respawnGameObject;
    
    [SerializeField]
    private new Rigidbody rigidbody;

    private bool respawnNextFixedUpdate = false;

    private Vector3? nextRespawnLocation;

    public void Start() {
        PlayerPackagePickupController.Instance.OnPackagePickup += UpdateRespawnLocation;
        SceneTransitionManager.Instance.OnTransitionOutFinished += Respawn;
    }

    public void UpdateRespawnLocation(PackageManager packageManager) {
        nextRespawnLocation = PlayerPackagePickupController.Instance.CurrentPackage.Manager.Quest.RespawnTransform.position;
    }


    public virtual void Respawn() {
        respawnNextFixedUpdate = true;
    }

    void FixedUpdate() {

        if(!respawnNextFixedUpdate) {
            return;
        }

        respawnNextFixedUpdate = false;
        respawnGameObject.transform.position =  nextRespawnLocation.HasValue ? nextRespawnLocation.Value : RespawnLocation.position;
        
    }

    void OnDestroy() {
        SceneTransitionManager.Instance.OnTransitionOutFinished -= Respawn;
    }
}
