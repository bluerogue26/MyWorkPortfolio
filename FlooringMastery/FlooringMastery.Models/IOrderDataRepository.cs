using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public interface IOrderDataRepository
    {
        List<Order> ReadFile(string date);

        Order LoadOrder(int orderNum, string date);

        List<Order> CheckFiles(string date);

        void AddToFile(Order newOrder, string date);

        void EditFile(Order newOrder, string date);

        void OverWriteFile(List<Order> orders, string date);

        void DeleteFile(int orderNum, string date);

        void MessageToLog(string message);
    }
}
