using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Library
{
    public class HTTP : IDisposable
    {
        public const int port = 80;
        private readonly TcpClient client_TCP;
        private NetworkStream network;

        // Инициализация
        public HTTP(string hostname)
        {
            client_TCP = new TcpClient(hostname, port);
        }

        // Отправка запроса серверу и принятие ответа
        public string SendRequest(string query)
        {
            // Создание потока для работы с сервером
            network = client_TCP.GetStream();

            // Запись запроса серверу
            network.Write(Encoding.ASCII.GetBytes(query));

            // Для работы с ответом сервераы
            byte[] buffer = new byte[client_TCP.ReceiveBufferSize];
            int currentNumOfBytesRead;
            var stringBuilder = new StringBuilder();
            do
            {
                // Чтение данных
                try
                {
                    currentNumOfBytesRead = network.Read(buffer);
                }
                catch (IOException)
                {
                    Dispose();
                    throw new IOException(ExceptionMessages.IOException);
                }

                // Если ответ оказался пустым
                if (currentNumOfBytesRead == 0)
                {
                    break;
                }

                // Конкатинация строк
                stringBuilder.AppendLine(Encoding.ASCII.GetString(buffer, 0,
                    currentNumOfBytesRead));

                // Чистка буфера
                Array.Clear(buffer, 0, buffer.Length);
            }
            while (currentNumOfBytesRead == buffer.Length);

            // Строка с ответом сервера
            return stringBuilder.ToString();
        }

        // Закрытие соединения
        public void Dispose()
        {
            network?.Close();
            client_TCP?.Close();
        }
    }
}
