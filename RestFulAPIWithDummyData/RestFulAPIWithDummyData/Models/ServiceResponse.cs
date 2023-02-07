using RestFulAPIWithDummyData.Models;

namespace RestFulAPIWithDummyData.Models
{
    public class ServiceResponse<TEntity>
    {
        public ServiceResponse()
        {
        }

        public ServiceResponse(TEntity data)
        {
            Data = data;
        }

        public ServiceResponse(string error)
        {
            Error = error;
            Success = false;
        }

        public TEntity? Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}