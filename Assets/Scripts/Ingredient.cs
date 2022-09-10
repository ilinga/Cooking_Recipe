using System;
public class Ingredient
{
    public string name { get; }
    public double amount { get; set; }
    public string unit { get; set; }

    public AnimationType animation { get; set; }

    public bool seperateUnitFromAmountWithSpace { get; }

    public Ingredient(string name, double amount, string unit, bool seperateUnitFromAmountWithSpace, AnimationType animation)
    {
        this.name = name;
        this.amount = amount;
        this.unit = unit;
        this.animation = animation;
        this.seperateUnitFromAmountWithSpace = seperateUnitFromAmountWithSpace;
    }

    public String getAmountString()
    {
        return amount.ToString() + ((seperateUnitFromAmountWithSpace && !(unit is null) && unit.Length > 0) ? " " : "") + (!(unit is null)?unit:"");
    }
}
