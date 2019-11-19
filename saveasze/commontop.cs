internal class commontop
{

    public string topPage(string uname)
    {
        string strTopPage = "";
        strTopPage = strTopPage + "< header class='header-area'>";
        strTopPage = strTopPage + " < div class='top-bar'>";
        strTopPage = strTopPage + "<div class='container'>";
        strTopPage = strTopPage + " <div class='clearfix'>";
        strTopPage = strTopPage + " < ul class='top-bar-text float_left'>";
        strTopPage = strTopPage + " < li><i class='fa fa-map-signs'></i>Making savings habit simple and effortless.</li>";
        strTopPage = strTopPage + " </ul>";
        strTopPage = strTopPage + "  < ul class='top-bar-text float_right'>";
        strTopPage = strTopPage + " < li>  <span> &nbsp;&nbsp;&nbsp;&nbsp;<img src = 'images/google.png' /> &nbsp;&nbsp;&nbsp;&nbsp;<img src = 'images/apple.png' /></ span ></ li >";
        strTopPage = strTopPage + " </ ul >";
        strTopPage = strTopPage + "< ul class='top-bar-text float_right'>";
        strTopPage = strTopPage + "< li><i class='fa fa-clock-o'></i><span id = 'date_time' ></ span >";
        strTopPage = strTopPage + "< script type='text/javascript'>window.onload = date_time('date_time');</script></li>";
        strTopPage = strTopPage + "</ul>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "< div class='header-bottom'>";
        strTopPage = strTopPage + "< div class='container'>";
        strTopPage = strTopPage + "< div class='header-bottom-bg clearfix'>";
        strTopPage = strTopPage + " < div class='main-logo float_left'>";
        strTopPage = strTopPage + "< a href = 'default.aspx' >< img src='images/logo/logo.png' alt=''></a>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "< div class='top-info float_right'>";
        strTopPage = strTopPage + "< ul>";
        strTopPage = strTopPage + " < li class='single-info-box'>";
        strTopPage = strTopPage + "< div class='icon-holder'>";
        strTopPage = strTopPage + "< span class='icon-technology'></span>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "< div class='text-holder'>";
        strTopPage = strTopPage + "< p><span>Call Us Now</span><br>0700SAVEASE</p>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "</li>";
        strTopPage = strTopPage + "< li class='single-info-box'>";
        strTopPage = strTopPage + " < div class='icon-holder'>";
        strTopPage = strTopPage + "< span class='icon-multimedia'></span>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "< div class='text-holder'>";
        strTopPage = strTopPage + "< p><span>Send Us eMail</span> <br>Info @savease.ng</p>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "</li>";
        strTopPage = strTopPage + showLogin(uname);
        strTopPage = strTopPage + "</li>";
        strTopPage = strTopPage + "</ul> ";
        strTopPage = strTopPage + " </div> ";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "</div>";
        strTopPage = strTopPage + "</div> ";
        strTopPage = strTopPage + "</header>";
        return strTopPage;
    }
    public string showLogin(string uname)
    {
        return (string.IsNullOrEmpty(uname)) ? "< li><a href = 'login.aspx' class='thm-btn' runat='server' id='loginAnchor'>Login</a></li>" : "<li> < a href = 'deposit.aspx' class='thm-btn' runat='server' id='quickDesposit' visible='false'>Make Quick Deposit</a></li>";
    }
}