using Interpreter.Abstractions.Expressions;
using Interpreter.Models;

namespace Interpreter.Expressions.Logical;

public class AndCondition(IConditionExpression left, IConditionExpression right) : IConditionExpression
{
    private readonly IConditionExpression _left = left, _right = right;

    public bool Interpret(ShoppingCart cart) => _left.Interpret(cart) && _right.Interpret(cart);
}
