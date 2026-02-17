using Interpreter.Abstractions.Expressions;
using Interpreter.Models;

namespace Interpreter.Expressions.Terminal;

public class ValueCondition(decimal threshold) : IConditionExpression
{
    private readonly decimal _threshold = threshold;

    public bool Interpret(ShoppingCart cart)
        => cart.TotalValue > _threshold;
}
