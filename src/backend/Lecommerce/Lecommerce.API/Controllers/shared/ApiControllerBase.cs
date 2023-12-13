using Microsoft.AspNetCore.Mvc;

namespace Lecommerce.API.Controllers.shared
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
    }
}
