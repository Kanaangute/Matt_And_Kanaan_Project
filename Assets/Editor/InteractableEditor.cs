//kanaan gute 12/10/24
using Unity.VisualScripting;
using UnityEditor;

[CustomEditor(typeof(Interactable),true)] // This tells Unity to use this custom editor for all objects of type 'Interactable' and any of its subclasses.
public class InteractableEditor : Editor // Custom editor class that inherits from Unity's Editor class.
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        // Check if the target object is of type 'Interactable'.
        if (target.GetType() == typeof(Interactable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            // Display a Help Box
            EditorGUILayout.HelpBox("EventOnlyInteract can Only use UnityEvents.", MessageType.Info);
            // Check if the 'InteractionEvent' component is missing from the object, add it if it is.
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }

        }
        else // If the target object is not of type 'Interactable'
        {
            base.OnInspectorGUI(); // Calls the base class 
            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                    interactable.gameObject.AddComponent<InteractionEvent>();
            }
            else // If 'useEvents' is disabled.
            {
                if (interactable.GetComponent<InteractionEvent>() != null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());

            }

        }   
    
    }
    

}
