namespace AdsPower.LocalApi.Requests;

public record StartBrowserRequest : BrowserRequest
{
    /// <summary>
    /// Whether to open a platform or historical page.
    /// 0: Open (default), 1: Close. Requires version 2.4.2.9 or above.
    /// </summary>
    public int OpenTabs { get; init; } = 0;

    /// <summary>
    /// Whether to open the IP detection page.
    /// 0: Not open, 1: Open (default). Requires version 2.5.7.9 or above.
    /// </summary>
    public int IpTab { get; init; } = 1;

    /// <summary>
    /// Whether to use the new version of the IP detection page.
    /// 1: New version, 0: Old version (default). Requires version 2.6.6.9 or above.
    /// </summary>
    public int NewFirstTab { get; init; } = 0;

    /// <summary>
    /// Browser startup parameters (e.g., "--blink-settings=imagesEnabled=false").
    /// Parameters set here will take priority over those in the profile. Requires version 2.4.6.7 or above.
    /// </summary>
    public string[]? LaunchArgs { get; init; }

    /// <summary>
    /// Whether to start the browser in headless mode.
    /// 0: No (default), 1: Yes. Requires version 2.4.6.7 or above.
    /// </summary>
    public int Headless { get; init; } = 0;

    /// <summary>
    /// Whether to disable the function of automatically filling passwords.
    /// 0: No (default), 1: Yes. Requires version 2.4.6.7 or above.
    /// </summary>
    public int DisablePasswordFilling { get; init; } = 0;

    /// <summary>
    /// Whether to delete the cache after closing the browser.
    /// 0: No (default), 1: Yes. Recommended if disk space is insufficient. Requires version 2.4.7.6 or above.
    /// </summary>
    public int ClearCacheAfterClosing { get; init; } = 0;

    /// <summary>
    /// Whether to allow the saving of passwords.
    /// 0: No (default), 1: Yes. Requires version 2.4.8.7 or above.
    /// </summary>
    public int EnablePasswordSaving { get; init; } = 0;

    /// <summary>
    /// Whether to mask the CDP (Chrome DevTools Protocol) detection.
    /// 1: Yes (default), 0: No.
    /// </summary>
    public int CdpMask { get; init; } = 1;
}