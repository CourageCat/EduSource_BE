namespace EduSource.Contract.DTOs.PaymentDTOs;

public sealed class ResultCacheDTO
{
    public ResultCacheDTO(long orderCode, Guid accountId)
    {
        OrderCode = orderCode;
        AccountId = accountId;
    }

    public long OrderCode { get; set; }
    public Guid AccountId { get; set; }

}
