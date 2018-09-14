using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace Sarawoot.Models
{
    public class HumanModel
    {
        public string[] human;// Test passing data from controller to View

        //Human property: ID, Name, Surname, Gender, Age
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set;}

        public int Age { get; set; }

        public decimal phone { get; set; }


        /// <summary>
        /// default constructor
        /// </summary>
        public HumanModel()
        {

        }


        /// <summary>
        /// Constructor Get Data from connected database
        /// </summary>
        /// <param name="id"></param>
        public HumanModel(int arg_id)
        {
            Get_Connection();
            ID = arg_id;

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                string.Format("SELECT concat (person_id, ') '," +
                                " surname, ', ', forename) Person," +
                                " Address1, Address2, photo," +
                                " length(photo) " +
                                "from PersonMaster WHERE Person_ID = '{0}'",
                                ID);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    reader.Read();

                    if (reader.IsDBNull(0) == false)
                    {
                        Name = reader.GetString(0);
                    }   
                    else{
                        Name = null;
                    }                        

                    if (reader.IsDBNull(1) == false) {
                        //Address1 = reader.GetString(1);
                    }
                    else {
                        //Address1 = null;
                    }


                    if (reader.IsDBNull(2) == false) {
                        //Address2 = reader.GetString(2);
                    }
                    else
                    {
                        //Address2 = null;
                    }
                    
                    if (reader.IsDBNull(3) == false)
                    {
                        //Photo = new byte[reader.GetInt32(4)];
                        //reader.GetBytes(3, 0, Photo, 0, reader.GetInt32(4));
                    }
                    else
                    {
                        //Photo = null;
                    }
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    reader.Close();
                    Name = MessageString;
                    //Address1 = Address2 = null;
                }
            }
            catch (MySqlException e)
            {
                string MessageString = "The following error occurred loading the Column details: "
                    + e.ErrorCode + " - " + e.Message;
                Name = MessageString;
               // Address1 = Address2 = null;
            }
            connection.Close();
        }



        /// <summary>
        /// https://www.codeproject.com/Articles/822392/Connecting-to-MySQL-from-ASP-NET-MVC-using-Visual
        /// 
        /// </summary>
        /// 
        #region MySQL DataBase connection 

        //MySQL Data
        private bool connection_open;
        private MySqlConnection connection;

        /// <summary>
        /// Connecto to Database Server
        /// </summary>
        private void Get_Connection()
        {
            connection_open = false;

            connection = new MySqlConnection();
            //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
            if (Open_Local_Connection())
            {
                connection_open = true;
            }
            else
            {
                //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
                //					 Application::Exit();
            }
        }//End: Get_Connection

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);//print exceptrion message//Sarawoot
                return false;
            }
        }
        #endregion
    }
}