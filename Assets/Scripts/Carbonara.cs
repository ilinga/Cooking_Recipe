using System;
using System.Collections.Generic;

public class Carbonara:IRecipe
{
    private int _participants;

    public Carbonara(int participants)
    {
        this._participants = participants;
    }

    private Dictionary<string, Ingredient> CreateIngredients()
    {
        Dictionary<string, Ingredient> ingredients = new Dictionary<string, Ingredient>();
        // 400g Spaghetti für 4 Personen --> 100g pro Person
        ingredients.Add("spaghetti", new Ingredient("Spaghetti", 100 * Participants, "g"));
        // 200g Speckwürfel für 4 Personen --> 50g pro Person
        ingredients.Add("bacon cubes", new Ingredient("Bacon cubes", 50 * Participants, "g"));
        // 4 Eier für 4 Personen --> 1 Ei pro Person
        ingredients.Add("eggs", new Ingredient("Eggs", 1 * Participants, ""));
        // 50g Butter für 4 Personen --> 12,5g pro Person
        ingredients.Add("butter", new Ingredient("Butter", (12.5 * Participants), "g"));
        // salt
        ingredients.Add("salt", new Ingredient("Salt", 1, ""));
        // pepper
        ingredients.Add("pepper", new Ingredient("Pepper", 1, ""));
        // 1 Prise Muskatpulver für 4 Personen --> 1/4 Prise pro Person
        ingredients.Add("nutmeg powder", new Ingredient("Nutmeg powder", (0.25 * Participants), "pinch"));
        // 100g Parmesan für 4 Personen --> 25g pro Person
        ingredients.Add("parmesan", new Ingredient("Parmesan", (25 * Participants), "g"));

        return ingredients;
    }


    private List<string> GetCookingSteps()
    {
        List<string> steps = new List<string>();

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
        steps.Add("Now noodles have to be cooked. Put water in a deep pan and boil water.");
        steps.Add("When the water boils put the spagetti inside the deep pan.");
        steps.Add("Wait about 10 minutes and stir every now and then.");
        steps.Add("Drain the pasta");
        steps.Add("Put the spagetti inside the bowl with the egg yolk and mix well.");
        steps.Add("Done! Bon Appetit!");

        return steps;
    }




    public string Name => "Spargetti Carbonara";

    public Difficulty Difficulty => Difficulty.EASY;

    public int Duration => 20;

    public List<string> CookingSteps => GetCookingSteps();

    public int Participants { get => _participants; set => _participants = value; }

    public Dictionary<string, Ingredient> Ingredients => CreateIngredients();
}
