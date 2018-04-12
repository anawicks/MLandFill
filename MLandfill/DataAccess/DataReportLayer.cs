using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MLandfill.Models;
using MLandfill.ViewModel;
using System.Diagnostics;
using MLandfill.Reports;

namespace MLandfill.DataAccess
{
    public class DataReportLayer
    {
        #region "Reports"

        public IEnumerable<OtherReports> rptDailyLandFillSummaryGet( DateTime fromDate, DateTime toDate)
        {

            SqlConnection con = null;

            List<OtherReports> rptList = new List<OtherReports>();
            try
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptDailyLandFillSummary", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);



                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                OtherReports rptModel = new OtherReports();

                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();
                                rptModel.ScaleTicket = rdr["ScaleTicket"].ToString();
                                rptModel.DocketNo = rdr["DocketNo"].ToString();
                                rptModel.VtNet = Convert.ToDecimal(rdr["VtNet"]);
                                if (!(rdr["ReceivedDate"] is DBNull))
                                    rptModel.ReceivedDate = Convert.ToDateTime(rdr["ReceivedDate"]);

                                rptModel.LocationLSD = rdr["LocationLSD"].ToString();
                                rptModel.ApprovalCode = rdr["ApprovalCode"].ToString();

                  
                                rptList.Add(rptModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return rptList;

        }

        public IEnumerable<OtherReports> rptLocationLoadSummaryGet( DateTime fromDate, DateTime toDate)
        {

            SqlConnection con = null;

            List<OtherReports> rptList = new List<OtherReports>();
            try
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptLocationLoadSummary", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                OtherReports rptModel = new OtherReports();

                                rptModel.DocketNo = rdr["DocketNo"].ToString();
                                rptModel.ReceivedDate = Convert.ToDateTime(rdr["ReceivedDate"]);
                                rptModel.VtNet = Convert.ToDecimal(rdr["VtNet"]);
                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();
                                rptModel.ApprovalCode = rdr["ApprovalCode"].ToString();
                                rptModel.Grid = rdr["Grid"].ToString();
                                rptModel.Cell = rdr["Cell"].ToString();
                                rptModel.GridNo = rdr["GridNo"].ToString();
                                rptModel.Elevation = rdr["Elevation"].ToString();
                                rptModel.WasteLocation = rdr["WasteLocation"].ToString();

                                rptList.Add(rptModel);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return rptList;

        }

        public IEnumerable<OtherReports> rptMonthlyLoadSummaryGet(int generatorId,                                                                       
                                                                    DateTime fromDate , 
                                                                    DateTime toDate, 
                                                                    string approvalCode )
        {

            SqlConnection con = null;

            List<OtherReports> rptList = new List<OtherReports>();
            try
            {

                //Newell Regional Landfill - Monthly Load Summary
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptMonthlyLoadSummary", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@generatorId", generatorId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                        cmd.Parameters.AddWithValue("@approvalCode", approvalCode);




                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                OtherReports rptModel = new OtherReports();

                                rptModel.ScaleTicket = rdr["ScaleTicket"].ToString();
                                rptModel.DocketNo = rdr["DocketNo"].ToString();
                                rptModel.ReceivedDate = Convert.ToDateTime(rdr["ReceivedDate"]);
                                rptModel.VtNet = Convert.ToDecimal(rdr["VtNet"]);
                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();
                                rptModel.ApprovalCode = rdr["ApprovalCode"].ToString();



                              
                                rptList.Add(rptModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return rptList;

        }


        public IEnumerable<OtherReports> rptSalesByCustomerSummaryGet(bool excludeGst, string month, int year)
        {

            SqlConnection con = null;

            List<OtherReports> rptList = new List<OtherReports>();
            try
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptSalesByCustomerSummary", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExcludeGst", excludeGst);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Year", year);



                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                OtherReports rptModel = new OtherReports();

                                rptModel.ApprovalCode = rdr["ApprovalCode"].ToString();
                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();
                                rptModel.ChargedTotal = Convert.ToDecimal( rdr["ChargedTotal"]);
                                rptModel.ChargedTotalWithGst = Convert.ToDecimal(rdr["ChargedTotalWithGst"]);
                                //rptModel.ReceivedDate = Convert.ToDateTime(rdr["ReceivedDate"]); 
                                
                                


                                rptList.Add(rptModel);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return rptList;

        }


        public IEnumerable<OtherReports> rptSubstanceLoadSummaryGet(  DateTime fromDate, DateTime toDate)
        {

            SqlConnection con = null;

            List<OtherReports> rptList = new List<OtherReports>();
            try
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptSubstanceLoadSummary", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);



                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                OtherReports rptModel = new OtherReports();


                                rptModel.DocketNo = rdr["DocketNo"].ToString();
                                rptModel.ReceivedDate = Convert.ToDateTime(rdr["ReceivedDate"]);
                                rptModel.VtNet = Convert.ToDecimal(rdr["VtNet"]);
                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();
                                rptModel.ApprovalCode = rdr["ApprovalCode"].ToString();
                                rptModel.Substance = rdr["Substance"].ToString();

                                rptList.Add(rptModel);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return rptList;

        }


        public IEnumerable<CenovusReport> rptCenovusGet(DateTime fromDate, DateTime toDate, int generatorId)
        {

            SqlConnection con = null;

            List<CenovusReport> rptList = new List<CenovusReport>();
            try
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptCenovus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //CONVERT(VARCHAR(10), GETDATE(), 110)
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                        cmd.Parameters.AddWithValue("@GeneratorId", generatorId);


                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                CenovusReport rptModel = new CenovusReport();


                                //rptModel.GeneratorName = rdr["GeneratorName"].ToString();

                                rptModel.ServiceMaterial = rdr["ServiceMaterial"].ToString(); //waste description
                                rptModel.ShipToParty = rdr["ShipToParty"].ToString();//lsd                                
                                rptModel.DocumentDate = Convert.ToDateTime(rdr["DocumentDate"]);//received date
                                rptModel.Dow = rdr["Dow"].ToString();//Substance Name

                                rptModel.WasteManifest = rdr["WasteManifest"].ToString();//Docket_No
                                rptModel.TruckCompany = rdr["TruckCompany"].ToString();//truck company
                                rptModel.TruckTicketNo = rdr["TruckTicketNo"].ToString();//scale ticket
                                rptModel.ProcessingVolume = Convert.ToDecimal(rdr["ProcessingVolume"]);//Gross
                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();


                                rptList.Add(rptModel);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return rptList;

        }


        public IEnumerable<OtherReports> rptGeneralSummaryGet(DateTime fromDate, DateTime toDate )
        {
            //Newell Regional Landfill - Load Summary by Generator

            SqlConnection con = null;

            List<OtherReports> rptList = new List<OtherReports>();
            try
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("spRptGeneralSummary", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //CONVERT(VARCHAR(10), GETDATE(), 110)
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                        //cmd.Parameters.AddWithValue("@GeneratorId", generatorId);


                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                OtherReports rptModel = new OtherReports();




                                rptModel.ScaleTicket = rdr["ScaleTicket"].ToString();
                                rptModel.DocketNo = rdr["DocketNo"].ToString();
                                if (!(rdr["ReceivedDate"] is DBNull))
                                    rptModel.ReceivedDate = Convert.ToDateTime(rdr["ReceivedDate"]);
                                rptModel.VtNet = Convert.ToDecimal(rdr["VtNet"]);
                                rptModel.GeneratorName = rdr["GeneratorName"].ToString();
                                rptModel.LocationLSD = rdr["LocationLSD"].ToString();
                                rptModel.ApprovalCode = rdr["ApprovalCode"].ToString();


                                rptList.Add(rptModel);

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return rptList;

        }
        #endregion
    }
}
 