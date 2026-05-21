using UnityEngine;

public enum GamePhase
{
    Ingredients,
    Prep,
    Cooking,
    Delivery,
    Finished
}

public enum ZoneType
{
    Kitchen,
    Front,
    ServicePass
}

public enum StationType
{
    Ingredient,
    Prep,
    Cooking,
    Delivery
}

public enum PlayerRole
{
    Unassigned,
    Kitchen,
    Front
}

// TODO: Maybe put this as a ScriptableObject or something instead of an enum, so we can add more data to it
// if not, add  ingredients as wanted to the enum, so we can use it in the UI and stuff
public enum IngredientType
{
    Tomato,
    Onion,
    Fish,
    Rice,
    Unknown
}
