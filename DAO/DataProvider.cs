using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    class DataProvider
    {
        public string cnnString = "Data Source=.;Initial Catalog=QLNhanVien;Integrated Security=True";
        protected SqlConnection cnn;
        protected SqlDataAdapter dt;
        protected SqlCommand cm;
        public void connect()
        {
            cnn = new SqlConnection(cnnString);
            cnn.Open();
        }
        public void disconnect()
        { cnn.Close(); }
        public void ExecuteNonQuery(string sql)
        {
            cm = new SqlCommand(sql);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
        }
        public void ExecuteUpdateQuery(string sql) //Them, xoa, sua
        {
            connect();
            ExecuteNonQuery(sql);
            disconnect();
        }
        public DataSet ExecuteQuery(string strSelect)
        {
            DataSet dataset = new DataSet();
            cm = new SqlCommand();
            cm.Connection = this.cnn;
            dt = new SqlDataAdapter(strSelect, cnn);
            try { dt.Fill(dataset); }
            catch (SqlException ex)
            { MessageBox.Show(ex.ToString()); }
            return dataset;
        }
        public DataTable ExecuteQuery_DataTble(string strSelect)
        { return ExecuteQuery(strSelect).Tables[0]; }
        protected virtual object GetInfoFrom1Row(DataTable ddt, int i)
        {
            return null;
        }
        protected ArrayList ConvertDataTable2ArrayList(DataTable ddt)
        {
            ArrayList ar = new ArrayList();
            int i, n = ddt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object dto = GetInfoFrom1Row(ddt, i);
                ar.Add(dto);
            }
            return ar;
        }

        protected string GetIDCode(string strID, string field, string table, int length)
        {
            try
            {
                this.connect();

                string IDCode = strID + "0000000000";
                string query = "select max(" + field.Trim() + ") from " + table.Trim() + " where left(" + field.Trim() + "," + strID.Length + ")='" + strID.Trim() + "'";

                this.cm = new SqlCommand(query, this.cnn);
                this.cm.CommandType = CommandType.Text;
                SqlDataReader reader = this.cm.ExecuteReader();

                while (reader.Read())
                    if (!reader.IsDBNull(0))
                        IDCode = Convert.ToString(reader.GetValue(0));

                IDCode = IDCode.Substring(strID.Length);
                IDCode = "0000000000000000" + Convert.ToString(Convert.ToInt64(IDCode) + 1);
                IDCode = strID + IDCode.Substring(IDCode.Length - length + strID.Length);

                this.disconnect();
                return IDCode;
            }
            catch (Exception ex)
            {
                this.disconnect();
                throw ex;
            }
        }
    }
}
