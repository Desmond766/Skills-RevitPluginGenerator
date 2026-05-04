---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveDistributionSysType(Autodesk.Revit.DB.Electrical.DistributionSysType)
source: html/1170cd1f-0209-53f6-dd7c-f294bc4e3e8f.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveDistributionSysType Method

Remove an existing distribution system type from the project.

## Syntax (C#)
```csharp
public void RemoveDistributionSysType(
	DistributionSysType distributionSysType
)
```

## Parameters
- **distributionSysType** (`Autodesk.Revit.DB.Electrical.DistributionSysType`)

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Distribution system type can be removed only if it is not currently assigned to any devices, otherwise an exception will be thrown.

