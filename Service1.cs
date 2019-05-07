using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace secretsWebService
{
    public class Service1 : IService1
    {
        cashDBDataContext myCashDB = new cashDBDataContext();

        //login part

        public bool checkUser(string uN, string pS)
        {
            var result = (from logIn in myCashDB.loginTBs where logIn.userName.Equals(uN) && logIn.password == pS select logIn);

            if (result.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool insertLogin(int id, string usName, string password)
        {
            try
            {
                loginTB newLogin = new loginTB();

                newLogin.userID = id;
                newLogin.userName = usName;
                newLogin.password = password;

                myCashDB.loginTBs.InsertOnSubmit(newLogin);
                myCashDB.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLogin(string userName)
        {
            try
            {
                var users = myCashDB.loginTBs.Where(s => s.userName == userName).FirstOrDefault();
                if (users == null)
                {
                    // We couldn't find a record with this ID.
                    return false;
                }
                myCashDB.loginTBs.DeleteOnSubmit(users);
                myCashDB.SubmitChanges();

                return true;    // Success !
            }
            catch
            {
                return false;    // Failed.

            }

        }

        public bool updateLogin(int id, string usName, string password)
        {

            try
            {
                var selectedUser = (from user in myCashDB.loginTBs where user.userID == id select user).ToList();

                selectedUser[0].userName = usName;
                selectedUser[0].password = password;

                myCashDB.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<loginTB> searchLogin(int id)
        {
            var res = (from ser in myCashDB.loginTBs where ser.userID == id select ser);
            return res.ToList();
        }
        //user part

        public List<userDetailsTB> viewAllUser()
        {
            var result = (from users in myCashDB.userDetailsTBs select users);

            return result.ToList();
        }

        public bool insertUser(string usName, string name, string branch, string imgPath)
        {
            try
            {
                userDetailsTB newUser = new userDetailsTB();

                newUser.userName = usName;
                newUser.employeeName = name;
                newUser.branch = branch;
                newUser.image = imgPath;

                myCashDB.userDetailsTBs.InsertOnSubmit(newUser);
                myCashDB.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<userDetailsTB> searchUser(string userName)
        {
            try
            {
                var searchedUser = (from serUser in myCashDB.userDetailsTBs where serUser.userName.Contains(userName) || serUser.employeeName.Contains(userName) select serUser);

                if (searchedUser.Any())
                {

                    return searchedUser.ToList();
                }
                else
                {
                    return null;

                }
            }

            catch
            {
                return null;
            }

        }

        public bool DeleteUser(string userName)
        {
            try
            {
                var users = myCashDB.userDetailsTBs.Where(s => s.userName == userName).FirstOrDefault();
                if (users == null)
                {
                    // We couldn't find a record with this ID.
                    return false;
                }
                myCashDB.userDetailsTBs.DeleteOnSubmit(users);
                myCashDB.SubmitChanges();

                return true;    // Success !
            }
            catch
            {
                return false;    // Failed.

            }

        }

        public bool updateUser(int id, string usName, string name, string branch, string imgPath, string password)
        {

            try
            {
                var selectedUser = (from user in myCashDB.userDetailsTBs where user.userID == id select user).ToList();

                selectedUser[0].branch = branch;
                selectedUser[0].employeeName = name;
                selectedUser[0].image = imgPath;
                selectedUser[0].userName = usName;

                bool login = updateLogin(id, usName, password);

                if (login)
                {
                    myCashDB.SubmitChanges();

                    return true;
                }

                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }

        }

        //item part
        public List<itemDetailsTB> viewAllItem()
        {
            var result = (from item in myCashDB.itemDetailsTBs select item);

            return result.ToList();
        }

        public bool insertItem(string Name, string Category, int purchesdPrice, int sellingPrice, string image, bool availability, string addedDate, string description, string size, int qty)
        {
            try
            {
                itemDetailsTB newItem = new itemDetailsTB();

                newItem.Name = Name;
                newItem.Category = Category;
                newItem.purchesdPrice = purchesdPrice;
                newItem.sellingPrice = sellingPrice;
                newItem.image = image;
                newItem.availability = availability;
                newItem.addedDate = addedDate;
                newItem.description = description;
                newItem.size = size;
                newItem.qty = qty;

                myCashDB.itemDetailsTBs.InsertOnSubmit(newItem);
                myCashDB.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<itemDetailsTB> searchItem(string itemName)
        {
            try
            {
                var searchedItem = (from seritem in myCashDB.itemDetailsTBs where seritem.Name.Contains(itemName) select seritem);

                if (searchedItem.Any())
                {

                    return searchedItem.ToList();
                }
                else
                {
                    return null;

                }
            }

            catch
            {
                return null;
            }

        }

        public bool DeleteItem(int itemID)
        {
            try
            {
                var item = myCashDB.itemDetailsTBs.Where(s => s.ItemID == itemID).FirstOrDefault();

                if (item == null)
                {
                    // We couldn't find a record with this ID.
                    return false;
                }
                myCashDB.itemDetailsTBs.DeleteOnSubmit(item);
                myCashDB.SubmitChanges();

                return true;    // Success !
            }
            catch
            {
                return false;    // Failed.

            }

        }

        public bool updateItem(int id, string Name, string Category, int purchesdPrice, int sellingPrice, string image, bool availability, string addedDate, string description, string size, int qty)
        {
            try
            {

                var selecteditem = (from itm in myCashDB.itemDetailsTBs where itm.ItemID == id select itm).ToList();

                selecteditem[0].Name = Name;
                selecteditem[0].image = image;
                selecteditem[0].Category = Category;
                selecteditem[0].purchesdPrice = purchesdPrice;
                selecteditem[0].sellingPrice = sellingPrice;
                selecteditem[0].availability = availability;
                selecteditem[0].addedDate = addedDate;
                selecteditem[0].description = description;
                selecteditem[0].size = size;
                selecteditem[0].qty = qty;

                myCashDB.SubmitChanges();
                return true;

            }

            catch
            {
                return false;
            }
        }



        //customer part

        public List<customerDetailsTB> viewAllCustomer()
        {
            var result = (from cust in myCashDB.customerDetailsTBs select cust);

            return result.ToList();
        }

        public bool insertCustomer(string name, int telephone, string email, string gender, string addedDate)
        {
            try
            {
                customerDetailsTB newCustomer = new customerDetailsTB();

                newCustomer.name = name;
                newCustomer.telephone = telephone;
                newCustomer.email = email;
                newCustomer.gender = gender;
                newCustomer.addedDate = addedDate;

                myCashDB.customerDetailsTBs.InsertOnSubmit(newCustomer);
                myCashDB.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<customerDetailsTB> searchCustomer(string customerName)
        {
            try
            {
                var searchedCustomer = (from serCustomer in myCashDB.customerDetailsTBs where serCustomer.name.Contains(customerName) select serCustomer);

                if (searchedCustomer.Any())
                {

                    return searchedCustomer.ToList();
                }
                else
                {
                    return null;

                }
            }

            catch
            {
                return null;
            }

        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = myCashDB.customerDetailsTBs.Where(s => s.customerID == customerId).FirstOrDefault();
                if (customer == null)
                {
                    // We couldn't find a record with this ID.
                    return false;
                }
                myCashDB.customerDetailsTBs.DeleteOnSubmit(customer);
                myCashDB.SubmitChanges();

                return true;    // Success !
            }
            catch
            {
                return false;    // Failed.

            }

        }

        public bool updateCustomer(int customerID, string nam, int tp, string gend, string email, string date)
        {
            //customerDetailsTB updatableTB = new customerDetailsTB();

            var selected = (from serCustomer in myCashDB.customerDetailsTBs where serCustomer.customerID == customerID select serCustomer).ToList();

            if (selected != null)
            {
                selected[0].name = nam;
                selected[0].telephone = tp;
                selected[0].gender = gend;
                selected[0].email = email;
                selected[0].addedDate = date;

                myCashDB.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


        //Report generating part

        public List<outOfStockDeatilsTB> viewAllOutOfStock()
        {
            var allData = (from stReport in myCashDB.outOfStockDeatilsTBs select stReport);
            return allData.ToList();
        }

        public bool insertOutOfStock(string date, int itemID, string name, int unitPrice, string cat, string addedDate, string overSince)
        {

            try
            {
                outOfStockDeatilsTB insertNew = new outOfStockDeatilsTB();

                insertNew.Date = date;
                insertNew.Name = name;
                insertNew.Item_ID = itemID;
                insertNew.Unit_Price = unitPrice;
                insertNew.Category = cat;
                insertNew.Added_Date = addedDate;
                insertNew.Stock_Over_Since = overSince;

                myCashDB.outOfStockDeatilsTBs.InsertOnSubmit(insertNew);
                myCashDB.SubmitChanges();

                return true;
            }

            catch
            {
                return false;
            }
        }

        public List<outOfStockDeatilsTB> searchOutOfStockReport(string date)
        {
            try
            {
                var selected = (from st in myCashDB.outOfStockDeatilsTBs where st.Date == date select st);
                return selected.ToList();
            }

            catch
            {
                return null;
            }
        }

        public bool updateItemavailability(int id)
        {
            var selected = (from serCustomer in myCashDB.itemDetailsTBs where serCustomer.ItemID == id select serCustomer).ToList();

            if (selected != null)
            {
                selected[0].availability = false;
            
                myCashDB.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        //bill generating part

        public bool insertInvoice(int BillNo, int ItemID, string ItemName, int ItemQty, int ItemUnitPrice, int ItemSumPrice, string Cashier, string Branch, string date)
        {
            invoiceTB newInvoice = new invoiceTB();

            newInvoice.BillNo = BillNo;
            newInvoice.ItemID = ItemID;
            newInvoice.ItemName = ItemName;
            newInvoice.ItemQty = ItemQty;
            newInvoice.ItemUnitPrice = ItemUnitPrice;
            newInvoice.ItemSumPrice = ItemSumPrice;
            newInvoice.Cashier = Cashier;
            newInvoice.Branch = Branch;
            newInvoice.Date = date;

            myCashDB.invoiceTBs.InsertOnSubmit(newInvoice);
            myCashDB.SubmitChanges();
            return true;

        }

        public List<itemDetailsTB> searchItemByID(int itemID)
        {
            try
            {
                var searchedItem = (from seritem in myCashDB.itemDetailsTBs where seritem.ItemID == itemID select seritem);

                if (searchedItem.Any())
                {

                    return searchedItem.ToList();
                }
                else
                {
                    return null;

                }
            }

            catch
            {
                return null;
            }

        }

        public int findLastBill()
        {

            int intIdt = myCashDB.invoiceTBs.Max(u => u.BillNo);
            return intIdt;

        }

        public bool reduceQty(int id, int amount)
        {
            try
            {

                var selecteditem = (from itm in myCashDB.itemDetailsTBs where itm.ItemID == id select itm).ToList();

                selecteditem[0].qty = selecteditem[0].qty - amount;

                if (selecteditem[0].qty - amount == 0)
                {
                    selecteditem[0].availability = false;
                }

                myCashDB.SubmitChanges();
                return true;

            }

            catch
            {
                return false;
            }
        }



        public List<invoiceTB> findBill(int id)
        {

            var selected = (from sel in myCashDB.invoiceTBs where sel.BillNo == id select sel);
            return selected.ToList();

        }


        //daily salse report part

        public bool insertSalse(int billNO,int total,string date)
        {
            DailySalseTB newsale = new DailySalseTB();

            newsale.BillNO = billNO;
            newsale.Amount = total;
            newsale.Date = date;

            myCashDB.DailySalseTBs.InsertOnSubmit(newsale);
            myCashDB.SubmitChanges();
            return true;
        }

    }
}




