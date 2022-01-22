using System;
using System.Windows;
using System.Windows.Documents;
using Library;
using Library.Query;

namespace Client
{
    public partial class Main : Window
    {
        // Разграничители текста
        private const string ClientRequestSeparator = "Client request:\n";
        private const string ServerResponseSeparator = "Server response:\n";
        private const string EndSeparator = "End\n";

        // Инициализация
        public Main()
        {
            InitializeComponent();
        }

        // Выбор метода(GET, HEAD)
        private void item_selected(object sender, RoutedEventArgs e)
        {
            if (request_body_richtextbox != null)
            {
                request_body_richtextbox.Document.Blocks.Clear();
                request_body_richtextbox.IsReadOnly = true;
            }
        }

        // Выбор метода (POST)
        private void post_selected(object sender, RoutedEventArgs e)
        {
            request_body_richtextbox.IsReadOnly = false;
        }

        // Нажатие на кнопку отправки метода
        private void send_request_button_click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Новый TCP-клиент
                using var http_сlient = new HTTP(host_textbox.Text);
                // Новый директор и конструктор запроса
                var director = new Director();
                var queryBuilder = new QueryBuilder();
                director.Builder = queryBuilder;
                // Новый путь
                string path = string.IsNullOrEmpty(path_textbox.Text) ? " / " : $" {path_textbox.Text} ";
                // Новая строка запроса
                string query;

                if (request_type_combobox.Text == "POST")
                {
                    // Получение отправляемого контента
                    string request_сontent = new TextRange(request_body_richtextbox.Document.ContentStart,
                        request_body_richtextbox.Document.ContentEnd).Text.Trim();

                    // Построение метода POST
                    director.BuildPostQuery(path, host_textbox.Text, request_сontent);
                    query = queryBuilder.GetQuery().GetStringQuery();
                }
                else
                {
                    // Построение метода GET, HEAD
                    director.BuildQueryWithoutBody(request_type_combobox.Text, path, host_textbox.Text);
                    query = queryBuilder.GetQuery().GetStringQuery();
                }

                // Отправка запроса и получение ответа сервера
                string response = http_сlient.SendRequest(query);

                // Вставка в конец поля ответа сервера очередного запроса и ответа
                TextRange textRange = new TextRange(log_richtextbox.Document.ContentEnd,
                    log_richtextbox.Document.ContentEnd)
                {
                    Text = ClientRequestSeparator.ToUpper() + query
                        + ServerResponseSeparator.ToUpper() + response + EndSeparator.ToUpper()
                };
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Нажатие на кнопку очистки ответа сервера
        private void clear_log_button_click(object sender, RoutedEventArgs e)
        {
            var textRange = new TextRange(log_richtextbox.Document.ContentStart, log_richtextbox.Document.ContentEnd)
            {
                Text = string.Empty
            };
        }
    }
}
