using CleanArchitecture.Tools.Marker;

namespace CleanArchitecture.Tools.Data
{
    public interface IGuidService : IApplicationService
    {
        Guid CreateNew();
    }
}
