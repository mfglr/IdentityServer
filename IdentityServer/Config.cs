using IdentityServer4.Models;

namespace IdentityServer
{
	public static class Config
	{
		public static IReadOnlyCollection<ApiResource> GetApiResources()
		{
			return new List<ApiResource>()
			{
				new ApiResource("resource_api1"){
					Scopes = {
						"api1.read",
						"api1.write",
						"api1.update"
					},
					ApiSecrets = { new Secret("secret".Sha256()) }
				},

				new ApiResource("resource_api2"){
					Scopes = {
						"api2.read",
						"api2.write",
						"api2.update"
					},
					ApiSecrets = { new Secret("secret".Sha256()) }
				}
			};
		}

		public static IReadOnlyCollection<ApiScope> GetApiScopes()
		{
			return new List<ApiScope>()
			{
				new ApiScope("api1.read","Read permission for Api1"),
				new ApiScope("api1.write","Write permission for Api1"),
				new ApiScope("api1.update","Update permission for Api1"),
				new ApiScope("api2.read","Read permission for Api2"),
				new ApiScope("api2.write","Write permission for Api2"),
				new ApiScope("api2.update","Update permission for Api2"),


			};
		}

		public static IReadOnlyCollection<Client> GetClients()
		{
			return new List<Client>()
			{
				new Client()
				{
					ClientId = "client1",
					ClientName = "Client 1",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets = new[] { new Secret("secret".Sha256()) },
					AllowedScopes = { "api1.read" },
				},
				new Client()
				{
					ClientId = "client2",
					ClientName = "Client 2",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets = new[] { new Secret("secret".Sha256()) },
					AllowedScopes = { "api2.write", "api2.update" },
				}
			};
		}

	}
}
