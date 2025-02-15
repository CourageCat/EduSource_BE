using EduSource.Contract.Enumarations.MessagesList;

namespace EduSource.Domain.Exceptions;

public static class CartException
{
    public sealed class ProductHasAlreadyAddedToCartException : BadRequestException
    {
        public ProductHasAlreadyAddedToCartException() : base(MessagesList.CartProductHasAlreadyAddedToCartException.GetMessage().Message, MessagesList.CartProductHasAlreadyAddedToCartException.GetMessage().Code)
        {

        }
    }

    public sealed class ProductNotFoundInCartException : NotFoundException
    {
        public ProductNotFoundInCartException() : base(MessagesList.CartProductNotFoundInCartException.GetMessage().Message, MessagesList.CartProductNotFoundInCartException.GetMessage().Code)
        {

        }
    }

    public sealed class CheckoutWithNoProductsInCartException : NotFoundException
    {
        public CheckoutWithNoProductsInCartException() : base(MessagesList.CartCheckoutWithNoProductsInCartException.GetMessage().Message, MessagesList.CartCheckoutWithNoProductsInCartException.GetMessage().Code)
        {

        }
    }
}
