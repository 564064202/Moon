<%@ Page
Language           = "C#"
AutoEventWireup    = "false"
Inherits           = "Moon.Pager.Default"
ValidateRequest    = "false"
EnableSessionState = "false"
%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Moon.Pager</title>
<script src="http://lko2o.com/Resources/Framework/Jquery/jquery-1.9.0.min.js" type="text/javascript"></script>
<%=Moon.Orm.Util.PagerUtil.GetAjaxPagerControlScriptsAndCss()%>

<script>
  $(function(){
  			    var sumDataCountUrl="SmallPage.aspx?onlyGetSumDataCount=1";
				var smallPageUrl="SmallPage.aspx";
				var perCount=5;
				var contentDomID="content";
				var p=new MoonPager();
			    p.LoadPager(sumDataCountUrl,smallPageUrl,perCount,contentDomID);
		
  });
	
</script>

</head>
<body> 
<div id="content"></div>
<div class="pageNav"></div>
</body>
</html>
