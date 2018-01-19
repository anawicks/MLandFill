using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Models
{
    public class DocketGrid
    {
        
     
        [Key]
        public int DocketId { get; set; }
        public string ManifestNo { get; set; }

        public string Producer { get; set; }
        public string Lsd { get; set; }
        public string WasteDescription { get; set; }

        public string ApprovalCode { get; set; }
        public string Substance { get; set; }

        public string TruckerCompany { get; set; }

        public string DriverName { get; set; }
        public string DestinatedFor { get; set; }
        public string ScaleTicket { get; set; }

        public decimal Gross { get; set; }
        public decimal Tare { get; set; }
        public decimal Net { get; set; }

        public string Cell { get; set; }
        public string Grid { get; set; }

        public string GridNo { get; set; }
        public string Elevation { get; set; }

        public DateTime JobDate { get; set; }
    
        public string Memo { get; set; }
        public string InvoiceNumber { get; set; }


    }
}