namespace Library.Query
{
    public interface IBuilder
    {
        // Добавление метода
        void AddMethod(string method);

        // Добавление пути
        void AddPath(string path);

        // Добавление версии протокола
        void AddVersion();

        // Добавление хоста
        void AddHost(string host);

        // Добавление информации о клиенте
        void AddUserAgent();

        // Добавление информации о принятых файлах
        void AddAccept();

        // Добавление информации о типе отправленного контента
        void AddContentType();

        // Добавление информации о длине отправленного контента
        void AddContentLength(string content);

        // Добавление информации об отправленном контенте
        void AddContent(string content);

        // Добавление строки конца запроса
        void AddEndOfQuery();
    }
}
