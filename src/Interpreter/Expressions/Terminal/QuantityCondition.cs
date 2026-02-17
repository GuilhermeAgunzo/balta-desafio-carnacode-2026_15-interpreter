using Interpreter.Abstractions.Expressions;
using Interpreter.Models;

namespace Interpreter.Expressions.Terminal;

public class QuantityCondition(int threshold) : IConditionExpression
{
    private readonly int _threshold = threshold;

    public bool Interpret(ShoppingCart cart)
        => cart.ItemQuantity > _threshold;
}
