using System.Text.Json.Serialization;

namespace AdsPower.LocalApi.Profile.Models;

/// <summary>
/// Represents the profile information.
/// </summary>
public record ProfileInfo
{
    /// <summary>
    /// Gets the serial number.
    /// </summary>
    [JsonPropertyName("serial_number")]
    public string SerialNumber { get; init; } = string.Empty;

    /// <summary>
    /// Gets the user ID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    /// <summary>
    /// Gets the name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Gets the group ID.
    /// </summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; init; } = string.Empty;

    /// <summary>
    /// Gets the group name.
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; init; } = string.Empty;

    /// <summary>
    /// Gets the domain name.
    /// </summary>
    [JsonPropertyName("domain_name")]
    public string DomainName { get; init; } = string.Empty;

    /// <summary>
    /// Gets the username.
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; init; } = string.Empty;

    /// <summary>
    /// Gets the remark.
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; init; } = string.Empty;

    /// <summary>
    /// Gets the system application category ID.
    /// </summary>
    [JsonPropertyName("sys_app_cate_id")]
    public string SysAppCateId { get; init; } = string.Empty;

    /// <summary>
    /// Gets the created time as a timestamp.
    /// </summary>
    [JsonPropertyName("created_time")]
    public string CreatedTime { get; init; } = string.Empty;

    /// <summary>
    /// Gets the IP address.
    /// </summary>
    [JsonPropertyName("ip")]
    public string Ip { get; init; } = string.Empty;

    /// <summary>
    /// Gets the IP country code.
    /// </summary>
    [JsonPropertyName("ip_country")]
    public string IpCountry { get; init; } = string.Empty;

    /// <summary>
    /// Gets the password.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// Gets the last open time as a timestamp.
    /// </summary>
    [JsonPropertyName("last_open_time")]
    public string LastOpenTime { get; init; } = string.Empty;
}