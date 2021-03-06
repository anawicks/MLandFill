﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MLandfill.Models
{
    public class ModelDockets
    {

        [Key]
        public int DocketId { get; set; }
        public string DocketNo { get; set; }
        public string WasteApprovalCode { get; set; }
        public int InvoiceeId { get; set; }
        public int TurckCompanyId { get; set; }
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
        public DateTime DateReceived { get; set; } //DateReceived
        public string Memo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime LoadReceivingDate { get; set; }
        public string TruckCompName { get; set; }
        public string TruckCompAddr { get; set; }
        public string TruckCompCity { get; set; }
        public string TruckCompProv { get; set; }
        public string TruckCompPostal { get; set; }
        public string TruckCompPhone { get; set; }
        public int TruckCompId { get; set; }
        public int WApGeneratorId { get; set; }
        public string WApWasteDescrip { get; set; }
        public int WApSubId { get; set; }
        public string WApApprovalcode { get; set; }
        public string GeneratorName { get; set; }
        public string SubstanceName { get; set; }
        public int GenerLocationId { get; set; }
        public string GenerLocationLsd { get; set; }

        public IEnumerable<tblGenerator> tblGenerators { get; set; }

        public IEnumerable<tblGenerator> ddGenerators { get; set; }


        public List<tblSubstance> ddSubstance { get; set; }

        public List<tblGeneratorLocation> ddLocations { get; set; }

        public List<tblTruckCompany> ddTruckCompany { get; set; }
        public IEnumerable<tblGenerator> tblGenerator { get; internal set; }

    }
}