using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for CustomerDataObject
/// </summary>
[DataObject(true)]
public class CustomersDataObject
{
    /// <summary>
    /// 
    /// </summary>
    private DataSet _customers;

    /// <summary>
    /// 
    /// </summary>
    public CustomersDataObject()
	{
        this._customers = HttpContext.Current.Session["Customers"] as DataSet;

        if (this._customers == null)
        {
            this._customers = new DataSet();
            this._customers.ReadXml(HttpContext.Current.Server.MapPath(@"App_Data\customers.xml"));

            HttpContext.Current.Session["Customers"] = this._customers;
        }
	}

    /// <summary>
    /// 
    /// </summary>
    public DataTable CustomerTable
    {
        get { return this._customers.Tables["customers"]; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DataView Select(string propertyName, string propertyValue)
    {
        EnumerableRowCollection<DataRow> query = null;
        if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(propertyValue))
        {
            query =
                from customer in this.CustomerTable.AsEnumerable()
                select customer;
        }
        else
        {
            query =
                from customer in this.CustomerTable.AsEnumerable()
                where customer.Field<string>(propertyName).Equals(propertyValue, StringComparison.CurrentCultureIgnoreCase)
                select customer;
        }

        return query.AsDataView();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="columnName"></param>
    /// <param name="count"></param>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public string[] GetCompletionList(string columnName, string prefix, int count)
    {
        //  find all of the rows that have values that start with
        //  the provided prefix
        EnumerableRowCollection<DataRow> query =
            from customer in this.CustomerTable.AsEnumerable()
            where customer.Field<string>(columnName).ToLower().StartsWith(prefix.ToLower())
            select customer;

        DataView view = query.AsDataView();

        //  only return distinct values
        System.Collections.Generic.List<string> items = new System.Collections.Generic.List<string>();
        #region Distinct
        for (int i = 0; i < count && i < view.Count; i++)
        {
            string value = view[i][columnName].ToString();
            if (!items.Contains(value))
            {
                items.Add(value);
            }
        }
        #endregion

        //  return the items
        return items.ToArray(); 
    }
}
