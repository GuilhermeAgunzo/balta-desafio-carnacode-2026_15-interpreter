using Interpreter.Abstractions.Expressions;
using Interpreter.Expressions;
using Interpreter.Expressions.Logical;
using Interpreter.Expressions.Terminal;

namespace Interpreter.Parsers;

public class DiscountParser
{
    public IDiscountExpression Parse(string rule)
    {
        var parts = rule.Split("ENTAO");
        var conditionPart = parts[0].Trim();

        var discountPart = decimal.Parse(parts[1].Trim());

        var condition = ParseCondition(conditionPart);

        return new DiscountRule(condition, discountPart);
    }

    private IConditionExpression ParseCondition(string conditionPart)
    {
        if (conditionPart.Contains(" E "))
        {
            var parts = conditionPart.Split(" E ");
            return new AndCondition(ParseCondition(parts[0].Trim()), ParseCondition(parts[1].Trim()));
        }

        if (conditionPart.Contains(" OU "))
        {
            var parts = conditionPart.Split(" OU ");
            return new OrCondition(ParseCondition(parts[0].Trim()), ParseCondition(parts[1].Trim()));
        }

        if (conditionPart.StartsWith("quantidade>", StringComparison.OrdinalIgnoreCase))
        {
            int threshold = int.Parse(conditionPart.Replace("quantidade>", ""));
            return new QuantityCondition(threshold);
        }

        if (conditionPart.StartsWith("valor>", StringComparison.OrdinalIgnoreCase))
        {
            decimal threshold = decimal.Parse(conditionPart.Replace("valor>", ""));
            return new ValueCondition(threshold);
        }

        if (conditionPart.StartsWith("categoria=", StringComparison.OrdinalIgnoreCase))
        {
            string category = conditionPart.Replace("categoria=", "").Trim('"');
            return new CategoryCondition(category);
        }

        if (conditionPart.StartsWith("primeiraCompra=", StringComparison.OrdinalIgnoreCase))
        {
            bool isFirstPurchase = bool.Parse(conditionPart.Replace("primeiraCompra=", ""));
            return new FirstPurchaseCondition(isFirstPurchase);
        }

        throw new ArgumentException($"Unknown condition format: {conditionPart}");
    }
}
