using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance { get; private set; }

    [SerializeField] private IngredientType requiredIngredient = IngredientType.Tomato;

    public IngredientType RequiredIngredient => requiredIngredient;

    private void Awake()
    {
        Instance = this;
    }

    public bool IsCorrectIngredient(IngredientType ingredient)
    {
        return ingredient == requiredIngredient;
    }
}