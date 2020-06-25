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

        public DataTable getBatchByPartAndDes(int Des, int PartID)
        {
            string sql = "select BathNumber from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID" +
                " inner join Orders on Orders.ID = OrderItems.OrderID" +
                "  where Destination = @Des and PartID = @PartID and BatchNumberHasRequired = 'true' group by BathNumber";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("Des", Des);
            cmd.Parameters.AddWithValue("PartID", PartID);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable getPartBySource(int Des)
        {
            string sql = "select DISTINCT PartID, PartName " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID" +
                " inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where BatchNumberHasRequired = 'true' and Orders.Destination = @Des";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("Des", Des);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
        
        public DataTable getIDOrders()
        {
            string sql = "SELECT MAX(ID)  FROM Orders";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public void insertIntoOrdersAdj(int TranID, int Source, int Des, string date)
        {
            string sql = "insert into Orders (TranSactionID, SourceWareHouse, Destination, OrderDate)" +
                " values(@TranID,@Source,@Des,@date)";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("TranID", TranID);
            cmd.Parameters.AddWithValue("Source", Source);
            cmd.Parameters.AddWithValue("Des", Des);
            cmd.Parameters.AddWithValue("date", date);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void insertIntoOrders(int TranID, int SupID, int Source, int Des, string date)
        {
            string sql = "insert into Orders values (@TranID, @SupID, @Source, @Des, @date)";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("TranID", TranID);
            cmd.Parameters.AddWithValue("SupID", SupID);
            cmd.Parameters.AddWithValue("Source", Source);
            cmd.Parameters.AddWithValue("Des", Des);
            cmd.Parameters.AddWithValue("date", date);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void insertIntoOrderItems(int OrderID, int PartID, string BathNumber, float Amount)
        {
            string sql = "insert into OrderItems values (@OrderID, @PartID, @BathNumber, @Amount)";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("OrderID", OrderID);
            cmd.Parameters.AddWithValue("PartID", PartID);
            cmd.Parameters.AddWithValue("BathNumber", BathNumber);
            cmd.Parameters.AddWithValue("Amount", Amount);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getBatchRequired(int ID)
        {
            string sql = "select BatchNumberHasRequired from PARTS where ID = @ID";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("ID", ID);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }


        public bool delete(int OrderItemsID)
        {
            string sql = "delete OrderItems where OrderItems.ID = @OrderItemsID";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
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

        public bool update(int PartID, float Amount, int OrderItemsID)
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
                "set SourceWareHouse = @SourceWareHouse, Destination = @Destination, TranSactionID = @TranSactionID " +
                "where Orders.ID = @OrdersId";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("SourceWareHouse", SourceWareHouse);
                cmd.Parameters.AddWithValue("Destination", Destination);
                cmd.Parameters.AddWithValue("TranSactionID", TranSactionID);
                cmd.Parameters.AddWithValue("OrdersId", OrdersId);
                cmd.ExecuteNonQuery();
                con.Close();
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

        public DataTable getIdByTranSactionName(string trantactionname)
        {
            string sql = "select TranSactionTypes.ID from TranSactionTypes where TranSactionName = @trantactionname";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("trantactionname", trantactionname);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
        public DataTable getAllOrders()
        {
            string sql = "select Parts.PartName, TranSactionTypes.TranSactionName,  Orders.OrderDate, OrderItems.Amount, e1.WareHouseName as 'Source' , e2.WareHouseName as 'Destination', OrderItems.ID as 'OrderItemId', Orders.ID as 'OrdersId'" +
                " from Orders" +
                " inner join WareHouses e1 on Orders.SourceWareHouse = e1.ID" +
                " inner join WareHouses e2 on Orders.Destination = e2.ID" +
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
        public DataTable getAllSuppliers()
        {
            string sql = "select * from Suppliers";
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

        public DataTable getMiniAmount(string PartName)
        {
            string sql = "select MinimumAmount from PARTS where PartName = @PartName";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("PartName", PartName);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public void updateParts(int PartID, float amount)
        {
            string sql = "update PARTS set MinimumAmount = MinimumAmount - @amount where ID = @PartID";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("PartID", PartID);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getAmountByBatch(int Des,string PartName)
        {
            string sql = "select t.Mua - ISNULL(h.Ban, 0 ) as 'Con' from (select PARTS.PartName, sum(Amount) as 'Mua' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.Destination = @Des " +
                "group by PARTS.PartName) t full join " +
                "( select PARTS.PartName, sum(Amount) as 'Ban' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.SourceWareHouse = @Des and Orders.TranSactionID = 2 " +
                "group by PARTS.PartName) h " +
                "on t.PartName = h.PartName where t.PartName = @PartName";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("Des", Des);
            cmd.Parameters.AddWithValue("PartName", PartName);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        /*public void updateOrderItemsByTranAndBatch(float Amount, string BathNumber, int SourceWareHouse)
        {
            string sql = "UPDATE OrderItems" +
                " SET Amount = Amount - @Amount" +
                " FROM OrderItems" +
                " inner join Orders on Orders.ID = OrderItems.OrderID" +
                " WHERE and SourceWareHouse = @Source BathNumber = @BathNumber";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("Amount", Amount);
            cmd.Parameters.AddWithValue("BathNumber", BathNumber);
            cmd.Parameters.AddWithValue("SourceWareHouse", SourceWareHouse);
            cmd.ExecuteNonQuery();
            con.Close();
        }*/

        public DataTable getBatchNumber(string BathNumber)
        {
            string sql = "select BathNumber from OrderItems where BathNumber = @BathNumber";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("BathNumber", BathNumber);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable getIventoryReport(int ID)
        {
            string sql = "select DISTINCT t.PartName, t.Mua - ISNULL(h.Ban, 0 ) as 'Con', t.Mua from " +
                "(select PARTS.PartName, sum(Amount) as 'Mua' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.Destination = @ID " +
                "group by PARTS.PartName) t full join " +
                "(select PARTS.PartName, sum(Amount) as 'Ban' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.SourceWareHouse = @ID and Orders.TranSactionID = 2 " +
                "group by PARTS.PartName) h on t.PartName = h.PartName ";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("ID", ID);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable getReportNull(int ID)
        {
            string sql = "select DISTINCT t.PartName, t.Mua - ISNULL(h.Ban, 0 ) as 'Con', t.Mua from " +
                "(select PARTS.PartName, sum(Amount) as 'Mua' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.Destination = @ID " +
                "group by PARTS.PartName) t full join(select PARTS.PartName, sum(Amount) as 'Ban' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.SourceWareHouse = @ID and Orders.TranSactionID = 2 " +
                "group by PARTS.PartName) h on t.PartName = h.PartName " +
                "where t.Mua - ISNULL(h.Ban, 0) = 0";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("ID", ID);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable getReportNotNull(int ID)
        {
            string sql = "select DISTINCT t.PartName, t.Mua - ISNULL(h.Ban, 0 ) as 'Con', t.Mua from " +
                "(select PARTS.PartName, sum(Amount) as 'Mua' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.Destination = @ID " +
                "group by PARTS.PartName) t full join(select PARTS.PartName, sum(Amount) as 'Ban' " +
                "from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID " +
                "inner join Orders on Orders.ID = OrderItems.OrderID " +
                "where Orders.SourceWareHouse = @ID and Orders.TranSactionID = 2 " +
                "group by PARTS.PartName) h on t.PartName = h.PartName " +
                "where t.Mua - ISNULL(h.Ban, 0) != 0";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("ID", ID);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable getDetailsBatch(int ID, string PartName)
        {
            string sql = "select BathNumber, Amount, TranSactionTypes.TranSactionName," +
                " e1.WareHouseName as 'Source' , e2.WareHouseName as 'Destination' from Orders " +
                "inner join WareHouses e1 on Orders.SourceWareHouse = e1.ID " +
                "inner join WareHouses e2 on Orders.Destination = e2.ID " +
                "inner join OrderItems on Orders.ID = OrderItems.OrderID " +
                "inner join Parts on OrderItems.PartID = Parts.ID " +
                "inner join TranSactionTypes on TranSactionTypes.ID = Orders.TranSactionID " +
                "where ((Orders.SourceWareHouse = @ID and Orders.TranSactionID = 2) or Orders.Destination = @ID) and PartName = @PartName";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.Parameters.AddWithValue("PartName", PartName);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
    }
}
