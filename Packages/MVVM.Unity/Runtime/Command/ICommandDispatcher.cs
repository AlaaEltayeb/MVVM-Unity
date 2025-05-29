namespace MVVM.Unity.Command
{
    public interface ICommandDispatcher
    {
        void Execute(ICommand command);
    }
}