namespace product_category_api.DTOs.ProductDtos;

public class CreateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
}