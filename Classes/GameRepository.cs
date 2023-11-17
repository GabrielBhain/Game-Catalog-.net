using DIO.Games.Interfaces;

namespace DIO.Games
{
    public class GameRepository : IRepository<Game>
    {
        private List<Game> gameList = new List<Game>();

        public void Update(int id, Game gameObject)
        {
            if (id >= 0 && id < gameList.Count)
            {
                gameList[id] = gameObject;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid ID for updating. ID must be within the range of existing games.");
            }
        }

        public void Delete(int id)
        {
            if (id >= 0 && id < gameList.Count)
            {
                gameList[id].Delete();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid ID for deletion. ID must be within the range of existing games.");
            }
        }

        public void Insert(Game gameObject)
        {
            gameList.Add(gameObject);
        }

        public List<Game> List()
        {
            return gameList;
        }

        public int NextId()
        {
            return gameList.Count;
        }

        public Game GetById(int id)
        {
            try
            {
                return gameList[id];
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid ID. ID must be within the range of existing games.");
            }
        }
    }
}
