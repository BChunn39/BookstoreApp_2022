using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_with_EF_2022.Models;
using API_with_EF_2022.DAL;

namespace API_with_EF_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        FishRepository repo = new FishRepository();
        [HttpPost("spawn")]
        public Fish AddFish(string name, string classification, bool fresh, bool salt)
        {
            Fish newFish = new Fish
            {
                Name = name,
                Classification = classification,
                SaltWater = salt,
                FreshWater = fresh,
            };
            return repo.AddFish(newFish);
        }
    }
}
