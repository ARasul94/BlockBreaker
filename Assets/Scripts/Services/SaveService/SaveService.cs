using Services.SaveService.Interface;

namespace Services.SaveService
{
    public class SaveService: ISaveService
    {
        private ISaveService m_saveService;

        public SaveService(ISaveService _saveServiceImpl)
        {
            m_saveService = _saveServiceImpl;
        }
        
        public bool TrySave(string _key, string _data)
        {
            return m_saveService.TrySave(_key, _data);
        }

        public string GetData(string _key)
        {
            return m_saveService.GetData(_key);
        }
    }
}