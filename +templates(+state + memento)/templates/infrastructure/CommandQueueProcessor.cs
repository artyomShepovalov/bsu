using System.Collections.Generic;
using System.Linq;

namespace templates.infrastructure
{
    public class CommandQueueProcessor : ICommandProcessor
    {
        public IEnumerable<IMemento> Snapshots { get; set; } 

        private int _runPosition;

        public void AddCommandToExecute(ICommand command)
        {
            ((Queue<IMemento>) Snapshots).Enqueue(command.GetSnapshot());
        }

        public ICommandExecutionResult Run()
        {
            var snap = Snapshots.ToArray()[_runPosition++];
            snap.Restore();
            
            return snap.Command.Execute();
        }

        public ICommandUndoResult Undo()
        {
            --_runPosition;
            
            var snap = ((Queue<IMemento>) Snapshots).Dequeue();
            snap.Restore();

            return snap.Command.Undo();
        }
    }
}
