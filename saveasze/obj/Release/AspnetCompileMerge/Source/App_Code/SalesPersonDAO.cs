using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Linq;
using System.Xml.Linq;

public class SalesPersonDAO
{
    /// <summary>
    /// 
    /// </summary>
    public List<SalesPerson> SalesPersonList
    {
        get
        {
            List<SalesPerson> salesPersonList = HttpContext.Current.Session["SalesPersonList"] as List<SalesPerson>;

            //  load the customers on first access
            if (salesPersonList == null)
            {
                salesPersonList = new List<SalesPerson>();
                XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"App_Data\salesperson.xml"));

                salesPersonList =
                (
                     from sp in xDoc.Descendants("salesperson")
                     select new SalesPerson
                     {
                         ID = int.Parse(sp.Attribute("ID").Value),
                         Name = sp.Attribute("FullName").Value,
                         Territory = sp.Attribute("Territory").Value,
                         SalesYTD = decimal.Parse(sp.Attribute("SalesYTD").Value),
                         SalesLastYear = decimal.Parse(sp.Attribute("SalesLastYear").Value),
                         Projected = decimal.Parse(sp.Attribute("Projected").Value)
                     }
                 ).ToList();

                //  cache the list
                HttpContext.Current.Session["SalesPersonList"] = salesPersonList;
            }

            return salesPersonList;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public SalesPersonDAO() { }
}
