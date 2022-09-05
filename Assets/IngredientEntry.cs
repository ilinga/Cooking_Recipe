using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setContent(Ingredient data)
    {
        transform.Find("Ingredient").GetComponent<TMPro.TextMeshPro>().text = data.name;
        transform.Find("Amount").GetComponent<TMPro.TextMeshPro>().text = data.amount + data.unit;
    }
}
