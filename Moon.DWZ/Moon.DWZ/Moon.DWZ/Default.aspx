<%@ Page Language="C#" Inherits="Moon.DWZ.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
    <title>Default</title>
    <link href="dwz/themes/default/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="dwz/themes/css/core.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="dwz/themes/css/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="dwz/uploadify/css/uploadify.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="dwz/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="dwz/mcore/dwz.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            DWZ.init("dwz.frag.xml", {
                loginUrl: "login_dialog.aspx", loginTitle: "登录",	// 弹出登录对话框
                //		loginUrl:"login.html",	// 跳到登录页面
                statusCode: { ok: 200, error: 300, timeout: 301 }, //【可选】
                pageInfo: { pageNum: "pageNum", numPerPage: "numPerPage", orderField: "orderField", orderDirection: "orderDirection" }, //【可选】
                keys: { statusCode: "statusCode", message: "message" }, //【可选】
                ui: { hideMode: 'offsets' }, //【可选】hideMode:navTab组件切换的隐藏方式，支持的值有’display’，’offsets’负数偏移位置的值，默认值为’display’
                debug: false,	// 调试模式 【true|false】
                callback: function () {
                    initEnv();
                    $("#themeList").theme({ themeBase: "dwz/themes" }); // themeBase 相对于index页面的主题base路径
                }
            });
        });

    </script>
