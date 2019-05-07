using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace secretsWebService
{
    [ServiceContract]
    public interface IService1
    {
        //login Part

        [OperationContract]
        bool checkUser(string uN, string pS);

        [OperationContract]
        bool insertLogin(int id, string usName, string password);

        [OperationContract]
        bool DeleteLogin(string userName);

        [OperationContract]
        bool updateLogin(int id, string usName, string password);

        [OperationContract]
        List<loginTB> searchLogin(int id);

        //user part

        [OperationContract]
        List<userDetailsTB> viewAllUser();

        [OperationContract]
        bool insertUser(string usName, string name, string branch, string imgPath);

        [OperationContract]
        List<userDetailsTB> searchUser(string userName);

        [OperationContract]
        bool DeleteUser(string userName);

        [OperationContract]
        bool updateUser(int id, string usName, string name, string branch, string imgPath, string password);


        //items part
        [OperationContract]
        bool insertItem(string Name, string Category, int purchesdPrice, int sellingPrice, string image, bool availability, string addedDate, string description, string size,int qty);

        [OperationContract]
        List<itemDetailsTB> searchItem(string itemName);

        [OperationContract]
        bool DeleteItem(int itemID);

        [OperationContract]
        List<itemDetailsTB> viewAllItem();

        [OperationContract]
        bool updateItem(int id, string Name, string Category, int purchesdPrice, int sellingPrice, string image, bool availability, string addedDate, string description, string size, int qty);

        [OperationContract]
        bool updateItemavailability(int id);

        //customer part
        [OperationContract]
        bool insertCustomer(string name, int telephone, string email, string gender, string addedDate);

        [OperationContract]
        List<customerDetailsTB> searchCustomer(string customerName);

        [OperationContract]
        bool DeleteCustomer(int customerId);

        [OperationContract]
        List<customerDetailsTB> viewAllCustomer();

        [OperationContract]
        bool updateCustomer(int customerID, string nam, int tp, string gend, string email, string date);

        //out of stock report part
        [OperationContract]
        List<outOfStockDeatilsTB> viewAllOutOfStock();

        [OperationContract]
        bool insertOutOfStock(string date, int itemID, string name, int unitPrice, string cat, string addedDate, string overSince);

        [OperationContract]
        List<outOfStockDeatilsTB> searchOutOfStockReport(string date);

        //bill part
        [OperationContract]
        bool insertInvoice(int BillNo, int ItemID, string ItemName, int ItemQty, int ItemUnitPrice, int ItemSumPrice, string Cashier, string Branch, string date);
       
        [OperationContract]
        List<itemDetailsTB> searchItemByID(int itemID);

        [OperationContract]
        int findLastBill();

        [OperationContract]
        bool reduceQty(int id, int amount);

        [OperationContract]
        List<invoiceTB> findBill(int id);

        //daily salse report part
         [OperationContract]
        bool insertSalse(int billNO, int total, string date);

    }

    
}
