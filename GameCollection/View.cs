using GameCollectionDAL;
using GameCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace GameCollection {
    internal class View {

        public int Menu() {

            ConsoleKey key;

            do {

                Console.Clear();
                string menu = NavMenu();
                int lines = CountLines(menu);
                Console.WriteLine( menu );

                key = Console.ReadKey( true ).Key;

                switch( key ) {

                    case ConsoleKey.DownArrow:
                        if( Position.pos == lines )
                            Position.pos = 0;
                        else
                            Position.pos++;
                        break;
                    case ConsoleKey.UpArrow:
                        if( Position.pos == 0 )
                            Position.pos = lines;
                        else
                            Position.pos--;
                        break;
                }
            } while( key == ConsoleKey.DownArrow || key == ConsoleKey.UpArrow );

            return Position.pos;
        }

        int CountLines( string menu ) {

            int count = 0;

            for( int i = 0; i < menu.Length; i++ )
                if( menu[i] == '\n' )
                    count++;
            return count - 1;
        }

        string NavMenu() {

            StringBuilder sb = new StringBuilder();

            sb.Append( Position.pos == 0 ? "> : " : "  : " );
            sb.AppendLine( "Lister tout les jeux" );
            sb.Append( Position.pos == 1 ? "> : " : "  : " );
            sb.AppendLine( "Lister les jeux par catégorie" );
            sb.Append( Position.pos == 2 ? "> : " : "  : " );
            sb.AppendLine( "Afficher les détails d'un jeu" );
            sb.Append( Position.pos == 3 ? "> : " : "  : " );
            sb.AppendLine( "Afficher les catégories" );
            sb.Append( Position.pos == 4 ? "> : " : "  : " );
            sb.AppendLine( "Ajouter un jeu" );
            sb.Append( Position.pos == 5 ? "> : " : "  : " );
            sb.AppendLine( "Ajouter une catégorie" );
            sb.Append( Position.pos == 6 ? "> : " : "  : " );
            sb.AppendLine( "Modifier une catégorie" );
            sb.Append( Position.pos == 7 ? "> : " : "  : " );
            sb.AppendLine( "Quitter" );

            return sb.ToString();
        }

        public void ListAll() {

            GamesService gameService = new();
            foreach( string game in gameService.ShowAll() )
                Console.WriteLine( game );
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        public void ListByCategory() {

            GamesService gameService = new();
            foreach( KeyValuePair<string, List<string>> kvp in gameService.ShowByCategory() ) {

                Console.WriteLine( kvp.Key );
                foreach( string game in kvp.Value )
                    Console.WriteLine( $"\t{game}" );
            }
            Console.WriteLine( "Appuyez sur une touche pour continuer..." );
            Console.ReadKey();
        }

        public void ShowDetail() {

            GamesService gameService = new();
            string game;
            Console.Clear();
            Console.Write( "Entrez le jeu que vous voulez rechercher : " );
            game = Console.ReadLine();

            Console.WriteLine( gameService.ShowDetail( game ) );
            Console.WriteLine( "Appuyez sur une touche pour continuer..." );
            Console.ReadKey();
        }

        public void ListCategories() {

            CategoriesService categoriesService = new();
            foreach( string cat in categoriesService.ShowAll() )
                Console.WriteLine( cat );
            Console.WriteLine( "Appuyez sur une touche pour continuer..." );
            Console.ReadKey();
        }

        public void CreateCategory() {

            CategoriesService categoriesService = new();
            string cat;
            Console.Clear();
            Console.Write( "Entrez le nom de la catégorie à ajouter : " );
            cat = Console.ReadLine();

            categoriesService.Create( cat );
            Console.WriteLine( "Appuyez sur une touche pour continuer..." );
            Console.ReadKey();
        }

        public void UpdateCategory() {

            CategoriesService categoriesService = new();
            string oldName;
            string newName;
            Console.Clear();
            Console.Write( "Entrez le nom de la catégorie à modifier : " );
            oldName = Console.ReadLine();
            Console.Write( "Entrez le nouveau nom : " );
            newName = Console.ReadLine();

            categoriesService.Update( newName, oldName );
            Console.WriteLine( "Appuyez sur une touche pour continuer..." );
            Console.ReadKey();
        }

        public void CreateGame() {

            GamesService gameService = new();
            ConsoleKey key;
            List<Category> categories = new();

            Console.Clear();
            Console.WriteLine("Entrez le nom du jeu : ");
            string title = Console.ReadLine();
            Console.Write( "Entrez la description du jeu : " );
            string description = Console.ReadLine();
            Console.WriteLine("Entrez la date de sortie 'JJ-MM-AA' : ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Game game = new Game();
            game.Title = title;
            game.Description = description;
            game.ReleaseDate = date;

            do {

                Console.WriteLine("Entrez une catégorie du jeu : ");
                categories.Add( new Category( Console.ReadLine() ) );

                Console.WriteLine("Appuyez sur touche pour insérer une autre catégorie ou Escape pour quitter.");
                key = Console.ReadKey( true ).Key;
            } while(key !=  ConsoleKey.Escape);

            gameService.Create( game, categories );

            Console.WriteLine( "Appuyez sur une touche pour continuer..." );
            Console.ReadKey();
        }
    }
}
