namespace EduSource.Contract.DTOs.OrderDTOs;

public class EmailOrderDTO
{
    public EmailOrderDTO()
    {
    }

    public EmailOrderDTO(string description, int quantity, int price, int total)
    {
        Description = description;
        Quantity = quantity;
        Price = price;
        Total = total;
    }

    public string Description { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int Total { get; set; }


}
