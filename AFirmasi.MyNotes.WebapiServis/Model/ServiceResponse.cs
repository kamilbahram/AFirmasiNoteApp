namespace AFirmasi.MyNotes.WebapiServis.Model
{
    public class ServiceResponse<T> : BaseResponse
    {
        public ServiceResponse()
        {
            Errors = new List<String>();    
            Entities = new List<T>();
        }

        public T Entity { get; set; }   
        public List<T> Entities { get; set; }   
        public int EntitiesCount { get; set; }
        
    }
}
