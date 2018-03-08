using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace DocumentsKeeperDemo.Web
{
	/// <summary>
	/// The unity resolver.
	/// </summary>
	public class UnityResolver : IDependencyResolver
	{
		private readonly IUnityContainer container;

		/// <summary>
		/// Initializes a new instance of the <see cref="UnityResolver"/> class.
		/// </summary>
		/// <param name="container"></param>
		public UnityResolver(IUnityContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException(nameof(container));
			}

			this.container = container;
		}

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <param name="serviceType">The service's type.</param>
		/// <returns>
		/// The service.
		/// </returns>
		public object GetService(Type serviceType)
		{
			try
			{
				return this.container.Resolve(serviceType);
			}
			catch (ResolutionFailedException)
			{
				return null;
			}
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			try
			{
				return this.container.ResolveAll(serviceType);
			}
			catch (ResolutionFailedException)
			{
				return new List<object>();
			}
		}

		public IDependencyScope BeginScope()
		{
			var child = this.container.CreateChildContainer();
			return new UnityResolver(child);
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		public void Dispose(bool disposing)
		{
			container.Dispose();
		}
	}
}