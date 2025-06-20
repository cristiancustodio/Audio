using Supabase;
using Web.Configuration;

namespace Web.Services
{
    public class SupabaseService
    {
        private readonly Client _client;

        public SupabaseService(Web.Configuration.SupabaseOptions options)
        {
            var url = options.Url;
            var key = options.Key;

            var supabaseOptions = new Supabase.SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true
            };

            _client = new Client(url, key, supabaseOptions);
        }

        public Client GetClient() => _client;
    }
}
