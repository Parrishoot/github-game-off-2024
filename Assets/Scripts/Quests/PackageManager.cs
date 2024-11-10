using UnityEngine;
using DG.Tweening;
using System;

public class PackageManager : MonoBehaviour
{
    [SerializeField]
    private new Rigidbody rigidbody;

    [SerializeField]
    private GameObject packageModelGameObject;

    [Header("Initial Fling")]
    [SerializeField]
    [Range(0, 1)]
    private float spawnFlingSpread = .2f; 

    [SerializeField]
    private float spawnFlingForce;

    [SerializeField]
    private float spawnFlingTorque;

    [SerializeField]
    private float spawnScaleSpeed = .5f;

    [SerializeField]
    private PackageInteractable interactable;

    public Action OnPickup { get; set; }

    public Action OnDrop { get; set; }

    public Action OnSpotted { get; set; }

    void Start()
    {
        interactable.OnPickup += () => OnPickup?.Invoke();

        packageModelGameObject.transform.localScale = Vector3.zero;
        packageModelGameObject.transform.DOScale(Vector3.one, spawnScaleSpeed).SetEase(Ease.InOutCubic);

        // When we first spawn the package, fling it in the air a little
        Vector3 flingVector = new Vector3(
            UnityEngine.Random.Range(-spawnFlingSpread, spawnFlingSpread),
            1f,
            UnityEngine.Random.Range(-spawnFlingSpread, spawnFlingSpread)
        );

        rigidbody.AddForce(flingVector * spawnFlingForce, ForceMode.Impulse);
        rigidbody.AddTorque(flingVector * spawnFlingTorque, ForceMode.Impulse);    
    }

    public void DeliverPackage() {
        // TODO: ADD REAL LOGIC HERE
        OnSpotted?.Invoke();
        Destroy(gameObject);
    }
}
