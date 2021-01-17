namespace todowebapp.data.Configs
{
        public class MongoDBConfig
        {
            public string Database { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }

            public string CollectionName {get;set;}

            public string ConnectionString {
                get {
                    return $@"mongodb://{Host}:{Port}";
                }
            }

        } 
}