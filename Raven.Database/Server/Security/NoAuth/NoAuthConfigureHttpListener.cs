using System;
using System.Net;
using Raven.Database.Config;
using System.Linq;

namespace Raven.Database.Server.Security.NoAuth
{
	public class NoAuthConfigureHttpListener : IConfigureHttpListener
	{
		#region IConfigureHttpListener implementation
		public void Configure (HttpListener listener, InMemoryRavenConfiguration config)
		{
			if (string.Equals(config.AuthenticationMode, "NoAuth", StringComparison.InvariantCultureIgnoreCase) == false) 
				return;

			listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

			listener.AuthenticationSchemeSelectorDelegate = request => {
				return AuthenticationSchemes.Anonymous;
			};
		}
		#endregion
		
	}
}

