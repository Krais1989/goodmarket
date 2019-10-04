namespace GoodMarket.RabbitMQ.Options
{
    public class RabbitConnectionOptions
    {
        public string HostName { get; set; } = "localhost";
        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string VirtualHost { get; set; } = "/";
        public bool AutomaticRecoveryEnabled { get; set; } = true;
        public int RequestedHeartbeat { get; set; } = 30;
    }
}