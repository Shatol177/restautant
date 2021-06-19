using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class CheckController
    {
        public bool CorrectEmail(string email)
        {
            bool correctemail = false;
            bool sob = false;
            bool toch = false;
            foreach (char item in email)
            {
                if (item == '@')
                {
                    sob = true;
                }
                if (item == '.')
                {
                    toch = true;
                }
                if (toch == true && sob == true)
                {
                    correctemail = true;
                }
            }
            if (correctemail == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool TextNull(string text)
        {
            if (text == "")
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
