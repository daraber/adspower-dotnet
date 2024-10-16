namespace AdsPower.LocalApi.Profile.Models;

/// <summary>
/// Represents the configuration settings for proxy usage in an account.
/// </summary>
public record UserProxyConfig
{
    /// <summary>
    /// The type of proxy software being used.
    /// Supported options include luminati, lumauto, oxylabsauto, 922S5auto, ipideaauto, ipfoxyauto,
    /// 922S5auth, kookauto, ssh, other, and noproxy.
    /// </summary>
    public required string ProxySoft { get; init; }

    /// <summary>
    /// The type of proxy connection. Supported types include http, https, and socks5.
    /// Can be omitted for no_proxy.
    /// </summary>
    public string? ProxyType { get; init; }

    /// <summary>
    /// The address of the proxy server. Users can enter either a domain name or an IP address.
    /// Can be omitted for no_proxy.
    /// </summary>
    public string? ProxyHost { get; init; }

    /// <summary>
    /// The port number for the proxy server.
    /// Can be omitted for no_proxy.
    /// </summary>
    public string? ProxyPort { get; init; }

    /// <summary>
    /// The username for proxy authentication.
    /// </summary>
    public string? ProxyUser { get; init; }

    /// <summary>
    /// The password for proxy authentication.
    /// </summary>
    public string? ProxyPassword { get; init; }

    /// <summary>
    /// A URL for changing the proxy IP address, primarily for mobile proxies.
    /// Supported protocols: http, https, and socks5.
    /// </summary>
    public string? ProxyUrl { get; init; }

    /// <summary>
    /// A flag to indicate whether to manage a list of accounts using the proxy.
    /// 0: No management; 1: Managed.
    /// </summary>
    public int GlobalConfig { get; init; } = 0;
}
