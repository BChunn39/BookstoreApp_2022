using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_with_EF_2022.DAL;
using API_with_EF_2022.Models;
using System.Linq.Expressions;
using System.Net;

namespace API_with_EF_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        BoardGameRepository repo = new BoardGameRepository();
         
        [HttpPost("add")]
        public BoardGame AddBoardGame(BoardGame game)
        {
      BoardGame newBoardGame = new BoardGame
      {
                Title = game.Title,
                Description = game.Description,
                YearPublished = game.YearPublished,
                RecommendedPlayerCount = game.RecommendedPlayerCount
            };
            return repo.AddBoardGame(newBoardGame);
        }
        [HttpGet]
        public List<BoardGame> GetAll()
        {
            return repo.GetAllGames();
        }
        [HttpGet("{id}")]
        public BoardGame GetById(int id)
        {
            return repo.FindById(id);
        }
        [HttpPost("delete/{id}")]
        public HttpResponseMessage DeleteById(int id)
        {
            try
            {
                if (repo.DeleteById(id) == true)
                {
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
        [HttpPost("update")]
        public HttpResponseMessage UpdateBoardGame(int id, string title, string descroption, int year, int count)
        {
            BoardGame gameToUpdate = new BoardGame
            {
                Id= id,
                Title = title,
                Description = descroption,
                YearPublished = year,
                RecommendedPlayerCount = count
            };
            try
            {
                if (repo.UpdateBoardGame(gameToUpdate) == true)
                {
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }

        }
    }
}
