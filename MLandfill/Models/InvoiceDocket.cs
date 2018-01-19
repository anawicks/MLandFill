using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLandfill.Models
{
    public class InvoiceDocket
    {
        public int DocketId { get; set; }
        public string DocketNo { get; set; }
        public string WasteDescription { get; set; }

        public decimal Net { get; set; }

        public string ScaleTicket { get; set; }

        public decimal Rate { get; set; }

        public DateTime DateReceived { get; set; }

        public decimal Amount { get; set; }

        public string WasteApprovalCode { get; set; }

        public string GenerLocationLsd { get; set; }

        public string Comments { get; set; }

    }
}