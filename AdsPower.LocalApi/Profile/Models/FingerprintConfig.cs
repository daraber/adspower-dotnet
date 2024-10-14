using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Profile.Models;

/// <summary>
/// Represents the configuration settings for browser fingerprinting.
/// </summary>
public record FingerprintConfig
{
    /// <summary>
    /// Indicates whether the timezone is automatically generated based on IP (1) or is a custom timezone (0).
    /// </summary>
    [JsonPropertyName("automatic_timezone")]
    public int AutomaticTimezone { get; init; } = 1;

    /// <summary>
    /// Custom timezone. An empty string represents the local timezone by default.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// WebRTC configuration. Options: forward, proxy, local, disabled.
    /// </summary>
    [JsonPropertyName("webrtc")]
    public string? WebRTC { get; init; } = "disabled";

    /// <summary>
    /// Location permission setting. Options: ask, allow, block.
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; init; } = "ask";

    /// <summary>
    /// Indicates whether to use IP-based (1) or custom location (0).
    /// </summary>
    [JsonPropertyName("location_switch")]
    public int LocationSwitch { get; init; } = 1;

    /// <summary>
    /// Longitude of the location, necessary when designating location.
    /// </summary>
    [JsonPropertyName("longitude")]
    public string? Longitude { get; init; }

    /// <summary>
    /// Latitude of the location, necessary when designating location.
    /// </summary>
    [JsonPropertyName("latitude ")]
    public string? Latitude { get; init; }

    /// <summary>
    /// Configures the accuracy of the location, necessary when designating location.
    /// </summary>
    [JsonPropertyName("accuracy")]
    public int Accuracy { get; init; } = 1000;

    /// <summary>
    /// Languages supported by the browser as an array of strings.
    /// </summary>
    public List<string>? Language { get; init; } = ["en-US", "en"];

    /// <summary>
    /// Language configuration switch based on IP country (1: On, 0: Off).
    /// </summary>
    [JsonPropertyName("language_switch")]
    public int LanguageSwitch { get; init; } = 1;

    /// <summary>
    /// Page language to be matched based on the provided languages.
    /// </summary>
    public string PageLanguage { get; init; } = "native";

    /// <summary>
    /// User-agent string for the browser.
    /// </summary>
    [JsonPropertyName("ua")]
    public string? UserAgent { get; init; }

    /// <summary>
    /// Screen resolution configuration.
    /// </summary>
    [JsonPropertyName("screen_resolution")]
    public string? ScreenResolution { get; init; } = "none";

    /// <summary>
    /// Custom fonts as an array of strings.
    /// </summary>
    [JsonPropertyName("fonts")]
    public List<string>? Fonts { get; init; } = ["all"];

    /// <summary>
    /// Canvas fingerprint switch (1: Add noise, 0: Use current default).
    /// </summary>
    [JsonPropertyName("canvas")]
    public int Canvas { get; init; } = 1;

    /// <summary>
    /// WebGL image fingerprint switch (1: Add noise, 0: Use current default).
    /// </summary>
    [JsonPropertyName("webgl_image")]
    public int WebGLImage { get; init; } = 1;

    /// <summary>
    /// WebGL metadata fingerprint switch (0: Default, 2: Custom, 3: Random).
    /// </summary>
    [JsonPropertyName("webgl")]
    public int WebGL { get; init; } = 3;

    /// <summary>
    /// Custom WebGL metadata configuration.
    /// </summary>
    [JsonPropertyName("webgl_config")]
    public object? WebGLConfig { get; init; }

    /// <summary>
    /// Audio fingerprint switch (1: Add noise, 0: Close).
    /// </summary>
    [JsonPropertyName("audio")]
    public int Audio { get; init; } = 1;

    /// <summary>
    /// Do Not Track configuration switch.
    /// Options: default, true, false.
    /// </summary>
    [JsonPropertyName("do_not_track")]
    public string DoNotTrack { get; init; } = "default";

    /// <summary>
    /// Number of CPU cores.
    /// </summary>
    [JsonPropertyName("hardware_concurrency")]
    public int HardwareConcurrency { get; init; } = 4;

    /// <summary>
    /// Amount of device memory.
    /// </summary>
    [JsonPropertyName("device_memory")]
    public int DeviceMemory { get; init; } = 8;

    /// <summary>
    /// Flash configuration switch (allow or block).
    /// </summary>
    [JsonPropertyName("flash")]
    public string Flash { get; init; } = "block";

    /// <summary>
    /// Port scan protection configuration (1: Enable, 0: Close).
    /// </summary>
    [JsonPropertyName("scan_port_type")]
    public int ScanPortType { get; init; } = 1;

    /// <summary>
    /// Ports allowed to be scanned when port scan protection is enabled.
    /// </summary>
    [JsonPropertyName("allow_scan_ports")]
    public List<string>? AllowScanPorts { get; init; }

    /// <summary>
    /// Media device switch (0: off, 1: noise with local devices, 2: noise with custom number).
    /// </summary>
    [JsonPropertyName("media_devices")]
    public int MediaDevices { get; init; } = 1;

    /// <summary>
    /// Number of audio and video input/output devices.
    /// </summary>
    [JsonPropertyName("media_devices_num")]
    public object? MediaDevicesNum { get; init; }

    /// <summary>
    /// ClientRects switch (0: Use defaults, 1: Add noise).
    /// </summary>
    [JsonPropertyName("client_rects")]
    public int ClientRects { get; init; } = 1;

    /// <summary>
    /// Device name configuration switch (0: Close, 1: Mask, 2: Custom).
    /// </summary>
    [JsonPropertyName("device_name_switch")]
    public int DeviceNameSwitch { get; init; } = 1;

    /// <summary>
    /// Custom device name.
    /// </summary>
    [JsonPropertyName("device_name")]
    public string? DeviceName { get; init; }

    /// <summary>
    /// Random UA configuration.
    /// </summary>
    [JsonPropertyName("random_ua")]
    public object? RandomUA { get; init; }

    /// <summary>
    /// Speech voices switch (0: Default, 1: Replace with a value).
    /// </summary>
    [JsonPropertyName("speech_switch")]
    public int SpeechSwitch { get; init; } = 1;

    /// <summary>
    /// MAC address configuration.
    /// </summary>
    [JsonPropertyName("mac_address_config")]
    public object? MacAddressConfig { get; init; }

    /// <summary>
    /// Browser kernel configuration.
    /// </summary>
    [JsonPropertyName("browser_kernel_config")]
    public object? BrowserKernelConfig { get; init; }

    /// <summary>
    /// GPU configuration (0: Local settings, 1: Enable hardware acceleration, 2: Disable).
    /// </summary>
    [JsonPropertyName("gpu")]
    public int Gpu { get; init; } = 0;
}