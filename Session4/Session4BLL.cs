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
    }
}
