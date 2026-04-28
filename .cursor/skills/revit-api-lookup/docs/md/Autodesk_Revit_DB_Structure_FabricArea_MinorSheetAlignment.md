---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricArea.MinorSheetAlignment
source: html/95451caf-0948-3236-be43-892771a42c26.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.MinorSheetAlignment Property

The fabric sheet alignment in the fabric distribution in the minor direction.

## Syntax (C#)
```csharp
public FabricSheetAlignment MinorSheetAlignment { get; set; }
```

## Remarks
Changing the value of this property causes change of MinorLapSplice and LapSplicePosition properties if needed

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

