---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctSettings.SetSpecificFittingAngleStatus(System.Double,System.Boolean)
source: html/9461503b-101d-ff04-6ad4-805578deb5f8.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSettings.SetSpecificFittingAngleStatus Method

Sets the status of given specific angle.

## Syntax (C#)
```csharp
public void SetSpecificFittingAngleStatus(
	double angle,
	bool useInLayout
)
```

## Parameters
- **angle** (`System.Double`) - The specific angle (in degree) that must be one of 60, 45, 30, 22.5 or 11.25 degrees.
- **useInLayout** (`System.Boolean`) - Status, true - using the given angle during the duct layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for angle must be 90, 60, 45, 30, 22.5 or 11.25 degrees.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can not set an angle status for an invalid angle.

