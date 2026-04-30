using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PPE_관제_시스템
{
    internal class db
    {
        public class dbManager
        {
            private string dbstr = "Server= http://43.200.27.117;Port=5000;Database=violations;id=sim;password=capston;";
            
            public void InsertViolation(string type, string zone, string camId, string imgpath)
            {
                using (MySqlConnection conn = new MySqlConnection(dbstr))
                {
                    conn.Open();
                    string sql = "INSERT INTO violations (violation_type, zone, camera_id, image_path, status, created_at) " +
                        "VALUES (@type, @zone, @cam, @img, '미해결', NOW())";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@zone", zone);
                    cmd.Parameters.AddWithValue("@cam", camId);
                    cmd.Parameters.AddWithValue("@img", imgpath);
                    cmd.ExecuteNonQuery();
                }
            }
        
        
        }
    }
}
