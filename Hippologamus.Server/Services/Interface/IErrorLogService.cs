using Hippologamus.Shared.DTO;
using Hippologamus.Server.Factorys;
using Hippologamus.Server.Services.Interface;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace Hippologamus.Server.Services.Interface
{
    public interface IErrorLogService
    {
        Task<ErrorLogCollectionResponce> Search(ErrorLogCollectionSearch search);
        Task<ErrorLogCollectionResponce> GetByLink(string link);
    }
}
