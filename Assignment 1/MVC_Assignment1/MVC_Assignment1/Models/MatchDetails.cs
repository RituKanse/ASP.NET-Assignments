using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_Assignment1.Models
{
    public class MatchDetails
    {

        public List<FootBallLeague> GetMatchDetails()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<FootBallLeague> MatchDetails = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("select * from FootBallLeague", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    MatchDetails.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status = Convert.ToString(dr["Status"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return MatchDetails;

            }
        }

        public bool InsertFootballDetails(FootBallLeague footBall)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InsertIntoFootBallLeague", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MatchID", footBall.MatchID);
                cmd.Parameters.AddWithValue("@TeamName1", footBall.TeamName1);
                cmd.Parameters.AddWithValue("@TeamName2", footBall.TeamName2);
                cmd.Parameters.AddWithValue("@WinningTeam", footBall.WinningTeam);
                cmd.Parameters.AddWithValue("@MatchStatus", footBall.Status);
                cmd.Parameters.AddWithValue("@Points", footBall.Points);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                    return true;
                else
                    return false;

            }
        }


        public List<FootBallLeague> WinningMatchDetails()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<FootBallLeague> winninglist = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("WinningTeams", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    winninglist.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status = Convert.ToString(dr["MatchStatus"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return winninglist;

            }
        }

        public List<FootBallLeague> DrawMatchDetails()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<FootBallLeague> drawlist = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("DrawTeams", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    drawlist.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status = Convert.ToString(dr["MatchStatus"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return drawlist;

            }
        }

        public List<FootBallLeague> JapanMatchDetails()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<FootBallLeague> japanlist = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("JapanMatchDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    japanlist.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status = Convert.ToString(dr["MatchStatus"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return japanlist;

            }
        }

    }
}