namespace MVVM.Unity.Command
{
    public interface ICommandFactory
    {
        void Populate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}