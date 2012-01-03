using System;
using System.Collections.Generic;
using Raven.Abstractions.Data;
using Raven.Database.Extensions;
using Raven.Database.Server.Abstractions;
using System.Linq;

namespace Raven.Database.Server.Security.NoAuth
{
	public class NoAuthRequestAuthorizer : AbstractRequestAuthorizer
	{
		#region implemented abstract members of Raven.Database.Server.Security.AbstractRequestAuthorizer
		public override bool Authorize (IHttpContext context)
		{
			return true;
		}
		#endregion
		
	}
}

