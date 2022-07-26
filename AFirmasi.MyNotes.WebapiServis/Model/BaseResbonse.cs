namespace AFirmasi.MyNotes.WebapiServis.Model
{
    public abstract class BaseResponse
    {
        public List<String> Errors { get; set; }
        public bool HasError { get; set; }
        public bool IsSuccessFul { get; set; }
    }
}
