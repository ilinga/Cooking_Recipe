using System;
using System.Collections.Generic;

public class Carbonara:IRecipe
{
    private int _participants;

    private Dictionary<string, Ingredient> _ingrediants;
    private List<CookingStep> _cookingSteps;

    public string Name => "Spargetti Carbonara";

    public Difficulty Difficulty => Difficulty.EASY_MEDIUM;

    public int Duration => 20;

    public List<CookingStep> CookingSteps => _cookingSteps;

    public int Participants { get => _participants; set => _participants = value; }

    public Dictionary<string, Ingredient> Ingredients => CreateIngredients();

    public string ImageName => "carbonara";

    public Carbonara(int participants)
    {
        this._participants = participants;
        CreateIngredients();
        CreateCookingSteps();
    }

    private Dictionary<string, Ingredient> CreateIngredients()
    {
        _ingrediants = new Dictionary<string, Ingredient>();
        // 400g Spaghetti für 4 Personen --> 100g pro Person
        _ingrediants.Add(GameObjects.SPAGHETTI, new Ingredient("Spaghetti", 100 * Participants, "g", AnimationType.DROP));
        // 200g Speckwürfel für 4 Personen --> 50g pro Person
        _ingrediants.Add(GameObjects.BACON_CUBES, new Ingredient("Bacon cubes", 50 * Participants, "g", AnimationType.DROP));
        // 4 Eier für 4 Personen --> 1 Ei pro Person
        _ingrediants.Add(GameObjects.EGG, new Ingredient("Eggs", 1 * Participants, "", AnimationType.DROP));
        // 50g Butter für 4 Personen --> 12,5g pro Person
        _ingrediants.Add(GameObjects.BUTTER, new Ingredient("Butter", (12.5 * Participants), "g", AnimationType.DROP));
        // salt
        _ingrediants.Add(GameObjects.SALT, new Ingredient("Salt", 1, "", AnimationType.ROTATE_VERTICAL));
        // pepper
        _ingrediants.Add(GameObjects.PEPPER, new Ingredient("Pepper", 1, "", AnimationType.ROTATE_VERTICAL));
        // 1 Prise Muskatpulver für 4 Personen --> 1/4 Prise pro Person
        _ingrediants.Add(GameObjects.NUTMEG, new Ingredient("Nutmeg powder", (0.25 * Participants), "pinch", AnimationType.ROTATE_VERTICAL));
        // 100g Parmesan für 4 Personen --> 25g pro Person
        _ingrediants.Add(GameObjects.PARMESAN, new Ingredient("Parmesan", (25 * Participants), "g", AnimationType.ROTATE_VERTICAL));
        // spoon
        _ingrediants.Add(GameObjects.SPOON, new Ingredient("Spoon", 1, "", AnimationType.MOVE_IN_CIRCLE));
        // olive_oil
        _ingrediants.Add(GameObjects.OLIVE_OIL, new Ingredient("Olive oil", 1, "", AnimationType.ROTATE_VERTICAL));
        return _ingrediants;
    }


    private void CreateCookingSteps()
    {
        _cookingSteps = new List<CookingStep>();

        _cookingSteps.Add(new CookingStep(GameObjects.PAN, new List<string> { GameObjects.OLIVE_OIL }, "Put olive oil in pan"));
        //TODO: BACON_CUBES
        _cookingSteps.Add(new CookingStep(GameObjects.PAN, new List<string> { GameObjects.NUTMEG }, "Put Bacon cubes in pan and then sear them"));

        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.EGG }, "Seperate eggs and put egg yolk in the bowl"));
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.SALT, GameObjects.PEPPER, GameObjects.NUTMEG }, "Add salt, pepper and " + Ingredients[GameObjects.NUTMEG].amount.ToString() + " pinches of nutmeg powder to egg yolk"));
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.SPOON }, "Whisk everything"));
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.BUTTER }, "Add " + Ingredients[GameObjects.BUTTER].amount.ToString() + "g butter to egg yolk"));
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.SPOON }, "Cream butter and mix well with egg yolks"));
        //TODO: BACON_CUBES
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.PARMESAN }, "Add bacon cubes and parmesan"));
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.SPOON }, "Whisk everything"));

        _cookingSteps.Add(new CookingStep(GameObjects.DEEPPAN, new List<string> { GameObjects.OLIVE_OIL }, "Now noodles have to be cooked.Put water in a deep pan and boil water."));
        _cookingSteps.Add(new CookingStep(GameObjects.DEEPPAN, new List<string> { GameObjects.SPAGHETTI }, "When the water boils put the spagetti inside the deep pan."));
        _cookingSteps.Add(new CookingStep(GameObjects.DEEPPAN, new List<string> { GameObjects.SPOON }, "Wait about 10 minutes and stir every now and then."));

        _cookingSteps.Add(new CookingStep(GameObjects.BOWL, new List<string> { GameObjects.SPAGHETTI_COOKED }, "Put the spagetti inside the bowl with the egg yolk."));
        _cookingSteps.Add(new CookingStep(GameObjects.BOWL_WITH_SPAGHETTI, new List<string> { GameObjects.SPOON }, "Mix well."));





        /*
        steps.Add("Put olive oil in pan");
        steps.Add("Bacon cubes in pan");
        steps.Add("Bacon cubes sear"); // sear = anbraten
        steps.Add("Seperate eggs(Wenn dieser Schritt auftaucht, Extraoption.Schwebendes Fragezeichen, falls ja, wird der Nutzer auf ein Unterprogramm umgeleitet, das erklärt, wie man Eier trennt)");

        steps.Add("Put egg yolk in bowl"); // Egg yolk = Eigelb
        steps.Add("Add salt, pepper and " + Ingredients["nutmeg powder"].amount.ToString() + " pinches of nutmeg powder to egg yolk");
        steps.Add("Whisk"); // Whisk = Verquirlen 
        steps.Add("Add " + Ingredients["butter"].amount.ToString() + "g butter to egg yolk");
        steps.Add("Cream butter and mix well with egg yolks");
        steps.Add("Add bacon cubes and parmesan");
        steps.Add("Whisk");
        //TODO wasser salzen
        steps.Add("Now noodles have to be cooked. Put water in a deep pan and boil water.");
        steps.Add("When the water boils put the spagetti inside the deep pan.");
        steps.Add("Wait about 10 minutes and stir every now and then.");
        steps.Add("Drain the pasta");
        steps.Add("Put the spagetti inside the bowl with the egg yolk and mix well.");
        steps.Add("Done! Bon Appetit!");
        */
    }
}
