
namespace BasicFacebookFeatures
{
    public class LoggedInUserSingleton
    {
        public FacebookWrapper.LoginResult LoginResult { get; set; }

        private LoggedInUserSingleton()
        {}

        public static LoggedInUserSingleton Instance
        {
            get { return Singleton<LoggedInUserSingleton>.Instance; }
        }
    }
}
