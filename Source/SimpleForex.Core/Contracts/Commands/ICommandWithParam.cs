using SimpleForex.Core.Contracts.Commands;

namespace SimpleForex.Core.Contracts
{
    /// <summary>
    /// References a command interface with parameter.
    /// </summary>
    /// <typeparam name="TParam">The command required parameter.</typeparam>
    public interface ICommandWithParam<TParam> : ICommandBase
    {
        /// <summary>
        /// Calls logic to be executed on the command using the expected parameter.
        /// </summary>
        /// <param name="param"><typeparamref name="TParam"/></param>
        void Execute(TParam param);
    }
}
