using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private IInteractable nextInteractable = null;

    private void OnTriggerEnter(Collider other) {
        
        IInteractable interactable = other.GetComponent<IInteractable>();

        if(interactable != null) {
            nextInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other) {
        
        IInteractable interactable = other.GetComponent<IInteractable>();

        if(interactable != null && nextInteractable != null && nextInteractable.Equals(interactable)) {
            nextInteractable = null;
        }
    }

    private void Update() {

        // TODO: Map this to actual input
        if(Input.GetKeyDown(KeyCode.E)) {
            nextInteractable?.Interact();
        }
    }
}
