using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Reports
{
    public class InvoiceModel
    {

        public int InvoiceNumber { get; set; }
        public string DocketNumber { get; set; }
        public string ScaleTicket { get; set; }
        public string ApprovalRate { get; set; }
        public DateTime DateReceived { get; set; }
        public decimal NetWeight { get; set; }
        public decimal AmountCharge { get; set; }

        public string WasteApprovalCode { get; set; }
        public decimal InvoiceTotal { get; set; }
        public int RecvMonth { get; set; }
        public int RecvYear { get; set; }
        public string WasteDescription { get; set; }

        public string WasteDescriptionCode { get; set; }
        public string WasteDescriptionInvoice { get; set; }
        public string GeneratorLocationLsd { get; set; }
        public string JOBNo { get; set; }
        public string AFENo { get; set; }
        public string PONo { get; set; }
        public bool ExcludeInterest { get; set; }

        public string GenContactName { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantAddr { get; set; }
        public string ConsultantCity { get; set; }
        public string ConsultantProv { get; set; }

        public string ConsultantPostal { get; set; }

        public int GeneratorId { get; set; }

        public string InvoiceeName { get; set; }

        

    }
}