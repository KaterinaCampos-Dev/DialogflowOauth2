using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;

using System.Web;


public class OauthToken : MonoBehaviour
{
    private static async Task<Token> GetElibilityToken(HttpClient client)
{
    string baseAddress = @"";

    string grant_type = "";
    string client_id = "";
    string client_secret = "";

    var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                };

    HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
    var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
    Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
    return tok;
}


internal class Token
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
}      
}
