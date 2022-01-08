namespace ReactBoard
{
    public sealed class AppSettings
    {
        public int MaxPostLength { get; set; } = 500;

        public string DatabaseConnectionString { get; set; }
    }
}