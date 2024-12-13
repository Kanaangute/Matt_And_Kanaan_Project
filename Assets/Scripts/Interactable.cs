//Kanaan Gute 12/09/24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    // The prompt message that will be displayed to the player when interacting.
    
    public string promptMessage;
    //called to handle the interaction.
    public void BaseInteract()
    {
        if (useEvents) // If useEvents is enabled, teh OnInteract is called
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {


    }




}
