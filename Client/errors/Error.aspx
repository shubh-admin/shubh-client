<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="errors_GeneralError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Panel | Error</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Error occured</h1>
        <p>
            The server is experiencing a problem with the page you requested. We apologize for
            the inconvenience. We will resolve this issue shortly.</p>
    </div>
    Error notification sent to webmaster, please
    <asp:LinkButton ID="lnkUrl" Text="Click here" PostBackUrl="~/Default.aspx" runat="server" />
    back to Home.
    </form>
</body>
</html>
