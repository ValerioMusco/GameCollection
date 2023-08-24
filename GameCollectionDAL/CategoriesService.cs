using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionDAL {
    public class CategoriesService {

        private readonly string _connectionString = "Data Source=DESKTOP-95QLTBL;Initial Catalog=GameCollectionDB; Integrated Security=True;";

        public void Create(string categoryName) {

            using(SqlConnection cnx = new(_connectionString) ) {

                using (SqlCommand cmd = cnx.CreateCommand() ) {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "CreateCategory";

                    cmd.Parameters.AddWithValue( "@categoryName", categoryName);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }

        public List<string> ShowAll() {
            
            List<string> list = new();
            using( SqlConnection cnx = new( _connectionString ) ) {

                using( SqlCommand cmd = cnx.CreateCommand() ) {

                    cmd.CommandText =
                        "SELECT Name FROM Categories";

                    cnx.Open();
                    using(SqlDataReader r = cmd.ExecuteReader()) {

                        while ( r.Read()) {

                            list.Add( (string)r["Name"] );
                        }
                    }
                    cnx.Close();
                    return list;
                }
            }
        }

        public void Update(string newName, string oldName) {

            using( SqlConnection cnx = new( _connectionString ) ) {

                using( SqlCommand cmd = cnx.CreateCommand() ) {

                    cmd.CommandText =
                        "UPDATE Categories " +
                        "SET Name = @newName " +
                        "WHERE Name LIKE @oldName";

                    cmd.Parameters.AddWithValue( "newName", newName );
                    cmd.Parameters.AddWithValue( "oldName", oldName );

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }


    }
}
