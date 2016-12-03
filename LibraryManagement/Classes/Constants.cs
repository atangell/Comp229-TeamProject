using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Classes
{
    public static class Constants
    {
        static string _userExistDetail;


        /// Get or set the static important data.

        public static string userExistDetail
        {
            get
            {
                return _userExistDetail;
            }
            set
            {
                _userExistDetail = value;
            }
        }

    }
}