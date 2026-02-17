using Interpreter.Abstractions.Expressions;
using Interpreter.Models;

namespace Interpreter.Expressions.Terminal;

public class FirstPurchaseCondition(bool expected) : IConditionExpression
{
    private readonly bool _expected = expected;

    public bool Interpret(ShoppingCart cart) => cart.IsFirstPurchase == _expected;
}
