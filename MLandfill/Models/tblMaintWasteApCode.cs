using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Models
{
    public class tblMaintWasteApCode
    {
        private DateTime _createdOn = DateTime.MinValue;

        [Key]
        public int WApApprovalId { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime WApCreateDate { get; set; }
        public DateTime WApCreateDate
        {
            get
            {
                return (_createdOn == DateTime.MinValue) ? DateTime.Now : _createdOn;
            }
            set { _createdOn = value; }
        }

        [Display(Name = "Approval Code")]
        public string WApApprovalcode { get; set; }

        public int WApGeneratorId { get; set; }

        [Display(Name = "Generator Name")]
        public string GeneratorName { get; set; }
        [Display(Name = "Waste Desciption")]
        public string WApWasteDescrip { get; set; }

        public int WApSubId { get; set; }
        [Display(Name = "Substance Name")]
        public string SubstanceName { get; set; }


        public int WApLocationId { get; set; }
        [Display(Name = "Location LSD")]
        public string GenerLocationLsd { get; set; }
        
        public int WApGenContactId { get; set; }
        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //public DateTime WApExpiryDate { get; set; }
        public DateTime WApExpiryDate
        {
            get
            {
                return (_createdOn == DateTime.MinValue) ? DateTime.Now : _createdOn;
            }
            set { _createdOn = value; }
        }

        [Display(Name = "Rate")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal WApRate { get; set; }

        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string WApComments { get; set; }
        [Display(Name = "Ext Quantity")]
        public double WApExtQuantity { get; set; }
        [Display(Name = "Approved ?")]
        public bool WApApproved { get; set; }
        [Display(Name = "Mail Merged ?")]
        public bool WApMailMerge { get; set; }
        [Display(Name = "Job No")]
        public string WApJobNo { get; set; }
        [Display(Name = "AFE No")]
        public string WApAfeNo { get; set; }
        [Display(Name = "PO No")]
        public string WApPoNo { get; set; }
        public int WApConsultantId { get; set; }
        public int WApConContactID { get; set; }

        public bool WApAdcApproved { get; set; }
        [Display(Name = "Invoicee")]
        public int WApInvoicee { get; set; }
        [Display(Name ="Merge Description")]
        public string WApWasteDescriptionMailMerge { get; set; }
        public bool WApMinCharge { get; set; }
        [Display(Name = "Generator Contact")]
        
        public string GenerContactName { get; set; }
        [Display(Name = "Gen. Contact Phone")]
        public string GenerContactPhone { get; set; }
        [Display(Name = "Consultant Name")]
        public string ConsultantName { get; set; }
        [Display(Name = "Consultant Contact")]
        public string ConsultantContactName { get; set; }
        [Display(Name = "Cons. Contact Phone")]
        public string ConsultantContactPhone { get; set; }
      
        [Display(Name = "Invoicee")]
        public string InvoiceeName { get; set; }
        public IEnumerable<tblGenerator> tblGenerators { get; set; }

        public IEnumerable<tblGenerator> ddGenerators { get; set; }


        public List<tblSubstance> ddSubstance { get; set; }


        public List<tblConsultant> ddconsultants { get; set; }
        public List<tblGeneratorLocation> ddLocations { get; set; }
        public List<tblInvoicee> ddInvoicee { get; set; }
        //public List<tblInvoiceesDd> ddInvoiceeD { get; set; }
        public List<tblTruckCompany> ddTruckCompany { get; set; }
        public IEnumerable<tblGenerator> tblGenerator { get; internal set; }

        public List<tblWasteApproval> ddWasteApproval { get; set; }
    }
}