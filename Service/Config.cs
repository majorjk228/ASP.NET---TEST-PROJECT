// Класс для конфигурации всего проекта 
// Настройки берутся из appsetings 
// Сделано для того, чтобы сменить что-либо в аппстеинг, изменения внесутся во все места, так как везде булет использоваться геттер класса

namespace TEST_TPLUS.Service
{
    public class Config
    {
        public static string? ConnectionString { get; set; }
        public static string? CompanyName { get; set; }
        public static string? CompanyEmail { get; set; }
        public static string? CompanyPhone { get; set; }
    }
}
