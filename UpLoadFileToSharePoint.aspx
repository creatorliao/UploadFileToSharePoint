<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpLoadFileToSharePoint.aspx.cs" Inherits="UpLoadFileToSharePoint.UpLoadFileToSharePoint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Form1 {
            height: 226px;
        }
    </style>
</head>
<body style="height: 241px">

    <form id="Form1" method="post" enctype="multipart/form-data" runat="server">
        Upload file to SharePoint:<br />
        <br />
         <asp:FileUpload id="file" runat="server" />
         <br />
         <asp:Button id="Button1" runat="server" text="Upload File" OnClick="ButtonUploadFile"/>
        <br />
        <br />
        <asp:Label ID="LabelResult" runat="server" Text="Result"></asp:Label>
    </form>
</body>
</html>
