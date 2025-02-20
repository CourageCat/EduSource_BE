namespace EduSource.Contract.DTOs.PaymentDTOs;

public sealed class CreatePaymentResponseDTO
{
    public long OrderCode { get; set; }
    public bool Success { get; set; }
    public string PaymentUrl { get; set; }
    public string Message { get; set; }

    public CreatePaymentResponseDTO(long orderCode, bool success, string paymentUrl, string message)
    {
        OrderCode = orderCode;
        Success = success;
        PaymentUrl = paymentUrl;
        Message = message;
    }
}
