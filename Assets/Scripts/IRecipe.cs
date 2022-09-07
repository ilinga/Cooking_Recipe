using System;
using System.Collections.Generic;

public interface IRecipe
{

    public string Name { get; }

    public Difficulty Difficulty { get; }

    /// <summary>
    /// name of picture for recipe located in Assets\Resources\RecipePictures
    /// </summary>
    public string ImageName { get; }

    /// <summary>
    /// Time in minutes
    /// </summary>
    public int Duration { get; }

    public Dictionary<string, Ingredient> Ingredients { get; }

    public List<CookingStep> CookingSteps { get; }

    public int Participants { get; set; }

    
}
