<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneralError.aspx.cs" Inherits="errors_GeneralError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Panel | Error</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <table width="85%" cellpadding="5" cellspacing="1" bgcolor="red">
                <tr bgcolor="white">
                    <td align="center">
                        <b><font color="red">An error occurred.</font></b>
                        <br>
                        <br>
                        <font color="red"><span id="lblMessage" runat="server"></span></font>
                        <br>
                        <br>
                        <b><font color="darkblue">Error information has been sent to the ClientPanel team.
                            <br>
                            <br>
                        </font></b>
                        <br>
                        If you have any comments, suggestions or questions, feel free to write to <a href="../Contactus.aspx">
                            Contact Us</a>. We like to hear from you.
                    </td>
                </tr>
            </table>
            <br>
            <h1>
                <a href="../Default.aspx">Return to Client Panel Homepage</a></h1>
        </center>
    </div>
    </form>
</body>
</html>
