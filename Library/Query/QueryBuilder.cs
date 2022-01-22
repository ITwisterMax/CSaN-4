namespace Library.Query
{
    public class QueryBuilder : IBuilder
    {
        private Query query;

        // Инициализация
        public QueryBuilder()
        {
            Reset();
        }

        // Создание новой строки запроса
        public void Reset()
        {
            query = new Query();
        }

        // Добавление информации о методе
        public void AddMethod(string method)
        {
            query.AddToQuery(method);
        }

        // Добавление информации о пути
        public void AddPath(string path)
        {
            query.AddToQuery(path);
        }

        // Добавление информации о версии протокола
        public void AddVersion()
        {
            query.AddToQuery(QueryStrings.HttpVersion);
        }

        // Добавление информации о хосте
        public void AddHost(string host)
        {
            query.AddToQuery(QueryStrings.Host + host + QueryStrings.NewLine);
        }


        // Добавление информации о клиенте
        public void AddUserAgent()
        {
            query.AddToQuery(QueryStrings.UserAgent);
        }

        // Добавление информации о принимаемых файлах
        public void AddAccept()
        {
            query.AddToQuery(QueryStrings.AcceptedFiles);
        }

        // Добавление информации о типе принимаемого контента
        public void AddContentType()
        {
            query.AddToQuery(QueryStrings.ContentType);
        }

        // Добавление информации о длине принимаемого контента
        public void AddContentLength(string content)
        {
            query.AddToQuery(QueryStrings.ContentLength + content.Length.ToString()
                + QueryStrings.NewLine + QueryStrings.NewLine);
        }

        // Добавление информации о принимаемом контенте
        public void AddContent(string content)
        {
            query.AddToQuery(content);
        }

        // Добавление строки конца запроса
        public void AddEndOfQuery()
        {
            query.AddToQuery(QueryStrings.EndOfQuery);
        }

        // Возвращает готовый запрос
        public Query GetQuery()
        {
            var result_query = query;
            Reset();
            return result_query;
        }
    }
}
