namespace DIO.Games
{
    public class Game : BaseEntity
    {
        // Attributes
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        // Methods
        public Game(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string result = "";
            result += "Genre: " + this.Genre + Environment.NewLine;
            result += "Title: " + this.Title + Environment.NewLine;
            result += "Description: " + this.Description + Environment.NewLine;
            result += "Year: " + this.Year + Environment.NewLine;
            result += "Deleted: " + this.Deleted;
            return result;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public int GetId()
        {
            return this.Id;
        }

        public bool IsDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}