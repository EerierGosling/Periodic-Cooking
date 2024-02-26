using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to the prefab of the sprite you want to create
    public GameObject targetSprite; // Reference to the target sprite

    private GameObject newSprite; // Reference to the instantiated sprite
    private bool isDragging = false;
    private Vector2 offset;
    public string ingredient_name;

    public GameObject manager;

    private WinConditions script;

    void Start() {
        script = manager.GetComponent<WinConditions>();
    }

    void Update()
    {
        if (isDragging && newSprite != null)
        {
            // Update the position of the dragged sprite based on the mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newSprite.transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, newSprite.transform.position.z);
        }
    }

    void OnMouseDown()
    {
        // Instantiate a new sprite when the mouse is pressed
        newSprite = Instantiate(spritePrefab, transform.position, Quaternion.identity);

        newSprite.GetComponent<SpriteRenderer>().sortingOrder = script.numClones+10;

        // Set dragging flag to true and store the offset from the mouse to the original sprite's position
        isDragging = true;
        offset = newSprite.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        bool found_sprite = false;
        isDragging = false;

        // Check if the copy sprite is touching the specific target sprite
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newSprite.transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == targetSprite)
            {
                // Run another function when the copy sprite is dropped on the specific target sprite
                HandleDropOnTargetSprite();
                found_sprite = true;
                break;
            }
        }
        if (!found_sprite) {
            Destroy(newSprite);
        }
    }

    void HandleDropOnTargetSprite()
    {
        // Implement the logic you want for the copy sprite
        Debug.Log("Dropped on the target sprite! Copy sprite moved.");
        script = manager.GetComponent<WinConditions>();

        script.addedIngredients.Add(ingredient_name);
        script.OrderIngredients();
    }
}
