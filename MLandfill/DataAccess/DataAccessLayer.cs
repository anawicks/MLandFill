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

    //MDockets
    public class DataAccessLayer
    {
        public int prgeneratorId { get; set; }
        public int prsubstanceId { get; set; }
        public int prgeneratorContactId { get; set; }

        public int prlsdId { get; set; }
        public int prinvoiceId { get; set; }
        public int prconsultantId { get; set; }
        public int prconsultantContactId { get; set; }

        public int prTruckCompId { get; set; }
        public int prWasteAppCodeId { get; set; }

        public string prWasteAppCode  { get; set; }

        public string prDocketNumber { get; set; }

        #region "Dockets"



        public IEnumerable<DocketGrid> docketsGridGet()
        {

            SqlConnection con = null;

            List<DocketGrid> ndocketList = new List<DocketGrid>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spDocketGridGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DocketGrid docket = new DocketGrid();


                docket.DocketId = Convert.ToInt32(rdr["DocketId"]);
                docket.ManifestNo = rdr["ManifestNo"].ToString();
                docket.Producer = rdr["Producer"].ToString();
                docket.Lsd = rdr["Lsd"].ToString();
                docket.WasteDescription = rdr["WasteDescription"].ToString();
                docket.ApprovalCode = rdr["ApprovalCode"].ToString();
                docket.Substance = rdr["Substance"].ToString();
                docket.TruckerCompany = rdr["TruckerCompany"].ToString();
                docket.DriverName = rdr["DriverName"].ToString();
                docket.DestinatedFor = rdr["DestinatedFor"].ToString();
                docket.ScaleTicket = rdr["ScaleTicket"].ToString();

                docket.Gross = Convert.ToDecimal(rdr["Gross"]);
                docket.Tare = Convert.ToDecimal(rdr["Tare"]);
                docket.Net = Convert.ToDecimal(rdr["Net"]);

                docket.Cell = rdr["Cell"].ToString();
                docket.Grid = rdr["Grid"].ToString();
                docket.GridNo = rdr["GridNo"].ToString();
                docket.Elevation = rdr["Elevation"].ToString();
                docket.JobDate = Convert.ToDateTime(rdr["JobDate"]);
                docket.Memo = rdr["Memo"].ToString();

                docket.InvoiceNumber = rdr["InvoiceNumber"].ToString();





                ndocketList.Add(docket);

            }
            return ndocketList;
        }



        public DocketViewModel DocketSingleGet(int docketId)
        //public IEnumerable<DocketViewModel> DocketSingleGet(int docketId)
        {




            SqlConnection con = null;

            List<DocketViewModel> ndocketList = new List<DocketViewModel>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spDocketWasteGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DocketId", docketId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();  
             DocketViewModel docket = new DocketViewModel();
            while (rdr.Read())
            {


                docket.DocketId = Convert.ToInt32(rdr["DocketId"]);
                docket.DocketNo = rdr["DocketNo"].ToString();
                docket.WApApprovalcode = rdr["WApApprovalcode"].ToString();  
                 
                if (!(rdr["WApApprovalId"] is DBNull))
                    docket.WApApprovalId = 0 + Convert.ToInt32(rdr["WApApprovalId"]);
                else
                    docket.WApApprovalId = 0;

                docket.TurckCompanyId = Convert.ToInt32(rdr["TruckCompId"]);
                docket.DriverName = rdr["DriverName"].ToString();
                docket.DestinatedFor = rdr["DestinatedFor"].ToString();
                docket.ScaleTicket = rdr["ScaleTicket"].ToString();

                docket.Gross = Convert.ToDecimal(rdr["Gross"]);
                docket.Tare = Convert.ToDecimal(rdr["Tare"]);
                docket.Net = Convert.ToDecimal(rdr["Net"]);

                docket.Cell = rdr["Cell"].ToString();
                docket.Grid = rdr["Grid"].ToString();
                docket.GridNo = rdr["GridNo"].ToString();
                docket.Elevation = rdr["Elevation"].ToString();

                docket.DateReceived = Convert.ToDateTime(rdr["ReceivedDate"]);
                docket.LoadReceivingDate = Convert.ToDateTime(rdr["ReceivedDate"]);
                docket.TruckCompName = rdr["TruckCompName"].ToString();
                docket.TruckCompAddr = rdr["TruckCompAddr"].ToString();
                docket.TruckCompCity = rdr["TruckCompCity"].ToString();
                docket.TruckCompProv = rdr["TruckCompProv"].ToString();
                docket.TruckCompPostal = rdr["TruckCompPostal"].ToString();
                docket.TruckCompPhone = rdr["TruckCompPhone"].ToString();

                docket.TruckCompId = Convert.ToInt32(rdr["TruckCompId"]);
                //docket.WApGeneratorId = Convert.ToInt32(rdr["WApGeneratorId"]);
                if (!(rdr["GeneratorId"] is DBNull))
                    docket.WApGeneratorId = 0 + Convert.ToInt32(rdr["GeneratorId"]);
                else
                    docket.WApGeneratorId = 0;
                docket.Memo = rdr["Memo"].ToString();
                docket.WApWasteDescrip = rdr["WApWasteDescrip"].ToString();

                if (!(rdr["SubstanceId"] is DBNull))
                    docket.WApSubId = 0 + Convert.ToInt32(rdr["SubstanceId"]);
                else
                    docket.WApSubId = 0;

                //docket.WApSubId = Convert.ToInt32(rdr["SubstanceId"]);

                
                docket.GeneratorName = rdr["GeneratorName"].ToString();
                docket.SubstanceName = rdr["SubstanceName"].ToString();

                if (!(rdr["GenerLocationId"] is DBNull))
                    docket.GenerLocationId = 0 + Convert.ToInt32(rdr["GenerLocationId"]);
                else
                    docket.GenerLocationId = 0;

                //docket.GenerLocationId = Convert.ToInt32(rdr["GenerLocationId"]);

                docket.GenerLocationLsd = rdr["GenerLocationLsd"].ToString();

                ndocketList.Add(docket);

            }
            return docket;



        }


        public void DocketUpdate(DocketViewModel docket)
        {
            DateTime d1 = new DateTime(1999, 1, 1);

            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDocketWasteUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DocketId", docket.DocketId);
                cmd.Parameters.AddWithValue("@DocketNo", docket.DocketNo);

                cmd.Parameters.AddWithValue("@WasteApprovalCode", docket.WasteApprovalCode);
                cmd.Parameters.AddWithValue("@WasteApprovalId", prWasteAppCodeId);
                cmd.Parameters.AddWithValue("@TurckCompanyId", prTruckCompId); 
                cmd.Parameters.AddWithValue("@DriverName", docket.DriverName);
                cmd.Parameters.AddWithValue("@DestinatedFor", docket.DestinatedFor);
                cmd.Parameters.AddWithValue("@ScaleTicket", docket.ScaleTicket);
                cmd.Parameters.AddWithValue("@Gross", docket.Gross);
                cmd.Parameters.AddWithValue("@Tare", docket.Tare);
                cmd.Parameters.AddWithValue("@Net", docket.Net);
                cmd.Parameters.AddWithValue("@Cell", docket.Cell);
                cmd.Parameters.AddWithValue("@Grid", docket.Grid);
                cmd.Parameters.AddWithValue("@GridNo", docket.GridNo);
                cmd.Parameters.AddWithValue("@Elevation", docket.Elevation);
                cmd.Parameters.AddWithValue("@DateReceived", docket.DateReceived);
                cmd.Parameters.AddWithValue("@Memo", docket.Memo);
                cmd.Parameters.AddWithValue("@InvoiceNo", docket.InvoiceNo);
                if (docket.LoadReceivingDate > d1)
                    cmd.Parameters.AddWithValue("@LoadReceivingDate", docket.LoadReceivingDate);

                con.Open();

                cmd.ExecuteNonQuery();
            }


        }


        public int DocketAdd(DocketViewModel docket)
        {
            int docketIdOut=0;

            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand("spDocketWasteAddNew", con))
                { 
                    cmd.CommandType = CommandType.StoredProcedure;
 
                    try
                    {
                        cmd.Parameters.Clear();

                    
                    
                        cmd.Parameters.AddWithValue("@DocketNo", docket.DocketNo);
                        cmd.Parameters.AddWithValue("@WasteApprovalCodeID", docket.WApApprovalId);//docket.WApApprovalcode

                        cmd.Parameters.AddWithValue("@TurckCompanyId", docket.TruckCompId);
                        cmd.Parameters.AddWithValue("@DriverName", docket.DriverName);
                        cmd.Parameters.AddWithValue("@DestinatedFor", docket.DestinatedFor);
                        cmd.Parameters.AddWithValue("@ScaleTicket", docket.ScaleTicket);
                        cmd.Parameters.AddWithValue("@Gross", docket.Gross);

                        cmd.Parameters.AddWithValue("@Tare", docket.Tare);
                        cmd.Parameters.AddWithValue("@Net", docket.Net);
                        cmd.Parameters.AddWithValue("@Cell", docket.Cell);
                        cmd.Parameters.AddWithValue("@Grid", docket.Grid);
                        cmd.Parameters.AddWithValue("@GridNo", docket.GridNo);

                        cmd.Parameters.AddWithValue("@Elevation", docket.Elevation);
                        cmd.Parameters.AddWithValue("@DateReceived", docket.DateReceived);
                        cmd.Parameters.AddWithValue("@Memo", docket.Memo);
                        cmd.Parameters.AddWithValue("@InvoiceNo", docket.InvoiceNo);
                        cmd.Parameters.AddWithValue("@LoadReceivingDate", docket.DateReceived);

                        cmd.Parameters.Add("@DocketIdOut", SqlDbType.Int);
                        cmd.Parameters["@DocketIdOut"].Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        docketIdOut =  Convert.ToInt32(cmd.Parameters["@DocketIdOut"].Value);
                    }


                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex.Message);
                    }

                }
            }

            return docketIdOut;
        }
        private void UpdateInvoice(DocketViewModel docket)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDocketWasteAddNew", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //GET THE NEW InvoiceNumber from tblInvoice and add that value to @InvoiceNo
                //also insert the other values to the tblInvoice
                //insert a record to tblLandFillWasteDocketsHistory


                try
                {


                    cmd.Parameters.AddWithValue("@DocketNo", docket.DocketNo);

                    cmd.Parameters.AddWithValue("@WasteApprovalCode", docket.WApApprovalcode);
                    cmd.Parameters.AddWithValue("@InvoiceeId", docket.InvoiceeId);
                    cmd.Parameters.AddWithValue("@TurckCompanyId", docket.TruckCompId);
                    cmd.Parameters.AddWithValue("@DriverName", docket.DriverName);
                    cmd.Parameters.AddWithValue("@DestinatedFor", docket.DestinatedFor);
                    cmd.Parameters.AddWithValue("@ScaleTicket", docket.ScaleTicket);
                    cmd.Parameters.AddWithValue("@Gross", docket.Gross);
                    cmd.Parameters.AddWithValue("@Tare", docket.Tare);
                    cmd.Parameters.AddWithValue("@Net", docket.Net);
                    cmd.Parameters.AddWithValue("@Cell", docket.Cell);
                    cmd.Parameters.AddWithValue("@Grid", docket.Grid);
                    cmd.Parameters.AddWithValue("@GridNo", docket.GridNo);
                    cmd.Parameters.AddWithValue("@Elevation", docket.Elevation);
                    cmd.Parameters.AddWithValue("@DateReceived", docket.DateReceived);
                    cmd.Parameters.AddWithValue("@Memo", docket.Memo);
                    cmd.Parameters.AddWithValue("@InvoiceNo", docket.InvoiceNo);
                    cmd.Parameters.AddWithValue("@LoadReceivingDate", docket.DateReceived);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);
                }

            }


        }
        public IEnumerable<ModelDockets> docketsAllGet()
        {

            SqlConnection con = null;

            List<ModelDockets> ndocketList = new List<ModelDockets>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spDocketWasteGetAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ModelDockets docket = new ModelDockets();

                docket.DocketId = Convert.ToInt32(rdr["DocketId"]);
                docket.DocketNo = rdr["DocketNo"].ToString();
                docket.WasteApprovalCode = rdr["WasteApprovalCode"].ToString();
                docket.InvoiceeId = Convert.ToInt32(rdr["InvoiceeId"]);
                docket.TurckCompanyId = Convert.ToInt32(rdr["TurckCompanyId"]);
                docket.DriverName = rdr["DriverName"].ToString();
                docket.DestinatedFor = rdr["DestinatedFor"].ToString();
                docket.ScaleTicket = rdr["ScaleTicket"].ToString();

                docket.Gross = Convert.ToDecimal(rdr["Gross"]);
                docket.Tare = Convert.ToDecimal(rdr["Tare"]);
                docket.Net = Convert.ToDecimal(rdr["Net"]);

                docket.Cell = rdr["Cell"].ToString();
                docket.Grid = rdr["Grid"].ToString();
                docket.GridNo = rdr["GridNo"].ToString();
                docket.GridNo = rdr["Elevation"].ToString();

                docket.DateReceived = Convert.ToDateTime(rdr["DateReceived"]);

                docket.TruckCompName = rdr["TruckCompName"].ToString();
                docket.TruckCompAddr = rdr["TruckCompAddr"].ToString();
                docket.TruckCompCity = rdr["TruckCompCity"].ToString();
                docket.TruckCompProv = rdr["TruckCompProv"].ToString();
                docket.TruckCompPostal = rdr["TruckCompPostal"].ToString();
                docket.TruckCompPhone = rdr["TruckCompPhone"].ToString();

                docket.TruckCompId = Convert.ToInt32(rdr["TruckCompId"]);
                docket.WApGeneratorId = Convert.ToInt32(rdr["WApGeneratorId"]);

                docket.WApWasteDescrip = rdr["WApWasteDescrip"].ToString();

                docket.WApSubId = Convert.ToInt32(rdr["WApSubId"]);

                docket.WApApprovalcode = rdr["WApApprovalcode"].ToString();
                docket.GeneratorName = rdr["GeneratorName"].ToString();
                docket.SubstanceName = rdr["SubstanceName"].ToString();

                docket.GenerLocationId = Convert.ToInt32(rdr["GenerLocationId"]);

                docket.GenerLocationLsd = rdr["GenerLocationLsd"].ToString();

                ndocketList.Add(docket);

            }
            return ndocketList;
        }

       public void DocketDelete(int docketId)
        {

           

            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDocketWasteDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocketId", docketId);

                con.Open();

                cmd.ExecuteNonQuery();
            }


        }

        #endregion

        #region "Invoice Docket"
        //InvoiceDocket

        public IEnumerable<InvoiceDocket> InvoiceDocketsGet(int generatorId, string month, int year, string approvalCode)
        {

            SqlConnection con = null;

            List<InvoiceDocket> ndocketList = new List<InvoiceDocket>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("InvoiceOfDocketsGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GeneratorId", generatorId);
            cmd.Parameters.AddWithValue("@Month", month);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@WasteApprovalCode", approvalCode);




            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                InvoiceDocket docket = new InvoiceDocket();

                docket.DocketId = Convert.ToInt32(rdr["DocketId"]);
                docket.DocketNo = rdr["DocketNo"].ToString();
                docket.WasteDescription = rdr["WasteDescription"].ToString();
                docket.Net = Convert.ToDecimal(rdr["Net"]);
                docket.ScaleTicket = rdr["ScaleTicket"].ToString();
                docket.Rate = Convert.ToDecimal(rdr["Rate"]);
                docket.DateReceived = Convert.ToDateTime(rdr["DateReceived"]);
                docket.Amount = Convert.ToDecimal(rdr["Amount"]);
                docket.WasteApprovalCode = rdr["WasteApprovalCode"].ToString();
                docket.GenerLocationLsd = rdr["GenerLocationLsd"].ToString();
                docket.Comments = rdr["Comments"].ToString();


                //if (!(rdr["InvoiceeId"] is DBNull))
                //    docket.InvoiceeId = 0 + Convert.ToInt32(rdr["InvoiceeId"]);
                //else
                //    docket.InvoiceeId = 11;


                ndocketList.Add(docket);

            }
            return ndocketList;

        }

        public IEnumerable<tblGenerator> InvoiceGeneratosGet(string month, int year)
        {

            SqlConnection con = null;

            List<tblGenerator> ndocketList = new List<tblGenerator>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("InvoiceGeneratorsGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Month", month);
            cmd.Parameters.AddWithValue("@Year", year);




            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tblGenerator generators = new tblGenerator();

                generators.GeneratorName = rdr["GeneratorName"].ToString();
                generators.GeneratorId = Convert.ToInt32(rdr["GeneratorId"]);




                ndocketList.Add(generators);

            }
            return ndocketList;

        }


        public IEnumerable<tblLandFillWasteDocket> InvoiceWasteAppCodesGet(int generatorId, string month, int year)
        {

            SqlConnection con = null;

            List<tblLandFillWasteDocket> ndocketList = new List<tblLandFillWasteDocket>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("InvoiceApprovalCodeGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GeneratorId", generatorId);
            cmd.Parameters.AddWithValue("@Month", month);
            cmd.Parameters.AddWithValue("@Year", year);




            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tblLandFillWasteDocket wasteAppCodes = new tblLandFillWasteDocket();

                wasteAppCodes.WasteApprovalCode = rdr["WasteApprovalCode"].ToString();





                ndocketList.Add(wasteAppCodes);

            }
            return ndocketList;

        }


        #endregion

        #region "TableMaintenance"


        public IEnumerable<tblMaintWasteApCode> WasteApprovalCodeAllGet()
        {

            SqlConnection con = null;

            List<tblMaintWasteApCode> nWstAppCode = new List<tblMaintWasteApCode>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spWasteApprovalGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tblMaintWasteApCode WstAppCode = new tblMaintWasteApCode();

                WstAppCode.WApApprovalId = Convert.ToInt32(rdr["WApApprovalId"]);
                WstAppCode.WApCreateDate = Convert.ToDateTime(rdr["WApCreateDate"]);
                WstAppCode.WApApprovalcode = rdr["WApApprovalcode"].ToString();
                WstAppCode.WApGeneratorId = Convert.ToInt32(rdr["WApGeneratorId"]);
                WstAppCode.GeneratorName = rdr["GeneratorName"].ToString();
                WstAppCode.WApWasteDescrip = rdr["WApWasteDescrip"].ToString();
                WstAppCode.WApSubId = Convert.ToInt32(rdr["WApSubId"]);
                WstAppCode.SubstanceName = rdr["SubstanceName"].ToString();
                WstAppCode.WApLocationId = Convert.ToInt32(rdr["WApLocationId"]);
                WstAppCode.GenerLocationLsd = rdr["GenerLocationLsd"].ToString();

                if (!(rdr["WApMinCharge"] is DBNull))
                    WstAppCode.WApMinCharge = Convert.ToBoolean(rdr["WApMinCharge"]);
                else
                    WstAppCode.WApMinCharge = false;

               nWstAppCode.Add(WstAppCode);

            }
            return nWstAppCode;
        }



        public IEnumerable<tblMaintWasteApCode> WasteAppCodeSingleGet(int Id)
        {




            SqlConnection con = null;

            List<tblMaintWasteApCode> nwasteAppCode = new List<tblMaintWasteApCode>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spWasteApprovalCodeGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@WApApprovalId", Id);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tblMaintWasteApCode wasteCode = new tblMaintWasteApCode();

                wasteCode.WApApprovalId = Convert.ToInt32(rdr["WApApprovalId"]);

                wasteCode.WApCreateDate = Convert.ToDateTime(rdr["WApCreateDate"]);
                wasteCode.WApApprovalcode = rdr["WApApprovalcode"].ToString();
                wasteCode.WApGeneratorId = Convert.ToInt32(rdr["WApGeneratorId"]);
                wasteCode.GeneratorName = rdr["GeneratorName"].ToString();
                wasteCode.WApWasteDescrip = rdr["WApWasteDescrip"].ToString();
                wasteCode.WApSubId = Convert.ToInt32(rdr["WApSubId"]);
                wasteCode.SubstanceName = rdr["SubstanceName"].ToString();
                wasteCode.WApLocationId = Convert.ToInt32(rdr["WApLocationId"]);
                wasteCode.GenerLocationLsd = rdr["GenerLocationLsd"].ToString();

                wasteCode.WApGenContactId = Convert.ToInt32(rdr["WApGenContactId"]);
                wasteCode.WApExpiryDate = Convert.ToDateTime(rdr["WApExpiryDate"]);
                wasteCode.WApRate = Convert.ToDecimal(rdr["WApRate"]);
                wasteCode.WApComments = rdr["WApComments"].ToString();

                wasteCode.WApExtQuantity = Convert.ToDouble(rdr["WApExtQuantity"]);
                wasteCode.WApApproved = Convert.ToBoolean(rdr["WApApproved"]);
                wasteCode.WApMailMerge = Convert.ToBoolean(rdr["WApMailMerge"]);


                wasteCode.WApJobNo = rdr["WApJobNo"].ToString();
                wasteCode.WApAfeNo = rdr["WApAfeNo"].ToString();
                wasteCode.WApPoNo = rdr["WApPoNo"].ToString();

                wasteCode.WApConsultantId = Convert.ToInt32(rdr["WApConsultantId"]);
                wasteCode.WApConContactID = Convert.ToInt32(rdr["WApConContactID"]);

                wasteCode.WApAdcApproved = Convert.ToBoolean(rdr["WApAdcApproved"]);

                if (!(rdr["WApInvoicee"] is DBNull))
                    wasteCode.WApInvoicee = 0 + Convert.ToInt32(rdr["WApInvoicee"]);




                wasteCode.WApWasteDescriptionMailMerge = rdr["WApWasteDescriptionMailMerge"].ToString();
                if (!(rdr["WApMinCharge"] is DBNull))
                    wasteCode.WApMinCharge = Convert.ToBoolean(rdr["WApMinCharge"]);

                wasteCode.GenerContactName = rdr["GenerContactName"].ToString();
                wasteCode.GenerContactPhone = rdr["GenerContactPhone"].ToString();
                wasteCode.ConsultantName = rdr["ConsultantName"].ToString();
                wasteCode.ConsultantContactName = rdr["ConsultantContactName"].ToString();
                wasteCode.ConsultantContactPhone = rdr["ConsultantContactPhone"].ToString();
                wasteCode.InvoiceeName = rdr["InvoiceeName"].ToString();




                nwasteAppCode.Add(wasteCode);

            }
            return nwasteAppCode;



        }

        public void WasteAppCodeUpdate(tblMaintWasteApCode wstAppCode)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spWasteApprovalUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WApApprovalcode", wstAppCode.WApApprovalcode);
                cmd.Parameters.AddWithValue("@WApApprovalId", wstAppCode.WApApprovalId);
                cmd.Parameters.AddWithValue("@WApCreateDate", wstAppCode.WApCreateDate);
                cmd.Parameters.AddWithValue("@WApGeneratorId", prgeneratorId);

                cmd.Parameters.AddWithValue("@WApWasteDescrip", wstAppCode.WApWasteDescrip);
                cmd.Parameters.AddWithValue("@WApSubId", prsubstanceId);
                cmd.Parameters.AddWithValue("@WApLocationId", prlsdId);
                cmd.Parameters.AddWithValue("@WApRate", wstAppCode.WApRate);
                cmd.Parameters.AddWithValue("@WApExtQuantity", wstAppCode.WApExtQuantity);
                cmd.Parameters.AddWithValue("@WApApproved", wstAppCode.WApApproved);


                cmd.Parameters.AddWithValue("@WApJobNo", wstAppCode.WApJobNo);
                cmd.Parameters.AddWithValue("@WApAfeNo", wstAppCode.WApAfeNo);
                cmd.Parameters.AddWithValue("@WApPoNo", wstAppCode.WApPoNo);
                cmd.Parameters.AddWithValue("@WApWasteDescriptionMailMerge", wstAppCode.WApWasteDescriptionMailMerge);
                cmd.Parameters.AddWithValue("@WApGenContactId", prgeneratorContactId);

                cmd.Parameters.AddWithValue("@WApConsultantId", prconsultantId);
                cmd.Parameters.AddWithValue("@WApConContactID", prconsultantContactId);
                cmd.Parameters.AddWithValue("@WApInvoicee", prinvoiceId);
                cmd.Parameters.AddWithValue("@WApExpiryDate", wstAppCode.WApExpiryDate);




                cmd.Parameters.AddWithValue("@WApComments", wstAppCode.WApComments);
                cmd.Parameters.AddWithValue("@WApMailMerge", wstAppCode.WApMailMerge);
                cmd.Parameters.AddWithValue("@WApAdcApproved", wstAppCode.WApAdcApproved);
                cmd.Parameters.AddWithValue("@WApMinCharge", wstAppCode.WApMinCharge);










                con.Open();

                cmd.ExecuteNonQuery();
            }


        }

        public void WasteAppCodeAddNew(tblMaintWasteApCode wstAppCode)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spWasteApprovalAddNew", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WApApprovalcode", wstAppCode.WApApprovalcode + SubstanceCodeGet(prsubstanceId));
                cmd.Parameters.AddWithValue("@WApGeneratorId", prgeneratorId);

                cmd.Parameters.AddWithValue("@WApWasteDescrip", wstAppCode.WApWasteDescrip);
                cmd.Parameters.AddWithValue("@WApSubId", prsubstanceId);
                cmd.Parameters.AddWithValue("@WApCreateDate", wstAppCode.WApCreateDate);
                cmd.Parameters.AddWithValue("@WApGenContactId", prgeneratorContactId);
                cmd.Parameters.AddWithValue("@WApExpiryDate", wstAppCode.WApExpiryDate);
                cmd.Parameters.AddWithValue("@WApRate", wstAppCode.WApRate);
                cmd.Parameters.AddWithValue("@WApComments", wstAppCode.WApComments);
                cmd.Parameters.AddWithValue("@WApExtQuantity", wstAppCode.WApExtQuantity);
                cmd.Parameters.AddWithValue("@WApApproved", wstAppCode.WApApproved);
                cmd.Parameters.AddWithValue("@WApMailMerge", wstAppCode.WApMailMerge);
                cmd.Parameters.AddWithValue("@WApJobNo", wstAppCode.WApJobNo);
                cmd.Parameters.AddWithValue("@WApAfeNo", wstAppCode.WApAfeNo);
                cmd.Parameters.AddWithValue("@WApPoNo", wstAppCode.WApPoNo);
                cmd.Parameters.AddWithValue("@WApLocationId", prlsdId);
                cmd.Parameters.AddWithValue("@WApConsultantId", wstAppCode.WApConsultantId);
                cmd.Parameters.AddWithValue("@WApConContactID", wstAppCode.WApConContactID);
                cmd.Parameters.AddWithValue("@WApAdcApproved", wstAppCode.WApAdcApproved);
                cmd.Parameters.AddWithValue("@WApInvoicee", prinvoiceId);
                cmd.Parameters.AddWithValue("@WApWasteDescriptionMailMerge", wstAppCode.WApWasteDescriptionMailMerge);
                cmd.Parameters.AddWithValue("@WApMinCharge", wstAppCode.WApMinCharge);

                con.Open();

                cmd.ExecuteNonQuery();
            }


        }

        public int ApprovalCodeIdNextGet()
        {
            int identCurrent = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spWasteApprovalIndentGet", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    identCurrent = Convert.ToInt32(rdr["NextIdentValue"]);
                }
            }

            return identCurrent;
        }



        private string SubstanceCodeGet(int substanceId)
        {
            string sibstanceCode = string.Empty;

            
            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSubstanceCodeGet", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SubstanceId", substanceId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    sibstanceCode = " " + rdr["SubstanceCode"].ToString();

                }

                

            }
            return sibstanceCode;

           



        }
        public int NewInvoiceNoGet( int month, int year, int generatorId, string approvalCode)
        {
            int newInvoiceNo=0 ;


            string connectionString = ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInvoiceMainSet", con);

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@generatorId", generatorId);
                cmd.Parameters.AddWithValue("@approvalCode", approvalCode);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    newInvoiceNo = Convert.ToInt32(rdr["NewInvoiceNumber"]);

                }



            }
            return newInvoiceNo;





        }
        private string SubstanceCodeGetA(int substanceId)
        {
            string sibstanceCode = string.Empty;

            SqlConnection con = null;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spSubstanceCodeGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubstanceId", substanceId);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                sibstanceCode = " " + rdr["SubstanceCode"].ToString();

            }

            return sibstanceCode;
            

           
        }



        #endregion

        #region "Invoice Generate"

        public IEnumerable<InvoiceBatchGrid> InvoiceBatchGridGet(string month, int year)
        {



            SqlConnection con = null;

            List<InvoiceBatchGrid> nInvoiceBatch = new List<InvoiceBatchGrid>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spInvoiceBatchGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                InvoiceBatchGrid InvBatch = new InvoiceBatchGrid();

                InvBatch.GeneratorName = rdr["GeneratorName"].ToString();
                InvBatch.WApApprovalcode = rdr["WApApprovalcode"].ToString();

                InvBatch.WApWasteDescrip = rdr["WApWasteDescrip"].ToString();
                InvBatch.WApRate = Convert.ToDecimal(rdr["WApRate"]);

                InvBatch.NetTotal = Convert.ToDecimal(rdr["NetTotal"]);
                InvBatch.Amount = Convert.ToDecimal(rdr["Amount"]);

                InvBatch.GeneratorId = Convert.ToInt32(rdr["GeneratorId"]);                
                InvBatch.WApComments = rdr["WApComments"].ToString(); 





                nInvoiceBatch.Add(InvBatch);

            }
            return nInvoiceBatch;



        }


        public List<DataRow> InvoiceRptInfoGetList(int invoiceNo)
        {

            DataTable table = new DataTable();
            DataSet ds = new DataSet();
            //List<string> dsList = new List<string>();

            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInvoicePrintGet", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceNo);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(ds);

                    }
                }
            }
            List<DataRow> dsList = ds.Tables[0].Rows.Cast<DataRow>().ToList();
 
            return dsList;
        }

        public List<DataRow> InvoiceRptInfoGetA(int invoiceNo)
        {

            DataTable table = new DataTable();
            DataSet ds = new DataSet();
            //List<string> dsList = new List<string>();

            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInvoicePrintGet", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceNo);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(ds);

                    }
                }
            }
            List<DataRow> dsList = ds.Tables[0].Rows.Cast<DataRow>().ToList();
            //http://www.danielroot.info/2009/06/how-to-render-reporting-services.html
            return dsList;
        }

        public IEnumerable<InvoiceModel> InvoiceRptInfoGet(int invoiceNumber)
        {

            SqlConnection con = null;

            List<InvoiceModel> ndocketList = new List<InvoiceModel>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spInvoicePrintGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);




            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                InvoiceModel docket = new InvoiceModel();

                docket.InvoiceNumber = Convert.ToInt32(rdr["InvoiceNumber"]);
                docket.DocketNumber = rdr["DocketNumber"].ToString();
                docket.ScaleTicket = rdr["ScaleTicket"].ToString();
                docket.ApprovalRate = rdr["ApprovalRate"].ToString();
                docket.DateReceived = Convert.ToDateTime(rdr["DateReceived"]);
                docket.NetWeight = Convert.ToDecimal(rdr["NetWeight"]);
                docket.AmountCharge = Convert.ToDecimal(rdr["AmountCharge"]);

                docket.WasteApprovalCode = rdr["WasteApprovalCode"].ToString();
                docket.InvoiceTotal = Convert.ToDecimal(rdr["InvoiceTotal"]);
                docket.RecvMonth = Convert.ToInt32(rdr["RecvMonth"]);
                docket.RecvYear = Convert.ToInt32(rdr["RecvYear"]);


                docket.WasteDescription = rdr["WasteDescription"].ToString();
                docket.WasteDescriptionCode = rdr["WasteDescriptionCode"].ToString();
                docket.WasteDescriptionInvoice = rdr["WasteDescriptionInvoice"].ToString();
                docket.GeneratorLocationLsd = rdr["GeneratorLocationLsd"].ToString();
                docket.JOBNo = rdr["JOBNo"].ToString();
                docket.AFENo = rdr["AFENo"].ToString();
                docket.PONo = rdr["PONo"].ToString();

                docket.ExcludeInterest = Convert.ToBoolean(rdr["ExcludeInterest"]);

                docket.GenContactName = rdr["GenContactName"].ToString();
                docket.ConsultantName = rdr["ConsultantName"].ToString();
                docket.ConsultantAddr = rdr["ConsultantAddr"].ToString();
                docket.ConsultantCity = rdr["ConsultantCity"].ToString();
                docket.ConsultantProv = rdr["ConsultantProv"].ToString();
                docket.ConsultantPostal = rdr["ConsultantPostal"].ToString(); 





                if (!(rdr["GeneratorId"] is DBNull))
                    docket.GeneratorId = 0 + Convert.ToInt32(rdr["GeneratorId"]);
                else
                    docket.GeneratorId = 11;

                docket.InvoiceeName = rdr["InvoiceeName"].ToString();
                ndocketList.Add(docket);

            }
            return ndocketList;

        }





        #endregion

        #region "ApprovalCode"
        //DocketViewModel
        public  DocketViewModel approvalCodeRelatedGet(int approvalCodeId)
        {

            SqlConnection con = null;

            List<DocketViewModel> ndocketList = new List<DocketViewModel>();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
            SqlCommand cmd = new SqlCommand("spWasteAppCodeReletedGet", con);
            cmd.Parameters.AddWithValue("@WApApprovalId", approvalCodeId);
            cmd.CommandType = CommandType.StoredProcedure;
            DocketViewModel docket = new DocketViewModel();
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
               
 
                docket.GeneratorName = rdr["GeneratorName"].ToString();
                docket.SubstanceName = rdr["SubstanceName"].ToString();
                docket.GenerLocationLsd = rdr["GenerLocationLsd"].ToString();


                ndocketList.Add(docket);

            }
            return docket;
        }
        //SqlConnection con = null;

        //List<DocketGrid> ndocketList = new List<DocketGrid>();
        //con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccessCn"].ToString());
        //SqlCommand cmd = new SqlCommand("spDocketGridGet", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //con.Open();
        //SqlDataReader rdr = cmd.ExecuteReader();
        #endregion



    }
}
 