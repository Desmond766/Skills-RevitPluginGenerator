---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsMaximumSpacing(System.Double,System.Double,System.Double,System.Double)
source: html/9d0a435c-4dec-544b-921c-c43b89010c38.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsMaximumSpacing Method

Sets the major layout pattern as MaximumSpacing, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMajorLayoutAsMaximumSpacing(
	double overallWidth,
	double minorStartOverhang,
	double minorEndOverhang,
	double spacing
)
```

## Parameters
- **overallWidth** (`System.Double`) - The entire width of the wire sheet in the minor direction.
- **minorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the minor direction.
- **minorEndOverhang** (`System.Double`) - The distance from the last wire to the edge of the sheet in the minor direction.
- **spacing** (`System.Double`) - The distance between the wires in the major direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallWidth is not a number
 -or-
 The given value for minorStartOverhang is not a number
 -or-
 The given value for minorEndOverhang is not a number
 -or-
 The given value for spacing is not a number
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallWidth must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for minorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for minorEndOverhang must be between 0 and 30000 feet.
 -or-
 The given value for spacing must be greater than 0 and no more than 30000 feet.

