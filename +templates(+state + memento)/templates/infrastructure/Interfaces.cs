using System.Collections.Generic;
using templates.bussiness;

namespace templates.infrastructure
{
    public interface ICommandExecutionResult
    {
        bool Success { get; set; }
    }

    public interface ICommandUndoResult
    {
        bool Success { get; set; }
    }

    public interface ICommand
    {
        IOrder Order { get; set; }

        ICommandExecutionResult Execute();

        ICommandUndoResult Undo();

        IMemento GetSnapshot();
    }

    public interface IMemento
    {
        ICommand Command { get; set; }

        void Restore();
    }

    public interface ICommandProcessor
    {
        IEnumerable<IMemento> Snapshots { get; set; }

        void AddCommandToExecute(ICommand command);

        ICommandExecutionResult Run();

        ICommandUndoResult Undo();
    }
}
