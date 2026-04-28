---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides(Autodesk.Revit.DB.ModelUpdatesStatus,Autodesk.Revit.DB.WorksharingDisplayGraphicSettings)
source: html/6fc5ed67-1d76-5039-bd39-4e43af2b1fa0.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides Method

Sets the graphic overrides assigned to elements with a particular status in the central model.

## Syntax (C#)
```csharp
public void SetGraphicOverrides(
	ModelUpdatesStatus status,
	WorksharingDisplayGraphicSettings overrides
)
```

## Parameters
- **status** (`Autodesk.Revit.DB.ModelUpdatesStatus`) - The status in the central model.
- **overrides** (`Autodesk.Revit.DB.WorksharingDisplayGraphicSettings`) - The desired graphic overrides for this status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

