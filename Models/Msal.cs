using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BlazorTest.Models
{
    public partial class Msal
    {
        //[JsonProperty("id_token")]
        //public AuthResp IdToken { get; set; }

        [JsonProperty("auth_resp")]
        public AuthResp AuthResp { get; set; }
    }

    public partial class AuthResp
    {
        [JsonProperty("uniqueId")]
        public Guid UniqueId { get; set; }

        [JsonProperty("tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty("tokenType")]
        public string TokenType { get; set; }

        [JsonProperty("idToken")]
        public IdToken IdToken { get; set; }

        [JsonProperty("idTokenClaims")]
        public IdTokenClaims IdTokenClaims { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }

        [JsonProperty("expiresOn")]
        public DateTimeOffset ExpiresOn { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("accountState")]
        public Guid AccountState { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("accountIdentifier")]
        public Guid AccountIdentifier { get; set; }

        [JsonProperty("homeAccountIdentifier")]
        public string HomeAccountIdentifier { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("idToken")]
        public IdTokenClaims IdToken { get; set; }

        [JsonProperty("idTokenClaims")]
        public IdTokenClaims IdTokenClaims { get; set; }

        [JsonProperty("environment")]
        public Uri Environment { get; set; }
    }

    public partial class IdTokenClaims
    {
        [JsonProperty("ver")]
        public string Ver { get; set; }

        [JsonProperty("iss")]
        public Uri Iss { get; set; }

        [JsonProperty("sub")]
        public string Sub { get; set; }

        [JsonProperty("aud")]
        public Guid Aud { get; set; }

        [JsonProperty("exp")]
        public long Exp { get; set; }

        [JsonProperty("iat")]
        public long Iat { get; set; }

        [JsonProperty("nbf")]
        public long Nbf { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("preferred_username")]
        public string PreferredUsername { get; set; }

        [JsonProperty("oid")]
        public Guid Oid { get; set; }

        [JsonProperty("tid")]
        public Guid Tid { get; set; }

        [JsonProperty("nonce")]
        public Guid Nonce { get; set; }

        [JsonProperty("aio")]
        public string Aio { get; set; }
    }

    public partial class IdToken
    {
        [JsonProperty("rawIdToken")]
        public string RawIdToken { get; set; }

        [JsonProperty("claims")]
        public IdTokenClaims Claims { get; set; }

        [JsonProperty("issuer")]
        public Uri Issuer { get; set; }

        [JsonProperty("objectId")]
        public Guid ObjectId { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("preferredName")]
        public string PreferredName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nonce")]
        public Guid Nonce { get; set; }

        [JsonProperty("expiration")]
        public long Expiration { get; set; }
    }
}
