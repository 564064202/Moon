<%@ Page
Language           = "C#"
AutoEventWireup    = "false"
Inherits           = "Moon.Pager.SmallPage"
ValidateRequest    = "false"
EnableSessionState = "false"
%>
<%
foreach(var a in this.List){%>
<p><%=a["ID"]%>&nbsp;<%=a["Name"]%></p>
<%}%>


