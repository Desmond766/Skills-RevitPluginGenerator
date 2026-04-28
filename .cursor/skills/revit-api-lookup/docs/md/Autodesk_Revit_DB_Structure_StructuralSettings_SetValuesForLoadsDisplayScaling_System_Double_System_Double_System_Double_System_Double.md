---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSettings.SetValuesForLoadsDisplayScaling(System.Double,System.Double,System.Double,System.Double)
source: html/e3a18f6d-3d95-b910-c33d-b678c6c57df5.htm
---
# Autodesk.Revit.DB.Structure.StructuralSettings.SetValuesForLoadsDisplayScaling Method

Sets values for loads display scaling by providing two load forces and their corresponding length of the representative lines in internal units.

## Syntax (C#)
```csharp
public void SetValuesForLoadsDisplayScaling(
	double minimumLoadValue,
	double minimumForceLineLength,
	double maximumLoadValue,
	double maximumForceLineLength
)
```

## Parameters
- **minimumLoadValue** (`System.Double`) - The minimum force in SpecTypeId.Force units.
- **minimumForceLineLength** (`System.Double`) - The line length for minimum force.
- **maximumLoadValue** (`System.Double`) - The maximum force in SpecTypeId.Force units.
- **maximumForceLineLength** (`System.Double`) - The line length for maximum force.

## Remarks
Use UnitUtils class methods to convert value from or to internal units.
 The values are used to scale the representation of all load types(point, line and area loads).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when:
 - forces are negative.
 - line lengths are negative.
 - minimum force is greater or equal to the maximum force.
 - line length for minimum force is greater than line length for maximum force.

