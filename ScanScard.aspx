<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScanScard.aspx.cs" Inherits="FinishGoodSMT.ScanScard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Resources/Images/inventronics icon.ico" rel="icon" />
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>    
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
<link rel="stylesheet" href="Resources/CSS/Styles.css" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
<script src="Resources/JS/script.js"></script>
    <title>Finish Good SCARD/SBOARD</title>

 
</head>
<body class="body-menu">
    <form id="form1" runat="server">
        <div class="header-menu">
            <div class="nav-logo">
                <asp:Image ImageUrl="~/Resources/Images/inv.png" runat="server" Height="50px" Width="150px" />
            </div>
            <h1>FINISH GOOD SCARD/SBOARD</h1>
        </div>

        <div class="form-material">
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblWO" CssClass="lbldata" runat="server" Text="Work Order" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br /><br />
                <asp:Label ID="lblQr" CssClass="lbldata" runat="server" Text="ESCANEAR QR Main" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSN" Visible="true" CssClass="lbldata" runat="server" Text="QR SCAN:"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblModel" Visible="true" CssClass="lbldata" runat="server" Text="Modelo:"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblpieces" Visible="true" CssClass="lbldata" runat="server" Text="Piezas/Panel:"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQtyWO" CssClass="lbldata" runat="server" Text="Cantidad WO:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcumWO" CssClass="lbldata" runat="server" Text="Acumulado WO:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcumDia" CssClass="lbldata" runat="server" Text="Acumulado DIA:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQtyScrap" CssClass="lbldata" runat="server" Text="Unidades Scrap:" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQtyRepair" CssClass="lbldata" runat="server" Text="en Reparacion:" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                
            </div>
            <div id="modQty">
                <asp:Label ID="txtWorkOrder" CssClass="lbldata4" Font-Bold="true" runat="server" ForeColor="#0079bc"></asp:Label><br /><br />
                <asp:TextBox ID="txtQRMain" CssClass="txtboxes" runat="server" ForeColor="#0079bc" AutoPostBack="true" Style="text-transform: uppercase" AutoCompleteType="Disabled" OnTextChanged="txtQRMain_TextChanged"></asp:TextBox><br /><br />
                 <asp:Label ID="dataQRSN" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataModel" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataPieces" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataQtyWO" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataAcumWO" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataAcumDia" CssClass="lbldata4" ForeColor="#0079bc" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataQtyScrap" CssClass="lbldata4" ForeColor="red" runat="server" Text="" Font-Bold="true"></asp:Label><br />
                <asp:Label ID="dataQtyRepair" CssClass="lbldata4" ForeColor="gold" runat="server" Text="" Font-Bold="true" Visible="false"></asp:Label><br />
                
            </div>
        </div>
        <div id="nav-user" class="mx-auto" style="width: 1100px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userlbl" runat="server" Text="Usuario:"></asp:Label>
            <asp:Label ID="userlabel" runat="server" Text=""></asp:Label>
        </div>

        <asp:LinkButton CssClass="btnLogout" runat="server" PostBackUrl="~/Menu.aspx">
                <span class="fas fa-backspace" aria-hidden="true"></span> &nbsp;Menú
        </asp:LinkButton>

        <asp:LinkButton CssClass="btnLogout2" runat="server" PostBackUrl="~/Login.aspx">
                <span class="fas fa-sign-out-alt" aria-hidden="true"></span> 
        </asp:LinkButton>
<%--                                    <asp:LinkButton CssClass="btnLogout3" ID="btnPrint" runat="server" Visible="false" OnClick="btnPrint_Click">
                <span class="fas fa-print" aria-hidden="true"></span> &nbsp;Exportar
            </asp:LinkButton>--%>
            <asp:LinkButton CssClass="btnReset" ID="btnReset" runat="server" Visible="false" OnClick="btnReset_Click">
                <span class="fas fa-sync-alt" aria-hidden="true"></span> &nbsp;Reset
            </asp:LinkButton>
<%--                    <asp:LinkButton CssClass="btnBalance" ID="btnBalance" runat="server" Visible="false" OnClick="btnBalance_Click">
                <span class="fas fa-balance-scale" aria-hidden="true"></span> &nbsp;Balance
            </asp:LinkButton>--%>
    </form>
<div  id="res2" visible="true" runat="server">
        <asp:Label Text="" ID="res" Visible="true" CssClass="font-weight-bold"  runat="server"></asp:Label><br />
    </div>
</body>
</html>
