using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionDAL {
    public class GamesService {

        private readonly string _connectionString = "Data Source=DESKTOP-95QLTBL;Initial Catalog=GameCollectionDB; Integrated Security=True;"; 

        public void Create(Game game, List<Category> categories) {

            using(SqlConnection cnx = new( _connectionString ) ) {

                foreach( Category category in categories ) {

                    using( SqlCommand cmd = cnx.CreateCommand() ) {

                        cnx.Open();

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "CreateGameCategory";

                        cmd.Parameters.AddWithValue( "@gameTitle", game.Title ?? "" );
                        cmd.Parameters.AddWithValue( "@gameReleaseDate", game.ReleaseDate );
                        cmd.Parameters.AddWithValue( "@gameDescription", game.Description ?? "" );
                        cmd.Parameters.AddWithValue( "@categoryName", category.Name );
                        cmd.ExecuteNonQuery();
                        
                        cnx.Close();
                    }
                }
            }
        }

        public List<string> ShowAll(string category = "") {

            List<string> list = new();

            using(SqlConnection cnx = new( _connectionString ) ) { 
            
                using(SqlCommand cmd = cnx.CreateCommand() ) {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetGame";
                    
                    cmd.Parameters.AddWithValue( "@gameCategory", category );

                    cnx.Open();
                    using( SqlDataReader r = cmd.ExecuteReader() ) {

                        while(r.Read()) {

                            list.Add( (string)r["Title"] );
                        }
                    }
                    cnx.Close();

                    return list;
                }
            }
        }

        public Dictionary<string, List<string>> ShowByCategory() {

            List<string> list = new List<string>();
            Dictionary<string, List<string>> keyValuePairs = new();

            using(SqlConnection cnx = new(_connectionString) ) {

                using(SqlCommand cmd = cnx.CreateCommand() ) {

                    cmd.CommandText =
                        "SELECT Name FROM Categories";

                    cnx.Open();
                    using(SqlDataReader r = cmd.ExecuteReader() ) {

                        while(r.Read())
                            list.Add( (string)r["Name"] );
                    }
                    cnx.Close();
                }

                foreach(string category in list )
                    keyValuePairs.Add(category, ShowAll( category ) );
            }

            return keyValuePairs;
        }

        public Game ShowDetail(string gameName) {

            Game game = new();
            using(SqlConnection cnx = new(_connectionString) ) {

                using(SqlCommand cmd =  cnx.CreateCommand()) {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetGameDetails";

                    cmd.Parameters.AddWithValue( "@gameName", gameName );

                    cnx.Open();
                    using(SqlDataReader r =cmd.ExecuteReader()) {

                        while( r.Read() ) {

                            game = new Game {

                                Id = (int)r["IdGame"],
                                Title = (string)r["Title"],
                                Description = (string)r["Description"],
                                ReleaseDate = (DateTime)r["ReleaseDate"],
                                Categories = ( (string)r["CategoryNames"] ).Split(',').ToList()
                            };
                        }
                    }
                    cnx.Close();
                    return game;
                }
            }
        }
    }
}
