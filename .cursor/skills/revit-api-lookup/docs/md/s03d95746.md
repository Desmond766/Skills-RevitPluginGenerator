---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMinorLayoutAsFixedNumber(System.Double,System.Double,System.Double,System.Int32)
source: html/43c7e4cf-b84e-793b-5b4b-2b4d52d384c8.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMinorLayoutAsFixedNumber Method

Sets the major layout pattern as FixedNumber, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMinorLayoutAsFixedNumber(
	double overallLength,
	double majorStartOverhang,
	double majorEndOverhang,
	int numberOfWires
)
```

## Parameters
- **overallLength** (`System.Double`) - The entire length of the wire sheet in the major direction.
- **majorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the major direction.
- **majorEndOverhang** (`System.Double`) - The distance from the last wire to the edge of the sheet in the major direction.
- **numberOfWires** (`System.Int32`) - The number of the wires to set in the minor direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallLength is not a number
 -or-
 The given value for majorStartOverhang is not a number
 -or-
 The given value for majorEndOverhang is not a number
 -or-
 numberOfWires must range from 2 to 1000000.
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallLength must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for majorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for majorEndOverhang must be between 0 and 30000 feet.

