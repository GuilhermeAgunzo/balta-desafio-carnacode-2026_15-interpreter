using Interpreter.Models;

namespace Interpreter.Abstractions.Expressions;

public interface IDiscountExpression
{
    decimal Interpret(ShoppingCart cart);
}
