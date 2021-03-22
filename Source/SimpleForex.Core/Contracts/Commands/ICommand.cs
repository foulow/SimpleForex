namespace SimpleForex.Core.Contracts.Commands
{

    /// <summary>
    /// References a command interface.
    /// </summary>
    public interface ICommand : ICommandBase
    {
        /// <summary>
        /// Calls logic to be executed on the command. 
        /// </summary>
        void Execute();
    }
}
