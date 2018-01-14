namespace RentalCars.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;

    [Area(AdminArea)]
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {
    }
}
