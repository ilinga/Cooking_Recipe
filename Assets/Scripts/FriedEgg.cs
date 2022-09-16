using System;
using System.Collections.Generic;

public class FriedEgg:IRecipe
{
    private int _participants;

    public FriedEgg(int participants)
    {
        this._participants = participants;
        CreateIngredients();
        CreateCookingSteps();
    }

    private Dictionary<string, Ingredient> CreateIngredients()
    {
        Dictionary<string, Ingredient> ingredients = new Dictionary<string, Ingredient>();
        ingredients.Add(GameObjects.PAN, new Ingredient("Pan", 1, "",false, AnimationType.DROP));
        ingredients.Add(GameObjects.BUTTER, new Ingredient("Butter", 30, "g", false,AnimationType.DROP));
        ingredients.Add(GameObjects.EGG, new Ingredient("Eggs", 2*Participants, "", true,AnimationType.DROP));
        ingredients.Add(GameObjects.SALT, new Ingredient("Salt", 2, "pinches", true, AnimationType.ROTATE_VERTICAL));
        ingredients.Add(GameObjects.PEPPER, new Ingredient("Pepper", 2, "pinches", true, AnimationType.ROTATE_VERTICAL));
        return ingredients;
    }



    public List<CookingStep> CookingSteps = null;



    public string Name => "Fried eggs";

    public Difficulty Difficulty => Difficulty.EASY;

    public int Duration => 15;


    public int Participants { get => _participants; set => _participants = value; }

    public void updateParticipants(int Participants)
    {
        this.Participants = Participants;
        CreateIngredients();
        CreateCookingSteps();
    }

    private void CreateCookingSteps()
    {
        this.CookingSteps = new List<CookingStep>(){
        new CookingStep(GameObjects.PAN, new List<string> { GameObjects.BUTTER }, "Put butter in pan and heat the pan. Use at most two thirds of the maximum power of the heating plate."),
        new CookingStep(GameObjects.PAN, new List<string> { GameObjects.EGG }, "When the pan is heated, break the eggs and add their content to the pan."),
        new CookingStep(GameObjects.PAN, new List<string> { GameObjects.SALT, GameObjects.PEPPER}, "When the surface of the fried eggs is firm, spice the fried eggs with salt and pepper. Continue until the desired firmness has been reached."),
    };
    }

    public Dictionary<string, Ingredient> Ingredients => CreateIngredients();

    public string ImageName => "fried_egg";

    List<CookingStep> IRecipe.CookingSteps => CookingSteps;
}
