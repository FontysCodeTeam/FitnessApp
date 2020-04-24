using StayFitApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFitApp.Models
{
   
    public class Queries
    {
        Database db = new Database();

        //Get history of exercises from the user
        public DataTable getHistory(int id)
        {
            DataTable dt = db.ExecuteStringQuery($"SELECT user.name, exercise.description, history.date, history.duration FROM((history " +
                $"INNER JOIN exercise ON history.exerciseID = exercise.ID) " +
                $"INNER JOIN user ON history.userID = user.ID) " +
                $"WHERE user.ID = '{id}'");

            return dt;
        } 

        //Updates the history of the user
        public void updateHistory(int userid, int exerciseid, int totalTime)
        {
            db.ExecuteNonQuery($"INSERT INTO `fhictDB`.`history` (`userID`, `exerciseID`, `date`, `duration`) " +
                $"VALUES('{userid}', '{exerciseid}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{totalTime}'); ");
        }

            
    }
}
