using API_with_EF_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace API_with_EF_2022.DAL
{
    public class BoardGameRepository
    {
        private GameContext _dbContext = new GameContext();
        public BoardGame AddBoardGame(BoardGame game)
        {
            _dbContext.BoardGames.Add(game);
            _dbContext.SaveChanges();
            return GetLatestBoardGame();
        }
        private BoardGame GetLatestBoardGame()
        {
            return _dbContext.BoardGames.OrderByDescending(x => x.Id).FirstOrDefault();
        }
        
        public List<BoardGame> GetAllGames()
        {
            return _dbContext.BoardGames.ToList();
        }
        public BoardGame FindById(int id)

        {
            // AsNoTracking will not lock the ID allowing updating it after finding it

            return _dbContext.BoardGames.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public bool DeleteById(int id)
        {
            BoardGame boardgame= FindById(id);
            if (boardgame == null)
            {
                return false;
            }
            _dbContext.BoardGames.Remove(FindById(id));
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateBoardGame(BoardGame gameToEdit)
        {
            if(FindById(gameToEdit.Id) == null)
            {
                return false;
            }
            _dbContext.BoardGames.Update(gameToEdit);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
