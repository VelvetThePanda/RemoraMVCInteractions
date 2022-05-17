using Remora.Results;

namespace RemoraMVCInteractions.Errors;

public record ValidationError(string Message) : IResultError;