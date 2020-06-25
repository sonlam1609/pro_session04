using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4
{
    class Session4BLL
    {
        Session4DAL dalSS4;
        public Session4BLL()
        {
            dalSS4 = new Session4DAL();
        }

        public DataTable getAllOrders() {
            return dalSS4.getAllOrders();
        }

        public DataTable getAllWareHouses()
        {
            return dalSS4.getAllWareHouses();
        }

        public DataTable getAllPart()
        {
            return dalSS4.getAllPartName();
        }

        public DataTable getAllTranSactionTypes()
        {
            return dalSS4.getAllTranSactionTypes();
        }

        public DataTable getIdByPartName(string partname)
        {
            return dalSS4.getIdByPartName(partname);
        }

        public DataTable getIdByWareHouse(string warehousename)
        {
            return dalSS4.getIdByWareHouse(warehousename);
        }

        public DataTable getIdByTranSactionName(string trantactionname)
        {
            return dalSS4.getIdByTranSactionName(trantactionname);
        }

        public bool update(int PartID, float Amount, int OrderItemsID)
        {
            return dalSS4.update(PartID, Amount, OrderItemsID);
        }
        public bool update2(int SourceWareHouse, int Destination, int TranSactionID, int OrdersId)
        {
            return dalSS4.update2(SourceWareHouse, Destination, TranSactionID, OrdersId);
        }
        public bool delete(int OrderItemsID)
        {
            return dalSS4.delete(OrderItemsID);
        }

        public DataTable getAllSuppliers()
        {
            return dalSS4.getAllSuppliers();
        }

        public DataTable getBatchRequired(int ID)
        {
            return dalSS4.getBatchRequired(ID);
        }

        public void insertIntoOrders(int TranID, int SupID, int Source, int Des, string date)
        {
            dalSS4.insertIntoOrders(TranID, SupID, Source, Des, date);
        }

        public void insertIntoOrderItems(int OrderID, int PartID, string BathNumber, float Amount)
        {
            dalSS4.insertIntoOrderItems(OrderID, PartID, BathNumber, Amount);
        }

        public DataTable getIDOrders()
        {
            return dalSS4.getIDOrders();
        }

        public void insertIntoOrdersAdj(int TranID, int Source, int Des, string date)
        {
            dalSS4.insertIntoOrdersAdj(TranID, Source, Des, date);
        }

        public DataTable getPartBySource(int Des)
        {
            return dalSS4.getPartBySource(Des);
        }

        public DataTable getBatchByPartAndDes(int Des, int PartID)
        {
            return dalSS4.getBatchByPartAndDes(Des, PartID);
        }

        public DataTable getMiniAmount(string PartName)
        {
            return dalSS4.getMiniAmount(PartName);
        }

        public void updateParts(int PartID, float amount)
        {
            dalSS4.updateParts(PartID, amount);
        }

        public DataTable getAmountByBatch(int Des, string PartName)
        {
            return dalSS4.getAmountByBatch(Des, PartName);
        }

        /*public void updateOrderItemsByTranAndBatch(float Amount, string BathNumber, int SourceWareHouse)
        {
            dalSS4.updateOrderItemsByTranAndBatch(Amount, BathNumber, SourceWareHouse);
        }*/

        public DataTable getBatchNumber(string BathNumber)
        {
            return dalSS4.getBatchNumber(BathNumber);
        }

        public DataTable getIventoryReport(int ID)
        {
            return dalSS4.getIventoryReport(ID);
        }

        public DataTable getReportNull(int ID)
        {
            return dalSS4.getReportNull(ID);
        }

        public DataTable getReportNotNull(int ID)
        {
            return dalSS4.getReportNotNull(ID);
        }

        public DataTable getDetailsBatch(int ID, string PartName)
        {
            return dalSS4.getDetailsBatch(ID, PartName);
        }
    }
}
