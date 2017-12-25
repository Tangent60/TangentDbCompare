using System.Data.SqlClient;

namespace DatabaseCompare.Domain
{
    /// <summary>
    /// Summary description for StoredProc.
    /// </summary>
    public class StoredProc : DatabaseObject
    {
        #region Properties
        public string TextDefinition { get; set; }
        #endregion

        public StoredProc(string name, int id) : base(name, id)
        {
        }

        public override void GatherData(SqlConnection conn)
        {
            base.GatherData(conn);
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = "select text from syscomments where id=@id";
                command.Parameters.AddWithValue("@id", this.Id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        TextDefinition += reader.GetString(0).Trim().ToLower();
                }
            }
        }

        protected override bool LocalCompare(DatabaseObject obj)
        {
            if (obj is StoredProc)
                return this.TextDefinition == ((StoredProc)obj).TextDefinition;
            return false;
        }

    }
}
