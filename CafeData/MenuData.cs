using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MenuData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int ID { get; set; }
    public string Ingredients { get; set; }
    public MenuData(){}
    public MenuData(
        string name,
        string description,
        string ingredients,
        int menuNumber,
        double price
    )
    {
        Name = name;
        Description = description;
        Ingredients = ingredients;
        Price = price;
    }
}
