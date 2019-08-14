using BlazorTest.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorTest.Services
{
    public class MyAuthenticationStateProvider : AuthenticationStateProvider
    {

        //public AuthResp StaticStore.AuthResult { get; set; } = null;

        public MyAuthenticationStateProvider()
        {

        }

        public void ReAuthenticate()
        {
 
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.Run(() => {
                Console.WriteLine("Checking if auth result is present...");
                if (StaticStore.AuthResult == null) return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

                Console.WriteLine("Auth result is present! Creating claims...");
                var claimsList = new List<Claim>();
                claimsList.Add(new Claim("ver", StaticStore.AuthResult.IdTokenClaims.Ver));
                claimsList.Add(new Claim("iss", StaticStore.AuthResult.IdTokenClaims.Iss.ToString()));
                claimsList.Add(new Claim("sub", StaticStore.AuthResult.IdTokenClaims.Sub));
                claimsList.Add(new Claim("aud", StaticStore.AuthResult.IdTokenClaims.Aud.ToString()));
                claimsList.Add(new Claim("exp", StaticStore.AuthResult.IdTokenClaims.Exp.ToString()));
                claimsList.Add(new Claim("iat", StaticStore.AuthResult.IdTokenClaims.Iat.ToString()));
                claimsList.Add(new Claim("nbf", StaticStore.AuthResult.IdTokenClaims.Nbf.ToString()));
                claimsList.Add(new Claim("name", StaticStore.AuthResult.IdTokenClaims.Nbf.ToString()));
                claimsList.Add(new Claim("preferred_username", StaticStore.AuthResult.IdTokenClaims.PreferredUsername));
                claimsList.Add(new Claim("oid", StaticStore.AuthResult.IdTokenClaims.Oid.ToString()));
                claimsList.Add(new Claim("tid", StaticStore.AuthResult.IdTokenClaims.Tid.ToString()));
                claimsList.Add(new Claim("nonce", StaticStore.AuthResult.IdTokenClaims.Nonce.ToString()));
                claimsList.Add(new Claim("aio", StaticStore.AuthResult.IdTokenClaims.Aio));
                claimsList.Add(new Claim("accesstoken", StaticStore.AuthResult.AccessToken));
                var identity = new ClaimsIdentity(claimsList);
                Console.WriteLine("returning Authstate...");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            });
        }

        //public override Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    if(StaticStore.AuthResult == null) return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        //    //var authJson = await _b2cService.GetTokenAsync();
        //    //var identity = new ClaimsIdentity();

        //    //if (!string.IsNullOrEmpty(authJson))
        //    //{
        //    //    var msal = JsonConvert.DeserializeObject<AuthResp>(authJson);
        //    //    if (msal != null)
        //    //    {
        //    //        var claimsList = new List<Claim>();
        //    //        claimsList.Add(new Claim("ver", msal.IdTokenClaims.Ver));
        //    //        claimsList.Add(new Claim("iss", msal.IdTokenClaims.Iss.ToString()));
        //    //        claimsList.Add(new Claim("sub", msal.IdTokenClaims.Sub));
        //    //        claimsList.Add(new Claim("aud", msal.IdTokenClaims.Aud.ToString()));
        //    //        claimsList.Add(new Claim("exp", msal.IdTokenClaims.Exp.ToString()));
        //    //        claimsList.Add(new Claim("iat", msal.IdTokenClaims.Iat.ToString()));
        //    //        claimsList.Add(new Claim("nbf", msal.IdTokenClaims.Nbf.ToString()));
        //    //        claimsList.Add(new Claim("name", msal.IdTokenClaims.Nbf.ToString()));
        //    //        claimsList.Add(new Claim("preferred_username", msal.IdTokenClaims.PreferredUsername));
        //    //        claimsList.Add(new Claim("oid", msal.IdTokenClaims.Oid.ToString()));
        //    //        claimsList.Add(new Claim("tid", msal.IdTokenClaims.Tid.ToString()));
        //    //        claimsList.Add(new Claim("nonce", msal.IdTokenClaims.Nonce.ToString()));
        //    //        claimsList.Add(new Claim("aio", msal.IdTokenClaims.Aio));
        //    //        claimsList.Add(new Claim("accesstoken", msal.AccessToken));
        //    //        identity = new ClaimsIdentity(claimsList);
        //    //    }
        //    //}

        //    //return new AuthenticationState(new ClaimsPrincipal(identity));
        //}
    }
}
