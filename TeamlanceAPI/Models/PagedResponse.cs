namespace TeamlanceAPI.Models
{
    public class PagedResponse<T> : Response<T>
    {
       
       
        public int TotalCount { get; set; }


        public PagedResponse(T data,int totalRecord)
        {
           
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
            this.TotalCount = totalRecord;
        }
    }
}
