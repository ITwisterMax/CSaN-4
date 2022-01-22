using System.Text;

namespace Library.Query
{
    public class Query
    {
        private readonly StringBuilder stringBuilder;

        // Инициализация
        public Query()
        {
            stringBuilder = new StringBuilder();
        }

        // Добавление очередной части запроса
        public void AddToQuery(string partOfQuery)
        {
            stringBuilder.Append(partOfQuery);
        }

        // Получение строки запроса
        public string GetStringQuery()
        {
            return stringBuilder.ToString();
        }
    }
}
