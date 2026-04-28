---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricArea.MajorSheetAlignment
source: html/cc8ee7a1-806a-c522-112f-e38fec71a708.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.MajorSheetAlignment Property

The fabric sheet alignment in the fabric distribution in the major direction.

## Syntax (C#)
```csharp
public FabricSheetAlignment MajorSheetAlignment { get; set; }
```

## Remarks
Changing the value of this property causes change of MajorLapSplice and LapSplicePosition properties if needed

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

