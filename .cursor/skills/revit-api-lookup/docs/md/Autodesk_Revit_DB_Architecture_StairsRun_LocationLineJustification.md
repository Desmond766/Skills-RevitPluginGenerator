---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.LocationLineJustification
source: html/042f94e0-29af-deac-5bcd-baec4075a866.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.LocationLineJustification Property

The position of the run relative to the Up-direction path used to create the run.

## Syntax (C#)
```csharp
public StairsRunJustification LocationLineJustification { get; set; }
```

## Remarks
Only common runs(straight, spiral, winder) have location line justification.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs run is sketched so the data being set is not applicable.

