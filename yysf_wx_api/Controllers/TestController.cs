using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yysf_Entity.BusEntitys;
using yysf_Repository.BusRepository;

namespace yysf_wx_api.Controllers
{
    [Route(template:"api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPictureRepository _pictureRepository;
        public TestController(IPictureRepository pictureRepository) 
        { 
            this._pictureRepository=pictureRepository;
        }
        [HttpPost]
        public bool AddPicture()
        {
            Picture picture = new Picture() { 
            Title = "Test",
            UserId=1,
            UserName = "夜雨声烦",
            };
            return _pictureRepository.Add(entity: picture);
        }
    }
}
