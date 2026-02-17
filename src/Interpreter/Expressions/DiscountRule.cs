using Interpreter.Abstractions.Expressions;
using Interpreter.Models;

namespace Interpreter.Expressions;

public class DiscountRule(IConditionExpression condition, decimal discountPercentage) : IDiscountExpression
{
    private readonly IConditionExpression _condition = condition;
    private readonly decimal _discountPercentage = discountPercentage;

    public decimal Interpret(ShoppingCart cart)
    {
        if (_condition.Interpret(cart))
            return cart.TotalValue * (_discountPercentage / 100);

        return 0;
    }
}
