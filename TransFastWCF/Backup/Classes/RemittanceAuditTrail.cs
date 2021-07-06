using System;
using System.Data;

namespace WesternUnionWCF.Classes
{
    public class RemittanceAuditTrail
	{

		public static string GetAuditTrailString(string branchCode, string userID, string roleID, string moduleID, string ipAddress, string macAddress)
		{
			DataColumn dcol = new DataColumn();
			DataTable dtable = new DataTable();
			DataSet dset = new DataSet();

			dset.DataSetName = "DTRACKER";
			dtable.TableName = "TRACKER";

			dcol.ColumnName = "BRID";
			dcol.DataType = System.Type.GetType("System.String");
			dtable.Columns.Add(dcol);

			dcol = new DataColumn();
			dcol.ColumnName = "UserID";
			dcol.DataType = System.Type.GetType("System.String");
			dtable.Columns.Add(dcol);

			dcol = new DataColumn();
			dcol.ColumnName = "RoleID";
			dcol.DataType = System.Type.GetType("System.Int64");
			dtable.Columns.Add(dcol);

			dcol = new DataColumn();
			dcol.ColumnName = "ModuleID";
			dcol.DataType = System.Type.GetType("System.Int64");
			dtable.Columns.Add(dcol);

			dcol = new DataColumn();
			dcol.ColumnName = "IPAdd";
			dcol.DataType = System.Type.GetType("System.String");
			dtable.Columns.Add(dcol);

			dcol = new DataColumn();
			dcol.ColumnName = "MACADD";
			dcol.DataType = System.Type.GetType("System.String");
			dtable.Columns.Add(dcol);

			DataRow drow = dtable.NewRow();

			drow[0] = Convert.ToString(branchCode);
			drow[1] = Convert.ToString(userID);
			drow[2] = Convert.ToString(roleID);
			drow[3] = Convert.ToString(moduleID);
			drow[4] = Convert.ToString(ipAddress);
			drow[5] = Convert.ToString(macAddress);

			dtable.Rows.Add(drow);
			dset.Tables.Add(dtable);

			string auditTrailString = dset.GetXml().ToString();

			return auditTrailString;
		}
	}
}