namespace product_category_api.DTOs.ProductDtos;

public class GetAllProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}