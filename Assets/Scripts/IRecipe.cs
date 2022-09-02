using System;
using System.Collections.Generic;

public interface IRecipe
{

    public string Name { get; }

    public Difficulty Difficulty { get; }

    public int Duration { get; }

    public Dictionary<string, Ingredient> Ingredients { get; }

    public List<CookingStep> CookingSteps { get; }

    public int Participants { get; set; }

}
