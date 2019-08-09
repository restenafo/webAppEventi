<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="WebAppEventiCrociera.reservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="css/styles.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="TBLEvento" runat="server"></asp:Table>
            <asp:TextBox ID="TXTpostiDaRiservare" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Button ID="BTNAvanti" runat="server" Text="Avanti" />
            <asp:Button ID="BTNIndietro" runat="server" Text="Indietro" />
        </div>
    </form>
</body>
</html>
