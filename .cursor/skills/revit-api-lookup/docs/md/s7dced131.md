---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewProjectPosition(System.Double,System.Double,System.Double,System.Double)
source: html/6c136686-4e88-5eef-805a-58db2cdb42d1.htm
---
# Autodesk.Revit.Creation.Application.NewProjectPosition Method

Creates a new project position object.

## Syntax (C#)
```csharp
public ProjectPosition NewProjectPosition(
	double ew,
	double ns,
	double elevation,
	double angle
)
```

## Parameters
- **ew** (`System.Double`) - East to West offset in feet.
- **ns** (`System.Double`) - North to South offset in feet.
- **elevation** (`System.Double`) - Elevation above sea level in feet.
- **angle** (`System.Double`) - Rotation angle away from true north in the range of -PI to +PI.

## Remarks
This object contains offset information and is used by the project location object
for setting the project location relative to the site location. Measurements are in feet and
radians.

