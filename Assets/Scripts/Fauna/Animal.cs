using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum InspectionState
    {
        NotInspected,
        Inspected
    }

    [Header("Animal Properties")]
    [SerializeField] protected string animalName = "Animal";
    [SerializeField] [TextArea] protected string animalDescription = "This is an Animal";

    [SerializeField] protected bool canBeInspected = true;

    protected InspectionState inspectionState = InspectionState.NotInspected;

    /// <summary>
    /// Called when the player enters the interaction range.
    /// Shows the animal's name on the UI.
    /// </summary>
    public virtual void OnSighting(UIAnimalPanel _uiPanel)
    {
        _uiPanel.SetText(animalName, animalDescription);
        _uiPanel.ShowNameOnly();
    }

    /// <summary>
    /// Called when the player actively interacts with the animal (e.g., presses 'E').
    /// Shows full animal details and marks as inspected.
    /// </summary>
    public virtual void OnInspect(UIAnimalPanel _uiPanel)
    {
        if (!canBeInspected) return;

        inspectionState = InspectionState.Inspected;

        _uiPanel.ShowAllDetails();
        Debug.Log($"{animalName} has been fully inspected.");
    }

    /// <summary>
    /// Called when the player leaves the interaction range.
    /// Hides the UI panel.
    /// </summary>
    public virtual void OnLeaveSighting(UIAnimalPanel _uiPanel)
    {
        _uiPanel.Hide();
    }

    public InspectionState GetInspectionState()
    {
        return inspectionState;
    }
}
