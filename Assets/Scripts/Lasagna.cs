using System;
using System.Collections.Generic;

public class Lasagna:IRecipe
{
    private int _participants;

    public Lasagna(int participants)
    {
        this._participants = participants;
    }

    private Dictionary<string, Ingredient> CreateIngredients()
    {
        Dictionary<string, Ingredient> ingredients = new Dictionary<string, Ingredient>();
        ingredients.Add("lasagna plates", new Ingredient("Lasagna plates", 100 * Participants, "g", AnimationType.DROP));
        ingredients.Add("minced meat", new Ingredient("Minced meat", 250 * Participants, "g", AnimationType.DROP));
        ingredients.Add("salt", new Ingredient("Salt", 1, "", AnimationType.DROP));
        return ingredients;
    }



    public List<CookingStep> CookingSteps => new List<CookingStep>(){new CookingStep(GameObjects.PAN, new List<string> { GameObjects.OLIVE_OIL }, "Put olive oil in pan")};



    public string Name => "Lasagna";

    public Difficulty Difficulty => Difficulty.MEDIUM;

    public int Duration => 130;


    public int Participants { get => _participants; set => _participants = value; }

    public Dictionary<string, Ingredient> Ingredients => CreateIngredients();

    public string ImageName => "lasagna";
}
