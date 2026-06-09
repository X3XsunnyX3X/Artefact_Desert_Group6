using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UIAnimalPanel uiPanel;
    [SerializeField] private LayerMask animalLayer;

    private Animal hoveredAnimal = null;
    private Animal selectedAnimal = null;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        
        if (uiPanel == null)
        {
            // Using FindObjectOfType for better compatibility across Unity versions
            uiPanel = Object.FindFirstObjectByType<UIAnimalPanel>();
        }
    }

    void Update()
    {
        HandleHover();
        HandleClick();
    }

    private void HandleHover()
    {
        // If we have a selected animal (details showing), we don't change hover state
        if (selectedAnimal != null) return;

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos, animalLayer);

        if (hit != null && hit.TryGetComponent(out Animal animal))
        {
            if (hoveredAnimal != animal)
            {
                // New animal hovered
                if (hoveredAnimal != null) hoveredAnimal.OnLeaveSighting(uiPanel);
                
                hoveredAnimal = animal;
                hoveredAnimal.OnSighting(uiPanel);
            }
        }
        else
        {
            // Hovered over nothing
            if (hoveredAnimal != null)
            {
                hoveredAnimal.OnLeaveSighting(uiPanel);
                hoveredAnimal = null;
            }
        }
    }

    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos, animalLayer);

            if (hit != null && hit.TryGetComponent(out Animal animal))
            {
                // Clicked on an animal
                if (selectedAnimal != null && selectedAnimal != animal)
                {
                    // If we had another one selected, hide it first
                    selectedAnimal.OnLeaveSighting(uiPanel);
                }

                selectedAnimal = animal;
                selectedAnimal.OnInspect(uiPanel);

                hoveredAnimal = null; // Selection takes priority over hover
            }
            else
            {
                // Clicked on empty space
                if (selectedAnimal != null)
                {
                    selectedAnimal.OnLeaveSighting(uiPanel);
                    selectedAnimal = null;
                }
            }
        }
    }
}
