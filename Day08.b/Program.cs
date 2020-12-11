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
var candidates = new BitArray(instructions.Count);
int p = 0;
while (true)
{
    if (executed[p]) break;

    executed[p] = true;

    var ins = instructions[p];

    switch(ins.Operation)
    {
        case Operation.Jmp:
            candidates[p] = true;
            p += ins.Argument;
            continue;

        case Operation.Nop:
            candidates[p] = true;
            break;
    }

    p++;
}

for (int i = 0; i < candidates.Length; i++)
{
    if (!candidates[i]) continue;

    executed.SetAll(false);
    int acc = 0;
    p = 0;
    bool loop = false;
    while (p < executed.Length)
    {
        if (executed[p])
        {
            loop = true;
            break;
        }

        executed[p] = true;

        var ins = instructions[p];
        if (i == p)
        {
            ins = new Instruction
            {
                Argument = ins.Argument,
                Operation = ins.Operation == Operation.Jmp
                    ? Operation.Nop
                    : Operation.Jmp
            };
        }

        switch (ins.Operation)
        {
            case Operation.Acc:
                acc += ins.Argument;
                break;

            case Operation.Jmp:
                p += ins.Argument;
                continue;
        }

        p++;
    }

    if (!loop)
    {
        Console.WriteLine(acc);
        break;
    }
}

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
