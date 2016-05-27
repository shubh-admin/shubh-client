<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageNotFound.aspx.cs" Inherits="errors_PageNotFound" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client | Page Not Found</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>Page Not Found!</h1>
        <p>We cannot find the page you are looking for. We apologize for
        the inconvenience. We will resolve this issue shortly.</p>
    </div>
    <p>Error notification sent to webmaster, please  <asp:LinkButton ID="lnkUrl" Text="Click here" PostBackUrl="../Default.aspx" runat="server" /> back to Home.</p>
    </form>
</body>
</html>
