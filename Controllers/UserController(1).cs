using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    class UserController
    {
        ARM_RestoranEntities db = new ARM_RestoranEntities();
        public Clients usersobj;
        public Clients usersobj1;
        public Managers managerobj;
        public Managers managerobj1;
        public Admins adminobj;
        public Admins adminobj1;
        public Wraiters wraiterobj;
        public Wraiters wraiterobj1;
        public bool CheckLogin(string login)
        {
            usersobj = db.Clients.Where(x => x.login == login).FirstOrDefault();
            if (usersobj == null)
            {
                managerobj = db.Managers.Where(x => x.login == login).FirstOrDefault();
                if (managerobj == null)
                {
                    adminobj = db.Admins.Where(x => x.login == login).FirstOrDefault();
                    if (adminobj == null)
                    {
                        wraiterobj = db.Wraiters.Where(x => x.login == login).FirstOrDefault();
                        if (wraiterobj == null)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }


        }
        public bool CheckPassword(string password)
        {
            usersobj1 = db.Clients.Where(x => x.password == password).FirstOrDefault();
            if (usersobj1 == null)
            {
                managerobj1 = db.Managers.Where(x => x.password == password).FirstOrDefault();
                if (managerobj1 == null)
                {
                    adminobj1 = db.Admins.Where(x => x.password == password).FirstOrDefault();
                    if (adminobj1 == null)
                    {
                        wraiterobj1 = db.Wraiters.Where(x => x.password == password).FirstOrDefault();
                        if (wraiterobj1 == null)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public bool CheckName(string Name)
        {
            usersobj1 = db.Clients.Where(x => x.first_name == Name).FirstOrDefault();
            if (usersobj1 == null)
            {
                managerobj1 = db.Managers.Where(x => x.first_name == Name).FirstOrDefault();
                if (managerobj1 == null)
                {
                    adminobj1 = db.Admins.Where(x => x.first_name == Name).FirstOrDefault();
                    if (adminobj1 == null)
                    {
                        wraiterobj1 = db.Wraiters.Where(x => x.first_name == Name).FirstOrDefault();
                        if (wraiterobj1 == null)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public bool CheckEmail(string Email)
        {
            usersobj1 = db.Clients.Where(x => x.email == Email).FirstOrDefault();
            if (usersobj1 == null)
            {
                return false;
                
            }
            else
            {
                return true;
            }
        }

    }
}
