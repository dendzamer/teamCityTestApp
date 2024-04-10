using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace teamCityTest
{
    public class WidgetContext
    {
        private readonly IMongoDatabase database;

        public WidgetContext(IOptions<MongoDbOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            database = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Widget> WidgetSet => database.GetCollection<Widget>("Widgets");
    }

    public class MongoDbOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
    }

    public class MongoDBOptionsSetup(IConfiguration configuration) : IConfigureOptions<MongoDbOptions>
    {
        private const string CONNECTION_STRING = "MongoDbOptions:ConnectionString";
        private const string DATABASE_NAME = "MongoDbOptions:Database";

        public void Configure(MongoDbOptions options)
        {
            options.ConnectionString = configuration[CONNECTION_STRING] ?? throw new ArgumentNullException(CONNECTION_STRING);
            options.Database = configuration[DATABASE_NAME] ?? throw new ArgumentNullException(DATABASE_NAME);
        }
    }
}
