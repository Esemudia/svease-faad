using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SalesPerson
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal SalesYTD { get; set; }
    public decimal SalesLastYear { get; set; }
    public decimal Projected { get; set; }
    public string Territory { get; set; }
}
