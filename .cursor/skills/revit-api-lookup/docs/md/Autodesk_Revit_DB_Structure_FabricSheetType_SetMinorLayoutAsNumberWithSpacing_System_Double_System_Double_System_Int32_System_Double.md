---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMinorLayoutAsNumberWithSpacing(System.Double,System.Double,System.Int32,System.Double)
source: html/26e9f566-af82-f06f-1a72-25e6eb19fc0b.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMinorLayoutAsNumberWithSpacing Method

Sets the major layout pattern as NumberWithSpacing, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMinorLayoutAsNumberWithSpacing(
	double overallLength,
	double majorStartOverhang,
	int numberOfWires,
	double spacing
)
```

## Parameters
- **overallLength** (`System.Double`) - The entire length of the wire sheet in the major direction.
- **majorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the major direction.
- **numberOfWires** (`System.Int32`) - The number of wires in the minor direction.
- **spacing** (`System.Double`) - The distance between the wires in the minor direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallLength is not a number
 -or-
 The given value for majorStartOverhang is not a number
 -or-
 numberOfWires must range from 2 to 1000000.
 -or-
 The given value for spacing is not a number
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallLength must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for majorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for spacing must be greater than 0 and no more than 30000 feet.

