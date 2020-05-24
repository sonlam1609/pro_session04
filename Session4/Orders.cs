using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4
{
    class Orders
    {
        public int ID { set; get; }
        public int TranSactionID { set; get; }
        public int SupplierID { set; get; }
        public int SourceWareHouse { set; get; }
        public int Destination { set; get; }
        public DateTime OrderDate { set; get; }
    }
}
