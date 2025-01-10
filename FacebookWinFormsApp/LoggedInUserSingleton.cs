using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class LoggedInUserSingleton
    {
        public FacebookWrapper.LoginResult LoginResult { get; set; }

        private LoggedInUserSingleton()
        {

        }

        public static LoggedInUserSingleton Instance
        {
            get { return Singleton<LoggedInUserSingleton>.Instance; }
        }
    }
}
