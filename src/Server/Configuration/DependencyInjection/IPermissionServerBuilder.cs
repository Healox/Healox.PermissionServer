namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// IdentityServer builder Interface
    /// </summary>
    public interface IPermissionServerBuilder
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        IServiceCollection Services { get; }
    }
}
