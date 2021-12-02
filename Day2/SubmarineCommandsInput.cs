using Common;

namespace Day2
{
    public readonly struct SubmarineCommandsInput : IInputSource<SubmarineCommandsInput, SubCommand>
    {
        public IEnumerable<SubCommand> Load(string name) => 
            default(LinesInput)
                .Load(name)
                .SelectWhere<string, SubCommand>(SubCommand.TryParse);
    }
}