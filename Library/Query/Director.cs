namespace Library.Query
{
    public class Director
    {
        private IBuilder builder;

        // Инициализация
        public IBuilder Builder
        {
            set { builder = value; }
        }

        // Формирование содержимого запроса без отправки на сервер (GET, HEAD)
        public void BuildQueryWithoutBody(string method, string path, string host)
        {
            builder.AddMethod(method);
            builder.AddPath(path);
            builder.AddVersion();
            builder.AddHost(host);
            builder.AddUserAgent();
            builder.AddAccept();
            builder.AddEndOfQuery();
        }

        // Формирование содержимого запроса с отправкой на сервер (POST)
        public void BuildPostQuery(string path, string host, string content)
        {
            builder.AddMethod("POST");
            builder.AddPath(path);
            builder.AddVersion();
            builder.AddHost(host);
            builder.AddUserAgent();
            builder.AddAccept();
            builder.AddContentType();
            builder.AddContentLength(content);
            builder.AddContent(content);
            builder.AddEndOfQuery();
        }
    }
}
