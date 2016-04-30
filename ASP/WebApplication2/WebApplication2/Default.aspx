<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body>
<p id="sessionId" contenteditable="true" runat="server"></p>
<p id="hits" contenteditable="true" runat="server"></p>
<form id="form1" runat="server">
   <div>
      <input id="userName" runat="server"/>
      <input id="email" runat="server" />
      <input id="userPhoneNumber" runat="server" />
      <input type="submit" runat="server" />
   </div>
</form>
</body>
</html>