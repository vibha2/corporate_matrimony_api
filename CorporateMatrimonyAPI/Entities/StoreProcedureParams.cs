namespace CorporateMatrimony.API.Entities
{
    public class StoreProcedureParams
    {
        
        public string ProcedureName { get; set; } = string.Empty;
        public Dictionary<string, object> Parameters { get; set; } = new();
       

    }
}
