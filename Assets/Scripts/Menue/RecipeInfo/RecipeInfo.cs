using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecipeInfo: MonoBehaviour
{

    public GameObject ingredientPrefab;

    private int ingrediantPage = 1;

    public int ingrediantSize = 9;
    private IRecipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        setContent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showPage(int page)
    {
        var cards = ListUtil.getPage<Ingredient>(new List<Ingredient>(recipe.Ingredients.Values),page, ingrediantSize);
        foreach (Transform child in transform.Find("Ingredient list")) {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            var cardObj = Instantiate(ingredientPrefab, transform.Find("Ingredient list")) as GameObject;
            cardObj.SendMessage("setContent", cards[i]);
        }
        transform.Find("Ingredient page").GetComponent<TMPro.TextMeshPro>().text = ingrediantPage.ToString() + "/" + ListUtil.getPages<Ingredient>(new List<Ingredient>(recipe.Ingredients.Values), ingrediantSize).ToString();
    }

    void setContent(IRecipe data)
    {
        if (data is null)
        {
            recipe = RecipeList.Recipes[RecipeList.selectedRecipeNo];
        }
        else
        {
            recipe = data;
        }


        transform.Find("Name").GetComponent<TMPro.TextMeshPro>().text = recipe.Name;
        transform.Find("Duration").GetComponent<TMPro.TextMeshPro>().text = recipe.Duration < 60 ? recipe.Duration + " minutes" : Math.Round(Mathf.Ceil((float)recipe.Duration / 15) / 4, 2) + " hours";
        transform.Find("Difficulty").GetComponent<TMPro.TextMeshPro>().text = (recipe.Difficulty == Difficulty.EASY ? "1" : recipe.Difficulty == Difficulty.MEDIUM ? "2" : "3") + "/3";
        transform.Find("Participants no").GetComponent<TMPro.TextMeshPro>().text = recipe.Participants.ToString();
        transform.Find("Ingredient page").GetComponent<TMPro.TextMeshPro>().text = ingrediantPage.ToString() + "/" + ListUtil.getPages<Ingredient>(new List<Ingredient>(recipe.Ingredients.Values), ingrediantSize).ToString();

        var picture = Resources.Load("RecipePictures\\" + recipe.ImageName) as Texture2D;
        if (!(picture is null))
        {
            transform.Find("Picture").GetComponent<MeshRenderer>().material.mainTexture = picture;
        }

        showPage(ingrediantPage);
    }

    public void nextPage() { 
        if (ListUtil.getPages<Ingredient>(new List<Ingredient>(recipe.Ingredients.Values), ingrediantSize) >= ingrediantPage + 1) {
            showPage(++ingrediantPage); 
        } 
    }
    public void prevPage() { 
        if (ingrediantPage > 1) { 
            showPage(--ingrediantPage); 
        } 
    }

    public void moreParticipants()
    {
        recipe.Participants = recipe.Participants + 1;
        setContent(recipe);
    }
    public void lessParticipants()
    {
        if (recipe.Participants > 1)
        {
            recipe.Participants = recipe.Participants - 1;
            setContent(recipe);
        }
    }

    public void returnToRecipeList()
    {
        SceneManager.LoadScene("Recipe_Selector",LoadSceneMode.Single);
    }

    public void startCooking()
    { 
        SceneManager.LoadScene("Cooking_Recipe_Project", LoadSceneMode.Single);
    }
}
