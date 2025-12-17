using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;

namespace QuanLyTrungTam
{
    public class GoogleHelper
    {
        // Thay bằng Client ID thật của bạn từ Google Cloud Console
        private static string ClientId = "YOUR_CLIENT_ID.apps.googleusercontent.com";

        public static async Task<string> LoginGoogleAsync()
        {
            try
            {
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets { ClientId = ClientId, ClientSecret = "YOUR_CLIENT_SECRET" },
                    new[] { "email", "profile" },
                    "user",
                    System.Threading.CancellationToken.None
                );

                var payload = await GoogleJsonWebSignature.ValidateAsync(credential.Token.IdToken);
                return payload.Email; // Trả về Email để check trong DB
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}