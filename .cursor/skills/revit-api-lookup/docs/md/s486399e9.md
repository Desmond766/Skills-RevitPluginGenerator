---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMinorLayoutAsMaximumSpacing(System.Double,System.Double,System.Double,System.Double)
source: html/f2923888-3c22-97fa-13bf-c5b9affb12fa.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMinorLayoutAsMaximumSpacing Method

Sets the major layout pattern as MaximumSpacing, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMinorLayoutAsMaximumSpacing(
	double overallLength,
	double majorStartOverhang,
	double majorEndOverhang,
	double spacing
)
```

## Parameters
- **overallLength** (`System.Double`) - The entire length of the wire sheet in the major direction.
- **majorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the major direction.
- **majorEndOverhang** (`System.Double`) - The distance from the last wire to the edge of the sheet in the major direction.
- **spacing** (`System.Double`) - The distance between the wires in the minor direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallLength is not a number
 -or-
 The given value for majorStartOverhang is not a number
 -or-
 The given value for majorEndOverhang is not a number
 -or-
 The given value for spacing is not a number
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallLength must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for majorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for majorEndOverhang must be between 0 and 30000 feet.
 -or-
 The given value for spacing must be greater than 0 and no more than 30000 feet.

