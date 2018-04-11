<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptViewerLoadSummary.aspx.cs" Inherits="MLandfill.Views.ReportViewer.RptViewerLoadSummary" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
<%--https://blogs.msdn.microsoft.com/sajoshi/2010/06/16/asp-net-mvc-handling-ssrs-reports-with-reportviewer-part-i/--%>
<%--http://www.codemag.com/article/1009061--%>