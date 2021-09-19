<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LW1b.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/modernizr-hui.js"></script>
    <script src="Scripts/web_socket_behavior.js"></script>
</head>
<body>
    <section style="width: 800px; float:left;">
        <div id="wsproperties">
            Web Sockets поддерживатеся?:
            <span id="support"></span><br />
        </div>
    </section>
    <br/>
    <section style="width: 215px; border:solid;">
        <div style="margin: 5px 5px 5px 5px;">
            <input id="bstart" type="button" value="Пуск" onclick="exe_start()" style="width: 100px" />
            <input id="bstop" type="button" value="Стоп" onclick="exe_stop()" style="width: 100px" />
            <textarea id="ta" rows="20" cols="25" style="text-align:center;" ></textarea>
        </div>
    </section>
</body>
</html>
