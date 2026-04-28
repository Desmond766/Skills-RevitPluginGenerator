---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsNumberWithSpacing(System.Double,System.Double,System.Int32,System.Double)
source: html/f90b996d-9897-2822-05df-01e3dd6e0031.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsNumberWithSpacing Method

Sets the major layout pattern as NumberWithSpacing, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMajorLayoutAsNumberWithSpacing(
	double overallWidth,
	double minorStartOverhang,
	int numberOfWires,
	double spacing
)
```

## Parameters
- **overallWidth** (`System.Double`) - The entire width of the wire sheet in the minor direction.
- **minorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the minor direction.
- **numberOfWires** (`System.Int32`) - The number of the wires to set in the major direction.
- **spacing** (`System.Double`) - The distance between the wires in the major direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallWidth is not a number
 -or-
 The given value for minorStartOverhang is not a number
 -or-
 numberOfWires must range from 2 to 1000000.
 -or-
 The given value for spacing is not a number
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallWidth must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for minorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for spacing must be greater than 0 and no more than 30000 feet.