</head>
<body scroll="no">
    <div id="layout">
        <div id="header">
            <div class="headerNav">
                <a class="logo">标志</a>
                <ul class="nav">
                    <li><a href="https://me.alipay.com/dwzteam" target="_blank">捐赠</a></li>
                    <li><a href="changepwd.html" target="dialog" width="600">设置</a></li>
                    <li><a href="http://www.cnblogs.com/dwzjs" target="_blank">博客</a></li>
                    <li><a href="http://weibo.com/dwzui" target="_blank">微博</a></li>
                    <li><a href="login.html">退出</a></li>
                    <a href="user.do?method=remove" target="ajaxTodo" title="确定要删除吗?">删除</a>
                </ul>
                <ul class="themeList" id="themeList">
                    <li theme="default">
                        <div class="selected">蓝色</div>
                    </li>
                    <li theme="green">
                        <div>绿色</div>
                    </li>
                    <!--<li theme="red"><div>红色</div></li>-->
                    <li theme="purple">
                        <div>紫色</div>
                    </li>
                    <li theme="silver">
                        <div>银色</div>
                    </li>
                    <li theme="azure">
                        <div>天蓝</div>
                    </li>
                </ul>
            </div>

            <!-- navMenu -->

        </div>

        <div id="leftside">
            <div id="sidebar_s">
                <div class="collapse">
                    <div class="toggleCollapse">
                        <div></div>
                    </div>
                </div>
            </div>
            <div id="sidebar">
                <div class="toggleCollapse">
                    <h2>站点导航</h2>
                    <div>收缩</div>
                </div>

                <div class="accordion" fillspace="sidebar">
                    <div class="accordionHeader">
                        <h2><span>Folder</span>技术博文</h2>
                    </div>
                    <div class="accordionContent">
                        <ul class="tree treeFolder">
                            <li><a href="tabsPage.html" target="navTab">.NET技术区</a>
                                <ul>
                                    <li><a href="main.html" target="navTab" rel="m_default_layout">B/S技术</a></li>
                                    <li><a href="main.html" target="navTab" rel="m_navigate_layout">C/S技术</a></li>
                                </ul>
                            </li>

                            <li><a>Java技术区</a>
                                <ul>
                                    <li><a href="main.html" target="navTab" rel="m_default_layout">B/S技术</a></li>
                                    <li><a href="main.html" target="navTab" rel="m_navigate_layout">C/S技术</a></li>
                                </ul>
                            </li>

                            <li><a>数据库技术区</a>
                                <ul>
                                    <li><a href="w_validation.html" target="navTab" rel="w_validation">sqlserver</a></li>
                                    <li><a href="w_button.html" target="navTab" rel="w_button">oracle</a></li>
                                    <li><a href="w_textInput.html" target="navTab" rel="w_textInput">mysql</a></li>
                                    <li><a href="w_combox.html" target="navTab" rel="w_combox">access</a></li>
                                    <li><a href="w_checkbox.html" target="navTab" rel="w_checkbox">postgresql</a></li>
                                    <li><a href="demo_upload.html" target="navTab" rel="demo_upload">sqlite</a></li>
                                    <li><a href="w_uploadify.html" target="navTab" rel="w_uploadify">其他数据库</a></li>
                                </ul>
                            </li>
                            <li><a>手机开发技术区</a>
                                <ul>
                                    <li><a href="demo/pagination/layout1.html" target="navTab" rel="pagination1">andriod</a></li>
                                    <li><a href="demo/pagination/layout2.html" target="navTab" rel="pagination2">ios</a></li>
                                    <li><a href="demo/pagination/layout2.html" target="navTab" rel="pagination2">其他</a></li>
                                </ul>
                            </li>
                            <li><a>c++技术区</a>
                                <ul>
                                    <li><a href="chart/test/barchart.html" target="navTab" rel="chart">柱状图(垂直)</a></li>
                                    <li><a href="chart/test/hbarchart.html" target="navTab" rel="chart">柱状图(水平)</a></li>
                                    <li><a href="chart/test/linechart.html" target="navTab" rel="chart">折线图</a></li>
                                    <li><a href="chart/test/linechart2.html" target="navTab" rel="chart">曲线图</a></li>
                                    <li><a href="chart/test/linechart3.html" target="navTab" rel="chart">曲线图(自定义X坐标)</a></li>
                                    <li><a href="chart/test/piechart.html" target="navTab" rel="chart">饼图</a></li>
                                </ul>
                            </li>
                            <li><a>前端技术区</a>
                                <ul>
                                    <li><a href="chart/test/barchart.html" target="navTab" rel="chart">柱状图(垂直)</a></li>
                                    <li><a href="chart/test/hbarchart.html" target="navTab" rel="chart">柱状图(水平)</a></li>
                                    <li><a href="chart/test/linechart.html" target="navTab" rel="chart">折线图</a></li>
                                    <li><a href="chart/test/linechart2.html" target="navTab" rel="chart">曲线图</a></li>
                                    <li><a href="chart/test/linechart3.html" target="navTab" rel="chart">曲线图(自定义X坐标)</a></li>
                                    <li><a href="chart/test/piechart.html" target="navTab" rel="chart">饼图</a></li>
                                </ul>
                            </li>
                            <li><a href="dwz.frag.xml" target="navTab" external="true">dwz.frag.xml</a></li>
                        </ul>
                    </div>
                    <div class="accordionHeader">
                        <h2><span>Folder</span>开源资讯</h2>
                    </div>
                    <div class="accordionContent">
                        <ul class="tree treeFolder treeCheck">
                            <li><a href="demo_page1.html" target="navTab" rel="demo_page1">查询我的客户</a></li>
                            <li><a href="demo_page1.html" target="navTab" rel="demo_page2">表单查询页面</a></li>
                            <li><a href="demo_page4.html" target="navTab" rel="demo_page4">表单录入页面</a></li>
                            <li><a href="demo_page5.html" target="navTab" rel="demo_page5">有文本输入的表单</a></li>
                            <li><a href="javascript:;">有提示的表单输入页面</a>
                                <ul>
                                    <li><a href="javascript:;">页面一</a></li>
                                    <li><a href="javascript:;">页面二</a></li>
                                </ul>
                            </li>
                            <li><a href="javascript:;">选项卡和图形的页面</a>
                                <ul>
                                    <li><a href="javascript:;">页面一</a></li>
                                    <li><a href="javascript:;">页面二</a></li>
                                </ul>
                            </li>
                            <li><a href="javascript:;">选项卡和图形切换的页面</a></li>
                            <li><a href="javascript:;">左右两个互动的页面</a></li>
                            <li><a href="javascript:;">列表输入的页面</a></li>
                            <li><a href="javascript:;">双层栏目列表的页面</a></li>
                        </ul>
                    </div>
                    <div class="accordionHeader">
                        <h2><span>Folder</span>个人中心</h2>
                    </div>
                    <div class="accordionContent">
                        <ul class="  tree treeFolder">
                            <li><a href="demo_page1.html" target="navTab" rel="demo_page1">账号管理</a></li>
                            <li><a href="demo_page1.html" target="navTab" rel="demo_page2">我的收藏</a></li>
                            <li><a href="demo_page1.html" target="navTab" rel="demo_page2">我的在线简历</a></li>
                            <li><a href="demo_page1.html" target="navTab" rel="demo_page2">偏好设定</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div id="container">
            <div id="navTab" class="tabsPage">
                <div class="tabsPageHeader">
                    <div class="tabsPageHeaderContent">
                        <!-- 显示左右控制时添加 class="tabsPageHeaderMargin" -->
                        <ul class="navTab-tab">
                            <li tabid="main" class="main"><a href="javascript:;"><span><span class="home_icon">我的主页</span></span></a></li>
                        </ul>
                    </div>
                    <div class="tabsLeft">left</div>
                    <!-- 禁用只需要添加一个样式 class="tabsLeft tabsLeftDisabled" -->
                    <div class="tabsRight">right</div>
                    <!-- 禁用只需要添加一个样式 class="tabsRight tabsRightDisabled" -->
                    <div class="tabsMore">more</div>
                </div>
                <ul class="tabsMoreList">
                    <li><a href="javascript:;">站点主页</a></li>
                </ul>
                <div class="navTab-panel tabsPageContent layoutBox">
                    <div class="page unitBox">
                        <div class="accountInfo">
                            <div class="alertInfo">
                                <p><a href="https://code.csdn.net/dwzteam/dwz_jui/tree/master/doc" target="_blank" style="line-height: 19px"><span>DWZ框架使用手册</span></a></p>
                                <p><a href="http://pan.baidu.com/s/18Bb8Z" target="_blank" style="line-height: 19px">DWZ框架开发视频教材</a></p>
                            </div>
                            <div class="right">
                                <p style="color: red">DWZ官方微博 <a href="http://weibo.com/dwzui" target="_blank">http://weibo.com/dwzui</a></p>
                            </div>
                            <p><span>DWZ富客户端框架</span></p>
                            <p>DWZ官方微博:<a href="http://weibo.com/dwzui" target="_blank">http://weibo.com/dwzui</a></p>
                        </div>
                        <div class="pageFormContent" layouth="80" style="margin-right: 230px">
                        </div>


                    </div>

                </div>
            </div>
        </div>

    </div>

    <div id="footer">Copyright &copy; 2014 立刻网</div>


    <script type="text/javascript" src="http://stat.mpnco.com.cn/stat/a.ashx?s=~xNjMpOSTQRnG~Pgkkp~QAQuUsH6ijp7js7sv4lv8US4Pl~7uFNpVQkVSldZmSba&c=~xNjMpOSTQRnG~Pgkkp~QAQuUsH6ijp7js7sv4lv8US4Pl~7uFNpVQkVSldZmSba"></script>
</body>
</html>
