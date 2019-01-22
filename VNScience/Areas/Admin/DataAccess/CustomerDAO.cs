using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VNScience.Models;
using VNScience.Models.Core;
using System.Data.Entity;

namespace VNScience.Areas.Admin.DataAccess
{
    public class CustomerDAO
    {
        ApplicationDbContext _db;
        public CustomerDAO(ApplicationDbContext db)
        {
            this._db = db;
        }

        public List<Customer> GetAll()
        {
            return _db.Customers
                .Include(e => e.CreatingUser)
                .Include(e => e.UpdatingUser)
                .ToList();
        }

        public List<Customer> GetAllExcept(int id)
        {
            return _db.Customers
                 .Include(e => e.CreatingUser)
                .Include(e => e.UpdatingUser)
                .Where(e => e.Id != id)
                .ToList();
        }

        public Customer Get(int id)
        {
            return _db.Customers
                .Include(e => e.CreatingUser)
                .Include(e => e.UpdatingUser)
                .FirstOrDefault(e => e.Id == id);
        }

        //CRUD
        public bool Insert(Customer customer)
        {
            bool isSuccess = true;

            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;
        }

        public bool Update(Customer customer)
        {
            bool isSuccess = true;

            try
            {
                _db.Entry(customer).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;
        }

        public bool Delete(int id)
        {
            bool isSuccess = true;

            try
            {
                _db.Customers.Remove(_db.Customers.Find(id));
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;
        }

    }
}