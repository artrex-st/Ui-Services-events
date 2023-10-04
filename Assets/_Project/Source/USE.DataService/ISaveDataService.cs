using Coimbra.Services;

namespace USE.DataService
{
    public interface ISaveDataService: IService
    {
        public GameData GameData { get; }
        public void Initialize(string fileName, bool useEncryption);
        void SaveData(GameData data);
        public void SaveGame();
    }
}
