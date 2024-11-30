using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

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

    public Action OnPickup { get; set; }

    public Action OnDrop { get; set; }

    public Action OnSpotted { get; set; }

    public Action OnLost { get; set; }

    public QuestController Quest { get; set; }

    void Start()
    {
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

        if(!gameObject.IsDestroyed()) {
            Destroy(gameObject);
        }
    }

    public void Lose() {
        OnLost?.Invoke();
    }
}
