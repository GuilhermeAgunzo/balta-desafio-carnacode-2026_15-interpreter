// DESAFIO: Sistema de Regras de Desconto Dinâmicas
// PROBLEMA: Um e-commerce precisa avaliar regras complexas de desconto escritas em formato
// texto (ex: "Se quantidade > 10 E valor > 1000 ENTÃO desconto 15%"). O código atual
// usa muitos if/else e não permite que regras sejam configuradas dinamicamente

using Interpreter.Models;
using Interpreter.Parsers;

Console.WriteLine("=== Sistema de Regras de Desconto ===\n");

var cart1 = new ShoppingCart
{
    TotalValue = 1500.00m,
    ItemQuantity = 15,
    CustomerCategory = "Regular",
    IsFirstPurchase = false
};

var cart2 = new ShoppingCart
{
    TotalValue = 500.00m,
    ItemQuantity = 5,
    CustomerCategory = "VIP",
    IsFirstPurchase = false
};

var cart3 = new ShoppingCart
{
    TotalValue = 200.00m,
    ItemQuantity = 2,
    CustomerCategory = "Regular",
    IsFirstPurchase = true
};

var rules = new List<string>
            {
                "quantidade>10 E valor>1000 ENTAO 15",
                "categoria=VIP ENTAO 20",
                "primeiraCompra=true ENTAO 10"
            };

var parser = new DiscountParser();

var cartTotalDiscount = 0m;
Console.WriteLine("=== Carrinho 1 ===");
foreach (var rule in rules)
{
    var expr = parser.Parse(rule);
    cartTotalDiscount += expr.Interpret(cart1);
}

Console.WriteLine($"Desconto total para Carrinho 1: {cartTotalDiscount}");
cartTotalDiscount = 0m;

Console.WriteLine("\n=== Carrinho 2 ===");
foreach (var rule in rules)
{
    var expr = parser.Parse(rule);
    cartTotalDiscount += expr.Interpret(cart2);
}

Console.WriteLine($"Desconto total para Carrinho 2: {cartTotalDiscount}");
cartTotalDiscount = 0m;

Console.WriteLine("\n=== Carrinho 3 ===");
foreach (var rule in rules)
{
    var expr = parser.Parse(rule);
    cartTotalDiscount += expr.Interpret(cart3);
}

Console.WriteLine($"Desconto total para Carrinho 3: {cartTotalDiscount}");
cartTotalDiscount = 0m;
