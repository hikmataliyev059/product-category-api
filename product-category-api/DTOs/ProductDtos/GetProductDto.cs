namespace product_category_api.DTOs.ProductDtos;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public double Price { get; set; }
    public string Description { get; set; }
    public int? CategoryId { get; set; }
    public string CategoryName { get; set; } 
}