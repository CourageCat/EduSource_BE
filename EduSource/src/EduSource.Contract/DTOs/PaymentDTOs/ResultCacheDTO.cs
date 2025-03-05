namespace EduSource.Contract.DTOs.PaymentDTOs;

public sealed class ResultCacheDTO
{
    public ResultCacheDTO(long orderCode, Guid accountId, string description, List<Guid> productIds, bool isFromCart)
    {
        OrderCode = orderCode;
        AccountId = accountId;
        Description = description;
        ProductIds = productIds;
        IsFromCart = isFromCart;
    }

    public long OrderCode { get; set; }
    public Guid AccountId { get; set; }
    public string Description { get; set; }
    public List<Guid> ProductIds { get; set; }
    public bool IsFromCart { get; set; }

}
