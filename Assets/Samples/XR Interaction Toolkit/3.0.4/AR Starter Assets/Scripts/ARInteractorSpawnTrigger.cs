#if AR_FOUNDATION_PRESENT
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.ARStarterAssets
{
    /// <summary>
    /// Spawns an object at an <see cref="IARInteractor"/>'s raycast hit position when a trigger is activated.
    /// </summary>
    public class ARInteractorSpawnTrigger : MonoBehaviour
    {

        [SerializeField]
        XRInputButtonReader m_SpawnObjectInput = new XRInputButtonReader("Spawn Object");

        /// <summary>
        /// The input used to trigger spawn, if <see cref="spawnTriggerType"/> is set to <see cref="SpawnTriggerType.InputAction"/>.
        /// </summary>
        public XRInputButtonReader spawnObjectInput
        {
            get => m_SpawnObjectInput;
            set => XRInputReaderUtility.SetInputProperty(ref m_SpawnObjectInput, value, this);
        }
        
        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        void OnEnable()
        {
            m_SpawnObjectInput.EnableDirectActionIfModeUsed();
        }

        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        void OnDisable()
        {
            m_SpawnObjectInput.DisableDirectActionIfModeUsed();
        }
        
    }
}
#endif
