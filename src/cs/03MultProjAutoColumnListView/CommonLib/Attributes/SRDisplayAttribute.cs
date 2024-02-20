using System.ComponentModel;
using System.Resources;

namespace CommonLib.Attributes;

public class SRDisplayNameAttribute(string resourceKey, Type resourceType) : DisplayNameAttribute
{
    private readonly string _resourceKey = resourceKey;
    private readonly ResourceManager _resourceManager = new(resourceType);

    public override string DisplayName
    {
        get
        {
            string? displayName = _resourceManager.GetString(_resourceKey);
            return displayName ?? base.DisplayName;
        }
    }

    public string ResourceKey => _resourceKey;
}
