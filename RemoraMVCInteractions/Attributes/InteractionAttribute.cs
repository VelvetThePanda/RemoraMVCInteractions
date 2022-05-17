namespace RemoraMVCInteractions.Attributes;

/// <summary>
/// Represents the base marker attribute for 
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class InteractionAttribute : Attribute
{
    public string CustomID { get; protected set; }

    public InteractionAttribute(string customID) => CustomID = customID;
}