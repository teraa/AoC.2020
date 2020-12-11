using System;
using System.Collections;
using System.Collections.Generic;

var instructions = new List<Instruction>();
string? line;
while ((line = Console.ReadLine()) is not null)
{
    var parts = line.Split(' ', 2);
    var ins = new Instruction
    {
        Operation = Enum.Parse<Operation>(parts[0], true),
        Argument = int.Parse(parts[1])
    };

    instructions.Add(ins);
}

var executed = new BitArray(instructions.Count);
int accumulator = 0;
int p = 0;
while (true)
{
    if (executed[p])
        break;

    executed[p] = true;

    var ins = instructions[p];
    switch(ins.Operation)
    {
        case Operation.Acc:
            accumulator += ins.Argument;
            break;

        case Operation.Jmp:
            p += ins.Argument;
            continue;
    }

    p++;
}

Console.WriteLine(accumulator);

class Instruction
{
    public Operation Operation { get; init; }
    public int Argument { get; init; }
}

enum Operation : ushort
{
    Acc,
    Jmp,
    Nop
}
