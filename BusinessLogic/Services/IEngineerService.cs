using BusinessLogic.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IEngineerService
    {
        Task<VolumetricData> CalculateVolumetricDataAsync(string filename); 
    }
}
