namespace AdsPower.LocalApi.Browser.Requests;

public record StartBrowserRequest : BrowserRequest
{
    /// <summary>
    /// Whether to open a platform or historical page.
    /// 0: Open (default), 1: Close. Requires version 2.4.2.9 or above.
    /// </summary>
    public int? OpenTabs { get; init; }

    /// <summary>
    /// Whether to open the IP detection page.
    /// 0: Not open, 1: Open (default). Requires version 2.5.7.9 or above.
    /// </summary>
    public int? IpTab { get; init; }

    /// <summary>
    /// Whether to use the new version of the IP detection page.
    /// 1: New version, 0: Old version (default). Requires version 2.6.6.9 or above.
    /// </summary>
    public int? NewFirstTab { get; init; }

    /// <summary>
    /// Browser startup parameters (e.g., "--blink-settings=imagesEnabled=false").
    /// Parameters set here will take priority over those in the profile. Requires version 2.4.6.7 or above.
    /// </summary>
    public string[]? LaunchArgs { get; init; }

    /// <summary>
    /// Whether to start the browser in headless mode.
    /// 0: No (default), 1: Yes. Requires version 2.4.6.7 or above.
    /// </summary>
    public int? Headless { get; init; }

    /// <summary>
    /// Whether to disable the function of automatically filling passwords.
    /// 0: No (default), 1: Yes. Requires version 2.4.6.7 or above.
    /// </summary>
    public int? DisablePasswordFilling { get; init; }

    /// <summary>
    /// Whether to delete the cache after closing the browser.
    /// 0: No (default), 1: Yes. Recommended if disk space is insufficient. Requires version 2.4.7.6 or above.
    /// </summary>
    public int? ClearCacheAfterClosing { get; init; }

    /// <summary>
    /// Whether to allow the saving of passwords.
    /// 0: No (default), 1: Yes. Requires version 2.4.8.7 or above.
    /// </summary>
    public int? EnablePasswordSaving { get; init; }

    /// <summary>
    /// Whether to mask the CDP (Chrome DevTools Protocol) detection.
    /// 1: Yes (default), 0: No.
    /// </summary>
    public int? CdpMask { get; init; }

    public override Dictionary<string, string> GetQueryParameters()
    {
        var parameters = base.GetQueryParameters();

        if (OpenTabs.HasValue) parameters.Add("open_tabs", OpenTabs.Value.ToString());
        if (IpTab.HasValue) parameters.Add("ip_tab", IpTab.Value.ToString());
        if (NewFirstTab.HasValue) parameters.Add("new_first_tab", NewFirstTab.Value.ToString());
        if (LaunchArgs is not null) parameters.Add("launch_args", string.Join(",", LaunchArgs));
        if (Headless.HasValue) parameters.Add("headless", Headless.Value.ToString());
        if (DisablePasswordFilling.HasValue) parameters.Add("disable_password_filling", DisablePasswordFilling.Value.ToString());
        if (ClearCacheAfterClosing.HasValue) parameters.Add("clear_cache_after_closing", ClearCacheAfterClosing.Value.ToString());
        if (EnablePasswordSaving.HasValue) parameters.Add("enable_password_saving", EnablePasswordSaving.Value.ToString());
        if (CdpMask.HasValue) parameters.Add("cdp_mask", CdpMask.Value.ToString());

        return parameters;
    }
}