using System;
using System.Collections.Generic;
using ThirdPartySDK;

public class ShoppingCart
{
    public static List<Product> Items = new List<Product>();

    // From ThirdPartySDK
    private InventoryService _inventoryService;

    public ShoppingCart()
    {
        _inventoryService = new InventoryService(); 
    }

    public void AddBookToCart(Product book)
    {

        if (_inventoryService.CheckInventory(book.Name) > 0)
        {
            double discount = CalculateDiscount("Book", book.Price);
            book.Price -= discount;
            Items.Add(book);
        }
    }

    public void AddCDToCart(Product cd)
    {
        if (_inventoryService.CheckInventory(cd.Name) > 0)
        {
            var discount = CalculateDiscount("CD", cd.Price);
            cd.Price -= discount;
            Items.Add(cd);
        }
    }

    private double CalculateDiscount(string productType, double price, int quantity)
    {
        double discountRate = 0;

        switch (productType)
        {
            case "Book":
                discountRate = 0.1;
                discountAfterQty = 2;
                break;
            case "CD":
                discountRate = 0.15;
                discountAfterQty = 5;
                break;
        }

        return price * discountRate;
    }
}

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int ItemType { get; set; }
}

public enum ItemType
{
    Digital,
    Physical
}
