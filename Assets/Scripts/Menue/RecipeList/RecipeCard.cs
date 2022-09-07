using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecipeCard : MonoBehaviour
{

    private IRecipe data;

    /// <summary>
    /// index of recipe in RecipeList
    /// </summary>
    private int idx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setContent(int idx)
    {
        data = RecipeList.Recipes[idx];
        this.idx = idx;
        transform.Find("Name").GetComponent<TMPro.TextMeshPro>().text = data.Name;
        transform.Find("Duration").GetComponent<TMPro.TextMeshPro>().text = data.Duration < 60 ? data.Duration + " minutes" : Math.Round(Mathf.Ceil((float)data.Duration / 15) / 4,2) + " hours";
        transform.Find("Difficulty").GetComponent<TMPro.TextMeshPro>().text = (data.Difficulty == Difficulty.EASY? "1": data.Difficulty == Difficulty.MEDIUM ? "2": "3") +"/3";

        var picture = Resources.Load("RecipePictures\\" + data.ImageName) as Texture2D;
        if (!(picture is null)) {
            transform.Find("Picture").GetComponent<MeshRenderer>().material.mainTexture = picture;
        }
    }

    public void openDetails()
    {
        RecipeList.selectedRecipeNo = idx;
        SceneManager.LoadScene("Recipe_Detail", LoadSceneMode.Single);
    }

}
