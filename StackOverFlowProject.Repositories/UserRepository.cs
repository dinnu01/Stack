using StackOverFlowProject.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlowProject.ServiceLayer
{
    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserdetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string email, string password);
        List<User> GetUsersByEmail(string email);
        List<User> GetUsersByUserId(int UserID);
        int GetLatestUserID();


    }

    public class UsersRepository : IUsersRepository
    {
        StackOverFlowDatabaseDbCon db;

        public UsersRepository()
        {
            db = new StackOverFlowDatabaseDbCon();
        }
        public void DeleteUser(int uid)
        {

        }

        public int GetLatestUserID()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            List<User> us = db.Users.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.Name).ToList();
            return us;
        }

        public List<User> GetUsersByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersByUserId(int UserID)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserdetails(User u)
        {
            User us = db.Users.Where(temp => temp.UserId == u.UserId).FirstOrDefault();
            if (us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User us = db.Users.Where(temp => temp.UserId == u.UserId).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }
    }
}
