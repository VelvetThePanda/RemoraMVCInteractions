using Remora.Results;
using RemoraMVCInteractions.Attributes;
using RemoraMVCInteractions.Services;

namespace RemoraMVCInteractions;

public class PlaceHolder : InteractionController // ?
{
    [Button("some_button")]
    public async Task<IResult> ThingAsync() => throw new NotImplementedException();

    [Select("some_select")]    
    public async Task<IResult> OtherThingAsync() => throw new NotImplementedException();

    [Modal("some_modal")]
    public async Task<IResult> OtherOtherThingAsync() => throw new NotImplementedException();

    [Interaction("some_future_type_or_catchall")]
    public async Task<IResult> FallAsync() => throw new NotImplementedException();
}