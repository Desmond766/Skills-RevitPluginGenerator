---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.SetSpecificFittingAngleStatus(System.Double,System.Boolean)
source: html/799e261d-93b7-062c-efcb-f370550ce67c.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.SetSpecificFittingAngleStatus Method

Sets the status of given specific angle.

## Syntax (C#)
```csharp
public void SetSpecificFittingAngleStatus(
	double angle,
	bool bStatus
)
```

## Parameters
- **angle** (`System.Double`) - The specific angle (in degree) that must be 60, 45, 30, 22.5 or 11.25 degrees.
- **bStatus** (`System.Boolean`) - Status, true - using the given angle during the pipe layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for angle must be 90, 60, 45, 30, 22.5 or 11.25 degrees.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can not set an angle status for an invalid angle.

