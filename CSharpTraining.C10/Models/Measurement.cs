namespace CSharpTraining.C10.Models; // file-scoped-namespace-declaration

public readonly struct Measurement
{
    public double Value { get; init; }
    public string Description { get; init; }

    public Measurement()
    {
        Value = double.NaN;
        Description = "Undefined";
    }

    public Measurement(double value, string description)
    {
        Value = value;
        Description = description;
    }

    // record-types-can-seal-tostring
    public override string ToString() => $"{Value} ({Description})";
}
