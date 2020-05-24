using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4
{
    class Session4DAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public Session4DAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllOrders()
        {
            string sql = " select Parts.PartName, TranSactionTypes.TranSactionName,  Orders.OrderDate, OrderItems.Amount, Orders.SourceWareHouse, Orders.Destination, OrderItems.ID " +
                "from Orders" +
                " inner join WareHouses on Orders.SourceWareHouse = WareHouses.ID" +
                " inner join OrderItems on Orders.ID = OrderItems.OrderID" +
                " inner join Parts on OrderItems.PartID = Parts.ID inner " +
                "join TranSactionTypes on TranSactionTypes.ID = Orders.TranSactionID ";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getAllWareHouses()
        {
            string sql = "select * from WareHouses";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getAllPartName()
        {
            string sql = "select * from PARTS;";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getAllTranSactionTypes()
        {
            string sql = "select * from TranSactionTypes;";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getIdByPartName(string partname)
        {
            string sql = "select PARTS.ID from PARTS where PARTS.PartName = @partname; ";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("partname", partname);
            DataTable dt = new DataTable();

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

    }
}
