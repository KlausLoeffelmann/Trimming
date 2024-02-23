namespace CommonLib.Attributes;

public class AotReflectionAttribute
{
    public AotReflectionAttribute(Type reflectingType)
    {
        ReflectingType = reflectingType;
    }

    public Type ReflectingType { get; }
}
