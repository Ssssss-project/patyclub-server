using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using patyclub_server.Entities;
namespace patyclub_server.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private DBContext _context;


        public UserController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> Get()
        {
            List<User> testList = _context.user.ToList();
            return testList;
        }

        [HttpGet("add")]
        public string Add()
        {
            List<User> testList = _context.user.ToList();
            User addData = new User{
                id = testList.Count,
                name = "test",
                phone = "test",
                remark = "test"
            };
            var res =_context.user.Add(addData);
            _context.SaveChanges();
            return "success";
        }

        [HttpGet("delete/{id}")]
        public string Delete(int id)
        {
            var findUser = _context.user.SingleOrDefault(x => x.id == id);
            if (findUser != null)
            {
                _context.user.Remove(findUser);
                _context.SaveChanges();
                return "delete success";
            }
            return "undefind any user";
        }

        [HttpGet("update/{id}")]
        public string Update(int id)
        {
            var findUser = _context.user.SingleOrDefault(x => x.id == id);
            if (findUser != null)
            {
                findUser.phone = "0917-001-997";
                _context.user.Update(findUser);
                _context.SaveChanges();
                return "update success";
            }
            return "undefind any user";
        }
    }
}
