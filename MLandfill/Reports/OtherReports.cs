using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Reports
{
    public class OtherReports
    {
        public String GeneratorName { get; set; }

        public String ScaleTicket { get; set; }

        public String DocketNo { get; set; }

        public decimal VtNet { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal GstAmount { get; set; }

        public DateTime ReceivedDate { get; set; }
        public String LocationLSD { get; set; }
        public String ApprovalCode { get; set; }
        public String Cell { get; set; }
        public String Grid { get; set; }
        public String GridNo { get; set; }
        public String Elevation { get; set; }
        public String Substance { get; set; }

        public String WasteLocation { get; set; }

        public Decimal ChargedTotal { get; set; }

        public Decimal ChargedTotalWithGst { get; set; }


    }
}