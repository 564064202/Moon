<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="w_panel.aspx.cs" Inherits="Moon.DWZ.w_panel" %>

<div class="pageContent sortDrag" selector="h1" layouth="42">
    <div class="panel   collapse" defh="700" defw="30">
        <h1>可折叠默认关闭面板</h1>
        <div>
            <select class="combox" name="cmbtype" >
                <option  value="'close collapse'" selected="selected">collapseClose</option>
                <option value="'collapse'">collapseOpen</option>
                <option value="">defaultPanel</option>
            </select>
        </div>
    </div>
</div>
