using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDigitalCash
{
    class UserDataMgr
    {
        private static UserDataMgr instance;
        public static UserDataMgr Ins
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDataMgr();
                }
                return instance;
            }
        }
             
        /// <summary>
        /// ACCESS_KEY
        /// </summary>
        public readonly string ACCESS_KEY = "bbb16059-5d7b5dcb-4e0439cf-071bd";
        /// <summary>
        /// SECRET_KEY()
        /// </summary>
        public readonly string SECRET_KEY = "df270d8a-c3dd4b31-3feca633-ae19c";
    }
}
