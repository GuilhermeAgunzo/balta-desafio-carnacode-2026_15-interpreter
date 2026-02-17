using Interpreter.Models;

namespace Interpreter.Abstractions.Expressions;

public interface IConditionExpression
{
    bool Interpret(ShoppingCart cart);
}
