using SimpleForex.Core.Contracts.Commands;

namespace SimpleForex.Core.Contracts.Factories
{
    public interface ICommandFactory
    {
        TCommand MakeCommand<TCommand>() where TCommand : ICommandBase;
    }
}
