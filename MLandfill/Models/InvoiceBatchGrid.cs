using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Models
{
    public class InvoiceBatchGrid
    {
        [Key]
        public string WApApprovalcode { get; set; }
        public string GeneratorName { get; set; }

        public string WApWasteDescrip { get; set; }

        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal WApRate { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal NetTotal { get; set; }

        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        public int GeneratorId { get; set; }

        public string WApComments { get; set; }

    }
}