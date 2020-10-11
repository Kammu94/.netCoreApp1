using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController: ControllerBase
    {
        //private readonly DataContext _context;
        //public UsersController(DataContext context)
        //{
        //    _context = context;

        //}

    }
}
