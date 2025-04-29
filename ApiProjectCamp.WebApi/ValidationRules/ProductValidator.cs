using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adını Boş Geçmeyin!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapın.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapın.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı Boş Geçilemez").GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz").LessThan(2000)
            .WithMessage("Ürün Fiyatı çok yüksek lütfen girdiğiniz değeri kontrol edin!");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz!");

        }
    }
}
