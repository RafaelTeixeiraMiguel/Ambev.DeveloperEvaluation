using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleItems)
            .Must(NotExceedMaxItemsPerProduct)
            .WithMessage("Maximum limit of 20 items per product exceeded.");
    }

    private bool NotExceedMaxItemsPerProduct(List<SaleItem> saleItems)
    {
        if (saleItems == null || !saleItems.Any())
            return true;

        var grouped = saleItems
            .GroupBy(item => item.ProductName)
            .Select(group => new
            {
                ProductName = group.Key,
                TotalQuantity = group.Sum(item => item.Quantity)
            });

        return grouped.All(g => g.TotalQuantity <= 20);
    }
}
