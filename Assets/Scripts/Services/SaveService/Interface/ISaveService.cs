namespace Services.SaveService.Interface
{
    /// <summary>
    /// todo
    /// </summary>
    public interface ISaveService
    {
        /// <summary>
        /// Сохранить
        /// </summary>
        /// <param name="_key">Ключ по которому нужно сохранить данные</param>
        /// <param name="_data">Данные для сохранения</param>
        /// <returns>true - если сохрание удалось, false - если произошла ошибка</returns>
        public bool TrySave(string _key, string _data);
        public string GetData(string _key);
    }
}