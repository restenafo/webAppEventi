<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebAppEventiCrociera.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="css/styles.css" rel="stylesheet" />
    <title>BOOK YOUR FUN</title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="row distanziaDallAlto">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-4">
                    <div class="d-flex justify-content-center">
                        <asp:TextBox ID="TXTemail" runat="server" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:TextBox ID="TXTpassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="d-flex justify-content-center">
                        <asp:Label ID="LBLrisposta" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="d-flex justify-content-center">
                        
                        <asp:Button ID="BTNlogin" class="btn btn-success" runat="server" Text="LOGIN" OnClick="BTNlogin_Click" />
                        <asp:Button ID="BTNreset" class="btn btn-danger" runat="server" Text="ANNULLA" OnClick="BTNreset_Click" />
                    </div>
                </div>
                <div class="col-lg-4">
                </div>
            </div>
        </form>
    </div>
</body>
</html>
