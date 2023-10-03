using Coimbra.Services;
using USE.SoundService;

namespace USE.SoundService
{
    public interface ISoundService : IService
    {
        public void Initialize(SoundLibrary library) { }
    }
}
