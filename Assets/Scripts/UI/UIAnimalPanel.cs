using TMPro;
using UnityEngine;

public class UIAnimalPanel : MonoBehaviour
{
    enum AnimalDetails
    {
        NameOnly,
        AllDetails
    }

    [Header("Animal UI Panel")]
    [SerializeField] private GameObject panel;

    [Header("Animal Text")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    void Start()
    {
        Hide();
    }

    private void Show()
    {
        if (panel != null) { panel.SetActive(true); }
    }

    public void Hide()
    {
        if (panel != null) {  panel.SetActive(false); }
    }

    /// <summary>
    /// Displays only the animal's name (sets description alpha to 0).
    /// </summary>
    public void ShowNameOnly()
    {
        if (nameText == null || descriptionText == null) { return; }

        nameText.alpha = 1.0f;
        descriptionText.alpha = 0.0f;

        Show();
    }

    /// <summary>
    /// Displays both the name and the full description.
    /// </summary>
    public void ShowAllDetails()
    {
        if (nameText == null || descriptionText == null) { return; }

        nameText.alpha = 1.0f;
        descriptionText.alpha = 1.0f;

        Show();
    }

    /// <summary>
    /// Updates the text content of the panel.
    /// </summary>
    public void SetText(string _animalName, string _animalDesc)
    {
        if (nameText != null) { nameText.text = _animalName; }
        if (descriptionText != null) {  descriptionText.text = _animalDesc; }
    }
}
