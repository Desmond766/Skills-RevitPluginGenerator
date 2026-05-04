---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsActualSpacing(System.Double,System.Double,System.Double)
source: html/76f4ef42-0dc5-8c84-42dc-27d4898b9ec0.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsActualSpacing Method

Sets the major layout pattern as ActualSpacing, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMajorLayoutAsActualSpacing(
	double overallWidth,
	double minorStartOverhang,
	double spacing
)
```

## Parameters
- **overallWidth** (`System.Double`) - The entire width of the wire sheet in the minor direction.
- **minorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the minor direction.
- **spacing** (`System.Double`) - The distance between the wires in the major direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallWidth is not a number
 -or-
 The given value for minorStartOverhang is not a number
 -or-
 The given value for spacing is not a number
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallWidth must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for minorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for spacing must be greater than 0 and no more than 30000 feet.

