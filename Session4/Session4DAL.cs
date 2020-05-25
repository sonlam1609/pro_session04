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

        public bool update(int PartID, int Amount, int OrderItemsID)
        {
            string sql = "UPDATE OrderItems" +
                " SET PartID = @PartID, Amount = @Amount" +
                " WHERE OrderItems.ID = @OrderItemsID; ";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("PartID", PartID);
                cmd.Parameters.AddWithValue("Amount", Amount);
                cmd.Parameters.AddWithValue("OrderItemsID", OrderItemsID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                return false;
            }
            return true;  
        }

        public bool update2(int SourceWareHouse, int Destination, int TranSactionID, int OrdersId)
        {
            string sql = "Update Orders " +
                "set SourceWareHouse = 2, Destination = 4, TranSactionID = 2 " +
                "where Orders.ID = 1";
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
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

        public DataTable getIdByWareHouse(string warehousename)
        {
            string sql = "select WareHouses.ID from WareHouses where WareHouses.WareHouseName = @warehousename";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("warehousename", warehousename);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
        public DataTable getAllOrders()
        {
            string sql = "select Parts.PartName, TranSactionTypes.TranSactionName,  Orders.OrderDate, OrderItems.Amount, WareHouses.WareHouseName as 'Source' , Destination.Destination, OrderItems.ID as 'OrderItemId', Orders.ID as 'OrdersId'" +
                " from Orders" +
                " inner join WareHouses on Orders.SourceWareHouse = WareHouses.ID" +
                " inner join Destination on Orders.Destination = Destination.ID" +
                " inner join OrderItems on Orders.ID = OrderItems.OrderID" +
                " inner join Parts on OrderItems.PartID = Parts.ID" +
                " inner join TranSactionTypes on TranSactionTypes.ID = Orders.TranSactionID";
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

        

    }
}
