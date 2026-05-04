---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheet.BentFabricBendDirection
source: html/0a69fdd3-8c45-d097-19c2-fb07a6a8f5cf.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.BentFabricBendDirection Property

Specifies which wire direction of the fabric sheet is bent.

## Syntax (C#)
```csharp
public BentFabricBendDirection BentFabricBendDirection { get; set; }
```

## Remarks
This parameter applies only to bent fabric sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the data-setting method is not applicable to fabric sheets that are flat
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidObjectException** - When setting this property: The data-setting method is not applicable to fabric sheets that are flat.

