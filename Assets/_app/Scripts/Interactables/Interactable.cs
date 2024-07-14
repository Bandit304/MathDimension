using UnityEngine;

namespace _app.Scripts.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        //Add or remove an InteractionEvent component to this gameObject.
        public bool useEvents;
        public string promptMessage;

        public void BaseInteract()
        {
            if (useEvents)
            {
                GetComponent<InteractionEvent>().OnInteract.Invoke();
            }
            Interact();
        }
        protected virtual void Interact()
        {
        
        }
    }
}
