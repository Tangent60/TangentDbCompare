namespace WFA_DB_Updater
{
    interface IDatabase
    {
        string IP { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
        string Name { get; set; }
    }
}
