using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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

        public decimal Phone { get; set; }

        public List<HumanModel> HumanList { get; set; }


        /// <summary>
        /// default constructor
        /// </summary>
        public HumanModel()
        {
            //HumanList = HumanListModel(1);

        }

        /// <summary>
        /// default constructor
        /// </summary>
        public HumanModel(bool isConnect)
        {
            if (isConnect)
                HumanList = HumanListModel(1);
        }
        
        public List<HumanModel> getSomeone(string name, int ageSt, int ageEd)
        {
            List<HumanModel> someone = new List<HumanModel>();
            //

            string str_sql = "SELECT * FROM human where NAME like '%"+ name + "%'" +
                                " AND Age BETWEEN " + ageSt + " AND " + ageEd + ";";
            
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                Get_Connection();

                cmd.Connection = connection;
                cmd.CommandText = str_sql;

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt != null)//confirm data is available
                {
                    if (dt.Rows.Count > 0)//check row count
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            HumanModel data = new HumanModel();
                            data.ID = int.Parse(dr["ID"].ToString());
                            data.Name = dr["NAME"].ToString();
                            someone.Add(data);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }         
            //
            return someone;
        }



        /// <summary>
        /// Constructor Get Data from connected database
        /// </summary>
        /// <param name="id"></param>
        public List<HumanModel> HumanListModel(int arg_id)
        {
            Get_Connection();
            ID = arg_id;

            List<HumanModel> res_data = new List<HumanModel>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("SELECT * FROM human;");
                
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable != null)//confirm data is available
                    {
                        if (dataTable.Rows.Count > 0)//check row count
                        {
                            foreach(DataRow dr in dataTable.Rows)
                            {
                                HumanModel data = new HumanModel();
                                data.ID = int.Parse(dr["ID"].ToString());
                                data.Name = dr["NAME"].ToString();
                                res_data.Add(data);
                            }
                        }
                    }                    

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    
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
            
            return res_data;
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