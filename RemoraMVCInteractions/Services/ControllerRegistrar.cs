using System.Reflection;
using Remora.Results;
using RemoraMVCInteractions.Attributes;
using RemoraMVCInteractions.Errors;

namespace RemoraMVCInteractions.Services;

public class ControllerRegistrar
{
    private const int MaxCustomIDLength = 80;
    
    public IReadOnlyList<Type> RegisteredControllerTypes => _registeredControllerTypes;

    private readonly List<Type> _registeredControllerTypes = new();

    public void RegisterType<TController>() where TController : InteractionController
        => RegisterType(typeof(TController));

    public void RegisterType(Type type)
    {
        if (!_registeredControllerTypes.Contains(type))
           _registeredControllerTypes.Add(type);
    }

    public Result Validate()
    {
        var seenNames = new HashSet<string>();

        foreach (var type in _registeredControllerTypes)
        {
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes();

                if (!attributes.Any())
                    continue;

                if (attributes.SingleOrDefault(att => att.GetType().IsAssignableTo(typeof(InteractionAttribute))) is {} interactionAttribute)
                {
                    if ((interactionAttribute as InteractionAttribute).CustomID.Length > MaxCustomIDLength)
                        return Result.FromError(new ValidationError("The specified custom ID exceeds the maximum length.\n" +
                                                                    ""))
                }
            }
        }
    }
}