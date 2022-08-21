using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MVC_Assignment2.Models
{
    public class BusInfoDB
    {
        public bool InsertbusDetails(BusInfo busdetails)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InsertIntoBusInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BoardingPoint", busdetails.BoardingPoint);
                cmd.Parameters.AddWithValue("@TravelDate", busdetails.TravelDate);
                cmd.Parameters.AddWithValue("@Amount", busdetails.Amount);
                cmd.Parameters.AddWithValue("@Rating", busdetails.Rating);

                SqlParameter outputparameter = new SqlParameter();
                outputparameter.ParameterName = "@BusId";
                outputparameter.SqlDbType = SqlDbType.Int;
                outputparameter.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outputparameter);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                string j = outputparameter.Value.ToString();
                busdetails.BusId = Convert.ToInt32(j);
                if (i >= 1)
                    return true;
                else
                    return false;

            }
        }
        public List<BusInfo> BusDetails()
        {
            List<BusInfo> buslist = new List<BusInfo>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            
            {
                SqlCommand cmd = new SqlCommand("select * from BusInfo", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfo
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"]),
                            Amount = Convert.ToDouble(dr["Amount"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        });

                }
                return buslist;
            }
        }

        public List<BusInfo> BusDetailsByAmount()
        {
            List<BusInfo> buslist2 = new List<BusInfo>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            
            {
                SqlCommand cmd = new SqlCommand("DetailsByAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist2.Add(
                        new BusInfo
                        {

                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"]),
                            Amount = Convert.ToDouble(dr["Amount"])

                        });

                }
                return buslist2;
            }
        }
        public List<BusInfo> BusDetailsByRating()
        {
            List<BusInfo> buslist3= new List<BusInfo>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Bus_View", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist3.Add(
                        new BusInfo
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        });

                }
                return buslist3;
            }
        }
        public List<BusInfo> BusDetailsByDate()
        {
            List<BusInfo> buslist4 = new List<BusInfo>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DetailsByDate", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist4.Add(
                        new BusInfo
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"])

                        });

                }
                return buslist4;
            }
        }
       
    }
}