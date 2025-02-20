namespace EduSource.Contract.DTOs.PaymentDTOs;

public sealed class ResultCacheDTO
{
    public ResultCacheDTO(long orderCode, Guid accountId, string description)
    {
        OrderCode = orderCode;
        AccountId = accountId;
        Description = description;
    }

    public long OrderCode { get; set; }
    public Guid AccountId { get; set; }
    public string Description { get; set; }

}
