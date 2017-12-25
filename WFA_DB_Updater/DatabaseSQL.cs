using System;

namespace WFA_DB_Updater
{
    class DatabaseSQL : IDatabase
    {
        public string IP
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}
