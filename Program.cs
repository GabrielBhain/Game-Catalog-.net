namespace DIO.Games
{
    class Program
    {
        static GameRepository repository = new GameRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                try
                {
                    switch (userOption)
                    {
                        case "1":
                            ListGames();
                            break;
                        case "2":
                            InsertGame();
                            break;
                        case "3":
                            UpdateGame();
                            break;
                        case "4":
                            DeleteGame();
                            break;
                        case "5":
                            ViewGame();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid ID. Please enter a valid ID.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid option. Please enter a valid option.");
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for using our services.");
            Console.ReadLine();
        }

        private static void DeleteGame()
        {
            Console.Write("Enter the game ID: ");
            if (int.TryParse(Console.ReadLine(), out int gameIndex))
            {
                repository.Delete(gameIndex);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        private static void ViewGame()
        {
            Console.Write("Enter the game ID: ");
            if (int.TryParse(Console.ReadLine(), out int gameIndex))
            {
                var game = repository.GetById(gameIndex);

                if (game != null)
                {
                    Console.WriteLine(game);
                }
                else
                {
                    Console.WriteLine("Game not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        private static void UpdateGame()
        {
            Console.Write("Enter the game ID: ");
            if (int.TryParse(Console.ReadLine(), out int gameIndex))
            {
                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
                }

                Console.Write("Enter the genre from the options above: ");
                if (int.TryParse(Console.ReadLine(), out int genreInput) && Enum.IsDefined(typeof(Genre), genreInput))
                {
                    Console.Write("Enter the Game Title: ");
                    string titleInput = Console.ReadLine();

                    Console.Write("Enter the Game Release Year: ");
                    if (int.TryParse(Console.ReadLine(), out int yearInput))
                    {
                        Console.Write("Enter the Game Description: ");
                        string descriptionInput = Console.ReadLine();

                        Game updatedGame = new Game(id: gameIndex,
                                                    genre: (Genre)genreInput,
                                                    title: titleInput,
                                                    year: yearInput,
                                                    description: descriptionInput);

                        repository.Update(gameIndex, updatedGame);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid year.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid genre.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        private static void ListGames()
        {
            Console.WriteLine("List of games");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No games registered.");
            }
            else
            {
                foreach (var game in list)
                {
                    var deleted = game.IsDeleted();

                    Console.WriteLine("#ID {0}: - {1} {2}", game.GetId(), game.GetTitle(), (deleted ? "*Deleted*" : ""));
                }
            }
        }

        private static void InsertGame()
        {
            Console.WriteLine("Insert new game");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Enter the genre from the options above: ");
            if (int.TryParse(Console.ReadLine(), out int genreInput) && Enum.IsDefined(typeof(Genre), genreInput))
            {
                Console.Write("Enter the Game Title: ");
                string titleInput = Console.ReadLine();

                Console.Write("Enter the Game Release Year: ");
                if (int.TryParse(Console.ReadLine(), out int yearInput))
                {
                    Console.Write("Enter the Game Description: ");
                    string descriptionInput = Console.ReadLine();

                    Game newGame = new Game(id: repository.NextId(),
                                            genre: (Genre)genreInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descriptionInput);

                    repository.Insert(newGame);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid year.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid genre.");
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Games at your service!");
            Console.WriteLine("Enter the desired option:");

            Console.WriteLine("1- List games");
            Console.WriteLine("2- Insert new game");
            Console.WriteLine("3- Update game");
            Console.WriteLine("4- Delete game");
            Console.WriteLine("5- View game");
            Console.WriteLine("C- Clear Screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
