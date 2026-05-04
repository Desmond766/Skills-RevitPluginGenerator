---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricSheet.BentFabricStraightWiresLocation
source: html/beb33ed1-b28b-2e4c-2ea3-51ec4bc4f79a.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.BentFabricStraightWiresLocation Property

Specifies the location of straight bars with respect to bent bars in the fabric sheet.

## Syntax (C#)
```csharp
public BentFabricStraightWiresLocation BentFabricStraightWiresLocation { get; set; }
```

## Remarks
This parameter applies only to bent fabric sheets.
 The side on wich straight wires will be loacted is determined by the start and end point of the first bent profile segment that specifies the direction of the curve loop on plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the data-setting method is not applicable to fabric sheets that are flat
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidObjectException** - When setting this property: The data-setting method is not applicable to fabric sheets that are flat.

