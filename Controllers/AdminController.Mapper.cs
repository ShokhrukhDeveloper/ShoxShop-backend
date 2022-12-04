using ShoxShop.Dtos.Admin;
using ShoxShop.Model;

namespace ShoxShop.Controllers;
public partial class AdminController
{
    AdminDto ToAdminDto(AdminModel model)
        => new()
        {
            AdminId=model.AdminId,
            FirstName=model.FirstName,
            LastName=model.LastName,
            PhoneNumber=model.PhoneNumber,
            CreatedAt=model.CreatedAt,
            UpdatedAt=model.UpdatedAt,
            Image=model.Image,
            BirthDate=model.BirthDate
        };
}