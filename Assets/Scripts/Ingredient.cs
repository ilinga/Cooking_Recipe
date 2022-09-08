using System;
public class Ingredient
{
    public string name { get; }
    public double amount { get; set; }
    public string unit { get; set; }

    public AnimationType animation { get; set; }

    //TODO public bool seperateUnitFromAmountWithSpace { get; }

    public Ingredient(string name, double amount, string unit, AnimationType animation)
    {
        this.name = name;
        this.amount = amount;
        this.unit = unit;
        this.animation = animation;
    }
}
