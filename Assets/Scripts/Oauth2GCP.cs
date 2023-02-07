using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class Oauth2GCP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OauthConnection()
    {
        string clientId = "";
        string clientSecret = "";

        string[] scopes = { "https://oauth2.googleapis.com/token" , "https://dialogflow.googleapis.com/v2/projects/{0}/agent/sessions/{1}:detectIntent" };

        var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
            },
            scopes, "user", CancellationToken.None).Result;
        if (credentials.Token.IsExpired(SystemClock.Default))
            credentials.RefreshTokenAsync(CancellationToken.None).Wait();
    }



}
