using System;
using System.Collections.Generic;

public static class RecipeList
{
    public static List<IRecipe> Recipes = new List<IRecipe>() { new Carbonara(1), new FriedEgg(1) };

    /// <summary>
    /// denotes which recipe should be shown in Scene "Recipe_Detail"
    /// index of recipe in Recipes list
    /// </summary>
    public static int selectedRecipeNo = 0;

    /// <summary>
    /// Returns a subset of the recipes
    /// </summary>
    /// <param name="page">which page, starting from 1</param>
    /// <param name="size">how many recipes each page</param>
    /// <returns>recipes on the page, else empty list</returns>
    public static List<IRecipe> getPage(int page, int size)
    {
        return ListUtil.getPage<IRecipe>(RecipeList.Recipes, page, size);
    }


    public static List<IRecipe> getAll() { return RecipeList.Recipes; }

}
