using appglobal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appglobal
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class DataUserController : ControllerBase
  {
    [HttpGet]
    public JsonResult GetList() //api/DataUser/GetList
    {
      var list_data_user = new List<DataUserModel>
      {
        new DataUserModel{nik = "1234", nama = "Bejo", alamat = "Kedung Baruk"},
        new DataUserModel{nik = "2345", nama = "Ani", alamat = "Semolowaru"},
        new DataUserModel{nik = "3456", nama = "Wahyu", alamat = "Rungkut"},
      };

      return new JsonResult(list_data_user);
    }    

    [HttpGet]
    public JsonResult GetListFromDB() //api/DataUser/GetList
    {
      data_model _context = new data_model();
      var list_data_user = _context.DataUsers.ToList();

      return new JsonResult(list_data_user);
    }

    [HttpGet]
    public async Task<JsonResult> GetListFromDBAsync() //api/DataUser/GetList
    {
      data_model _context = new data_model();
      var list_data_user = await _context.DataUsers.ToListAsync();

      return new JsonResult(list_data_user);
    }
  }
}
