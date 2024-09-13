namespace Application.DTOs.FooterAddressDtos;

public class CreateFooterAddressDto : IBaseDto
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
