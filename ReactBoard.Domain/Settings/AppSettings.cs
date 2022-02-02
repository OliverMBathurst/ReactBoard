namespace ReactBoard
{
    public sealed class AppSettings
    {
        public int MaxPostLength { get; set; } = 500;

        public string DatabaseConnectionString { get; set; }

        public string Secret { get; set; }

        public int ThreadsPerPage { get; set; } = 10;
    }
}