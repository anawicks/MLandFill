using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MLandfill.Core.Domain;
using MLandfill.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MLandfill.ViewModel
{
    public class DocketViewModel
    {
        private DateTime _createdOn = DateTime.MinValue;

        [Key]
        public int DocketId { get; set; }
       [Required]
       [DisplayName("Docket No")]
        public string DocketNo { get; set; }
        [DisplayName("Approval Code")]
        public string WasteApprovalCode { get; set; }
        public int InvoiceeId { get; set; }
      
        public int TurckCompanyId { get; set; }

        [DisplayName("Driver")]
        public string DriverName { get; set; }
        [DisplayName("Destinated For")]
        public string DestinatedFor { get; set; }
        [DisplayName("Scale Ticket")]
        public string ScaleTicket { get; set; }
        
        public decimal Gross { get; set; }
        public decimal Tare { get; set; }
        [Required]
        public decimal Net { get; set; }
        public string Cell { get; set; }
        public string Grid { get; set; }
        [DisplayName("Grid No")]
        public string GridNo { get; set; }
        public string Elevation { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayName("Received Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime DateReceived { get; set; }
        public DateTime DateReceived
        {
            get
            {
                return (_createdOn == DateTime.MinValue) ? DateTime.Now : _createdOn;
            }
            set { _createdOn = value; }
        }
        public string Memo { get; set; }
        [DisplayName("Invoice No")]
        public string InvoiceNo { get; set; }
        [DisplayName("Load Received Date")]
        public DateTime LoadReceivingDate { get; set; }
        [DisplayName("DocketNo")]
        public string TruckCompName { get; set; }
        [DisplayName("Address")]
        public string TruckCompAddr { get; set; }
        [DisplayName("City")]
        public string TruckCompCity { get; set; }
        [DisplayName("Province")]
        public string TruckCompProv { get; set; }
        [DisplayName("Postal Code")]
        public string TruckCompPostal { get; set; }
        [DisplayName("Phone")]
        public string TruckCompPhone { get; set; }
        public int TruckCompId { get; set; }
        public int WApGeneratorId { get; set; }
        [DisplayName("DocketNo")]
        public string WApWasteDescrip { get; set; }
        public int WApSubId { get; set; }
        [DisplayName("Approval Code")]
        public string WApApprovalcode { get; set; }
        [Required]
        public int   WApApprovalId { get; set; }
        [DisplayName("Generator")]
        public string GeneratorName { get; set; }
        [DisplayName("Substance")]
        public string SubstanceName { get; set; }
        public int GenerLocationId { get; set; }
        [DisplayName("Location Lsd")]
        public string GenerLocationLsd { get; set; }
        public IEnumerable<tblGenerator> tblGenerators { get; set; }

        public IEnumerable<tblGenerator> ddGenerators { get; set; }
         

        public List<tblSubstance> ddSubstance { get; set; }

        

        public List<tblGeneratorLocation> ddLocations { get; set; }

        public List<tblTruckCompany> ddTruckCompany { get; set; }
        public IEnumerable<tblGenerator> tblGenerator { get; internal set; }

        public List<tblWasteApproval> ddWasteApproval  { get; set; }
}
}