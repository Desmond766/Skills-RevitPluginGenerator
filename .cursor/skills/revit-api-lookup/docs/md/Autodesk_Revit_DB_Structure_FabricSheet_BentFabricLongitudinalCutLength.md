---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheet.BentFabricLongitudinalCutLength
source: html/2cd7d6f0-b9ce-43cb-2183-1b15a2d95099.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.BentFabricLongitudinalCutLength Property

Specifies the cut length of the fabric sheet perpendicular to the bend edge.

## Syntax (C#)
```csharp
public double BentFabricLongitudinalCutLength { get; set; }
```

## Remarks
Zero indicates that the fabric sheet is not shortened.
 This parameter applies only to bent fabric sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for bentFabricLongitudinalCutLength must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidObjectException** - When setting this property: The data-setting method is not applicable to fabric sheets that are flat.

