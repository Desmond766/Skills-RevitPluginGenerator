---
kind: property
id: P:Autodesk.Revit.DB.CompoundStructure.SampleHeight
source: html/8b60783a-a146-a498-0d92-3d5e55dab34e.htm
---
# Autodesk.Revit.DB.CompoundStructure.SampleHeight Property

The sample height is the presumed height of the wall to which the data in this CompoundStructure is applied.

## Syntax (C#)
```csharp
public double SampleHeight { get; set; }
```

## Remarks
This value has meaning only for vertically compound structures.
 In order to apply this CompoundStructure to a wall whose height differs from the sample height,
 the underlying grid will be rescaled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value newSampleHeight is smaller than the value of MinimumSampleHeight.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

