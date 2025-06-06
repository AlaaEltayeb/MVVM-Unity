using VContainer;

namespace MVVM.Unity.Command
{
    public sealed class CommandFactory : ICommandFactory
    {
        private readonly IObjectResolver _objectResolver;

        public CommandFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void Populate<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            _objectResolver.Inject(command);
        }
    }
}