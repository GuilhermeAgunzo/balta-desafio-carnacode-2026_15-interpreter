using Interpreter.Abstractions.Expressions;
using Interpreter.Models;

namespace Interpreter.Expressions.Terminal;

public class CategoryCondition(string category) : IConditionExpression
{
    private readonly string _category = category;

    public bool Interpret(ShoppingCart cart)
            => cart.CustomerCategory.Equals(_category, StringComparison.OrdinalIgnoreCase);
}
