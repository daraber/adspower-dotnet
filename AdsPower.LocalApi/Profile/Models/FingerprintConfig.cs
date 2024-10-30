using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Profile.Models;

/// <summary>
/// Represents the configuration settings for browser fingerprinting.
/// </summary>
public record FingerprintConfig
{
    /// <summary>
    /// 1: Timezone, automatically generated based on IP (Default setting); 0: Custom timezone.
    /// </summary>
    [JsonPropertyName("automatic_timezone")]
    public int AutomaticTimezone { get; init; } = 1;

    /// <summary>
    /// Custom timezone. An empty string represents the local timezone by default.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// Chrome instant messaging component, 4 options:
    /// forward: Use proxy IP to cover real IP, high-security (upgrade to V2.6.8.6 and above);
    /// proxy: Replace (Use proxy IP to cover real IP);
    /// local: Real (The local IP is acquired);
    /// disabled: Disabled (Default setting, website cannot obtain your IP).
    /// </summary>
    [JsonPropertyName("webrtc")]
    public string? WebRTC { get; init; } = "disabled";

    /// <summary>
    /// Website requests your current location. Ask: ask for permission (Default setting), the same as common browsers; Allow: always allow website to obtain your location information; Block: always block obtaining location.
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; init; } = "ask";

    /// <summary>
    /// 1: Location, generated based on IP (Default setting); 0: Custom location.
    /// </summary>
    [JsonPropertyName("location_switch")]
    public int LocationSwitch { get; init; } = 1;

    /// <summary>
    /// Configure the longitude of location, necessary when designating location. From -180 to 180 with 6 number after decimal point.
    /// </summary>
    [JsonPropertyName("longitude")]
    public string? Longitude { get; init; }

    /// <summary>
    /// Configure latitude of location, necessary when designating location, from -90 to 90 with 6 numbers after decimal point.
    /// </summary>
    [JsonPropertyName("latitude")]
    public string? Latitude { get; init; }

    /// <summary>
    /// Configure distance of location, necessary when designating location, from 10 to 5000 meters, should be integer.
    /// </summary>
    [JsonPropertyName("accuracy")]
    public int Accuracy { get; init; } = 1000;

    /// <summary>
    /// Language of the browser (Default setting: ["en-US","en"]), supports many languages, format: string array.
    /// </summary>
    public List<string>? Language { get; init; } = new List<string> { "en-US", "en" };

    /// <summary>
    /// Configure languages based on IP country. 0: Off; 1: On. Should upgrade to V2.4.4.3 or above.
    /// </summary>
    [JsonPropertyName("language_switch")]
    public int LanguageSwitch { get; init; } = 1;

    /// <summary>
    /// Match interface language based on [language], 0: Disabled 1: Enabled. Conditions for use: 1. Upgrade to Patch 2.6.72 or above. 2. Supported SunBrowser versions: a. Windows: Chrome 109 and above. b. macOS: Chrome 119 or above.
    /// </summary>
    [JsonPropertyName("page_language_switch")]
    public int PageLanguageSwitch { get; init; } = 1;

    /// <summary>
    /// Page language to be matched based on the provided languages. Defaults to native, i.e., the local language, you can also pass in the country code to see the page language.
    /// </summary>
    public string PageLanguage { get; init; } = "native";

    /// <summary>
    /// User-agent, default setting: using random ua base. When customizing please make sure that ua format and content meet the requirement.
    /// </summary>
    [JsonPropertyName("ua")]
    public string? UserAgent { get; init; }

    /// <summary>
    /// Screen resolution configuration. none: default setting, follow current computer. random: random resolution. When customizing, separate them with "_", width_height.
    /// </summary>
    [JsonPropertyName("screen_resolution")]
    public string? ScreenResolution { get; init; } = "none";

    /// <summary>
    /// Font of the browser. Allows to customize font, format: string array.
    /// </summary>
    [JsonPropertyName("fonts")]
    public List<string>? Fonts { get; init; } = new List<string> { "all" };

    /// <summary>
    /// Browser canvas fingerprint switch. 1: Add noise (Default setting); 0: Use the current computer default Canvas.
    /// </summary>
    [JsonPropertyName("canvas")]
    public int Canvas { get; init; } = 1;

    /// <summary>
    /// Browser webgl image fingerprint switch. 1: Add noise (Default setting); 0: Use the current computer default WebGL.
    /// </summary>
    [JsonPropertyName("webgl_image")]
    public int WebGLImage { get; init; } = 1;

    /// <summary>
    /// Browser webgl metadata fingerprint switch. 0: computer default; 2: Custom (need to define webgl_config); 3: Random matching (this type is only supported in the interface of adding an account, and the interface of updating an account is not currently supported). For 2 Custom, should upgrade to V 2.4.3.9 or above.
    /// </summary>
    [JsonPropertyName("webgl")]
    public int WebGL { get; init; } = 3;

    /// <summary>
    /// Custom browser webgl metadata. Unmasked vendor: providers; Unmasked renderer: can be customized only when webgl is 2. When webgl is 2, vendor and renderer cannot be empty. webgpu based on webgl_config 1: WebGL based matching 2: Real 0: Disabled. Should update to V 2.6.8.1 or above.
    /// </summary>
    [JsonPropertyName("webgl_config")]
    public object? WebGLConfig { get; init; }

    /// <summary>
    /// Audio fingerprint switch. 1: Add noise; (Default setting) 0: Close.
    /// </summary>
    [JsonPropertyName("audio")]
    public int Audio { get; init; } = 1;

    /// <summary>
    /// DNT means do not track. A browser configuration switch. 3 options: Default; True: open; False: close.
    /// </summary>
    [JsonPropertyName("do_not_track")]
    public string DoNotTrack { get; init; } = "default";

    /// <summary>
    /// The number of CPU cores. Follow the current computer (Default); 2; 4 (Default value if parameter is not passed); 6; 8; 16.
    /// </summary>
    [JsonPropertyName("hardware_concurrency")]
    public int HardwareConcurrency { get; init; } = 4;

    /// <summary>
    /// Amount of device memory. Follow the current computer (Default); 2; 4; 6; 8 (Default value if parameter is not passed).
    /// </summary>
    [JsonPropertyName("device_memory")]
    public int DeviceMemory { get; init; } = 8;

    /// <summary>
    /// Flash configuration switch. Allow or block (Default setting).
    /// </summary>
    [JsonPropertyName("flash")]
    public string Flash { get; init; } = "block";

    /// <summary>
    /// Port scan protection. 1: Enable (Default setting); 0: Close.
    /// </summary>
    [JsonPropertyName("scan_port_type")]
    public int ScanPortType { get; init; } = 1;

    /// <summary>
    /// Port allowed to be scanned when port scan protection is enabled, format: string array. Leave it empty if not to pass the parameter.
    /// </summary>
    [JsonPropertyName("allow_scan_ports")]
    public List<string>? AllowScanPorts { get; init; }

    /// <summary>
    /// Media device switch, 0: off (each Browser uses the default media device ID of the current computer) 1: Noise (number of devices follows local machine) 2: Noise (custom number of devices, media_devices_num needs to be transmitted). Need to upgrade to version V2.6.4.2 and above.
    /// </summary>
    [JsonPropertyName("media_devices")]
    public int MediaDevices { get; init; } = 1;

    /// <summary>
    /// Number of audio and video input/output devices. audioinput_num：Number of microphones(1-9)；videoinput_num：Number of cameras(1-9)；audiooutput_num: Number of speakers(1-9)； Need to upgrade to version V2.6.4.2 and above.
    /// </summary>
    [JsonPropertyName("media_devices_num")]
    public object? MediaDevicesNum { get; init; }

    /// <summary>
    /// ClientRects，0：Each browser uses the default ClientRects of the current computer. 1：Add corresponding noise, generate different ClientRects for each browser on the same computer. Should upgrade to V3.6.2 or above.
    /// </summary>
    [JsonPropertyName("client_rects")]
    public int ClientRects { get; init; } = 1;

    /// <summary>
    /// Device name, 0: Close, each browser uses the device name of the current computer. 1: Mask, replace your real device name with a suitable value. 2: Custom device name. Should upgrade to 3.6.25 or above, when the value is 2, upgrade to V2.4.8.1 and above.
    /// </summary>
    [JsonPropertyName("device_name_switch")]
    public int DeviceNameSwitch { get; init; } = 1;

    /// <summary>
    /// Custom device name. Should upgrade to V2.4.8.1 or above.
    /// </summary>
    [JsonPropertyName("device_name")]
    public string? DeviceName { get; init; }

    /// <summary>
    /// Support specified type, system, version setting ua. If you pass in a custom ua at the same time, take the custom ua first. ua_browser: chrome || firefox； ua_system_version: system； ua_version: version. This field is only supported in the create account interface, and the update account interface does not currently support the specified type, system and version update ua. tips: "ua_browser" is the same as the type under "browser_kernel_config". The default is chrome.
    /// </summary>
    [JsonPropertyName("random_ua")]
    public object? RandomUA { get; init; }

    /// <summary>
    /// SpeechVoices，0：Each profile uses the default SpeechVoices of the current computer 1：Use a value to replace the real SpeechVoices. Should update program version to V3.11.10 or above and kernel version to V2.5.0.9 or above.
    /// </summary>
    [JsonPropertyName("speech_switch")]
    public int SpeechSwitch { get; init; } = 1;

    /// <summary>
    /// MAC address: Support setting an appropriate value instead of the real MAC address. model: 0 (use the MAC address of the current computer) , 1 (match an appropriate value instead of the real MAC address) , 2 (custom appropriate value instead of the real MAC address). address: Custom MAC address, when model is 2, this value needs to be passed in. Should update program version to V4.3.9 or above.
    /// </summary>
    [JsonPropertyName("mac_address_config")]
    public object? MacAddressConfig { get; init; }

    /// <summary>
    /// Open the browser with the corresponding browser kernel. type:chrome || firefox, version specifies the kernel version. 92: 92 version of the kernel 99: 99 version of the kernel ua_auto: Smart match kernel version. The software version needs to be upgraded to v4.4.21 and above. This version only supports the optional values of version '92', '99', '102', '105', '108', '111'. firefox only supports 100 kernel version.
    /// </summary>
    [JsonPropertyName("browser_kernel_config")]
    public object? BrowserKernelConfig { get; init; }

    /// <summary>
    /// GPU configuration. 0：Deploy settings from [Local settings - Hardware acceleration] (default).
    /// 1：Turn on hardware acceleration to improve browser performance. Using different hardware may affect hardware-related fingerprints.
    /// 2：Turning off hardware acceleration will reduce browser performance.
    /// </summary>
    [JsonPropertyName("gpu")]
    public string Gpu { get; init; } = "0";
}