namespace Catharsium.Cooking.Terminal.ActionHandlers.Choosers;

public interface ISelectionStep<T>
{
    Task<T> Select();
}