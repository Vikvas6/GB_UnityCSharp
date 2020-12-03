
using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {

        #region Properties

        public bool IsInteractable { get; } = true;

        #endregion

        #region UnityMethods

        private void Start()
        {
            Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interact();
            Destroy(gameObject);
        }

        #endregion

        #region Methods

        protected abstract void Interact();
        
        public override string ToString()
        {
            return $"I am a {nameof(InteractiveObject)} class method";
        }

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                //renderer.material.color = Random.ColorHSV();
            }
        }

        #endregion

    }
}