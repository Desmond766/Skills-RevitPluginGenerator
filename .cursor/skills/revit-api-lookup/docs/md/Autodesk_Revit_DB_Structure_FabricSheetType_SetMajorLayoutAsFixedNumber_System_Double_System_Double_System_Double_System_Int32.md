---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsFixedNumber(System.Double,System.Double,System.Double,System.Int32)
source: html/67722d68-3d89-6572-a6cd-44924f628089.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetMajorLayoutAsFixedNumber Method

Sets the major layout pattern as FixedNumber, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetMajorLayoutAsFixedNumber(
	double overallWidth,
	double minorStartOverhang,
	double minorEndOverhang,
	int numberOfWires
)
```

## Parameters
- **overallWidth** (`System.Double`) - The entire width of the wire sheet in the minor direction.
- **minorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the minor direction.
- **minorEndOverhang** (`System.Double`) - The distance from the last wire to the edge of the sheet in the minor direction.
- **numberOfWires** (`System.Int32`) - The number of the wires to set in the major direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for overallWidth is not a number
 -or-
 The given value for minorStartOverhang is not a number
 -or-
 The given value for minorEndOverhang is not a number
 -or-
 numberOfWires must range from 2 to 1000000.
 -or-
 The arguments are not consistent, please specify proper input values.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for overallWidth must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for minorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for minorEndOverhang must be between 0 and 30000 feet.

