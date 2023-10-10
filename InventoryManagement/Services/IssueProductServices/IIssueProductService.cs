using InventoryManagement.Dtos.IssueProductDto;
using InventoryManagement.Models;

namespace InventoryManagement.Services.IssueProductServices
{
    public interface IIssueProductService
    {
        Task<List<IssueProduct>> GetAllIssueProductAsync();

        Task<IssueProduct> GetIssueProductAsync(int issueProductId);
        Task<IssueProduct> CreateIssueProductAsync(IssueProduct issueProduct);

        Task<IssueProduct> UpdateIssueProductAsync(IssueProduct issueProduct, CreateIssueProductDto createIssueProductDto);

        Task<IssueProduct> DeleteIssueProductAsync(IssueProduct issueProduct);

        Task<List<IssueProduct>> SearchIssueProductAsync(string keyword);

    }
}
