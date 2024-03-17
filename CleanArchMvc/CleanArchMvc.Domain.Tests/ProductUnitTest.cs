using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 8.99m,
            89, "Product image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 8.99m,
                        89, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 8.99m,
                        89, "product image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. too short, mininum 3 characteres");
        }
        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters");
        }
        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 8.99m, 89, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 8.99m, 89, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDamainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Invalid price stock");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(1, "Pro", "Product Description", -9.99m, 99,
                "product image");
            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Invalid price value");
        }

    }
}

