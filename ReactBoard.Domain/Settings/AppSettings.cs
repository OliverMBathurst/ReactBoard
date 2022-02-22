namespace ReactBoard.Domain.Settings
{
    public sealed class AppSettings
    {
        public int MaxPostLength { get; set; } = 500;

        public string ImageAPIEndpoint { get; set; }

        public string Secret { get; set; }

        public int ThreadsPerPage { get; set; } = 10;

        public int MaxFeaturedThreads { get; set; } = 8;
    }
}