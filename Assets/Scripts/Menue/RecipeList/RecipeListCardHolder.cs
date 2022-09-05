using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeListCardHolder: MonoBehaviour
{

    public GameObject recipeCardPrefab;

    private int page = 1;

    public int size = 3;
    // Start is called before the first frame update
    void Start()
    {
        showPage(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showPage(int page)
    {
        var cards = RecipeList.getPage(page, size);
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            var cardObj = Instantiate(recipeCardPrefab, transform) as GameObject;
            cardObj.SendMessage("setContent", (page-1)*size+i);
        }

        updateButtonStates();
    }

    public void nextPage() { 
        if (ListUtil.getPages<IRecipe>(RecipeList.getAll(),size) >= page + 1) 
        { 
            showPage(++page); 
        }
        updateButtonStates();
    }
    public void prevPage() { 
        if (page > 1) { 
            showPage(--page); 
        }
        updateButtonStates();

    }

    public void updateButtonStates()
    {
        transform.parent.Find("Previous page").GetComponent<Button>().interactable = page == 1 ? false : true;
        transform.parent.Find("Next page").GetComponent<Button>().interactable = page == ListUtil.getPages<IRecipe>(RecipeList.getAll(), size) ? false : true;
    }
}
