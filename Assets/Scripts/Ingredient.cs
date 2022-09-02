using System;
public class Ingredient
{
    public string name { get; }
    public double amount { get; set; }
    string unit { get; set; }

    public Ingredient(string name, double amount, string unit)
    {
        this.name = name;
        this.amount = amount;
        this.unit = unit;
    }
}
