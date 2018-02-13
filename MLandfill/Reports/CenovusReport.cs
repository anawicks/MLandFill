using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Reports
{
    public class CenovusReport
    {
         
        public String GeneratorName { get; set; }

        public String ServiceMaterial { get; set; }

        public String ShipToParty { get; set; }
        public String Dow { get; set; }
        public DateTime DocumentDate { get; set; }

        public String WasteManifest { get; set; }

        public String TruckCompany { get; set; }

        public String TruckTicketNo { get; set; }

        public decimal ProcessingVolume { get; set; }




    }
}