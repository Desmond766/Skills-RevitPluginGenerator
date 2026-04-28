---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides(Autodesk.Revit.DB.ModelUpdatesStatus)
source: html/192a99a8-62d4-7330-6552-5f7256de82eb.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides Method

Returns the graphic overrides assigned to a particular model update status.

## Syntax (C#)
```csharp
public WorksharingDisplayGraphicSettings GetGraphicOverrides(
	ModelUpdatesStatus statusInCentral
)
```

## Parameters
- **statusInCentral** (`Autodesk.Revit.DB.ModelUpdatesStatus`) - The model update status of interest.

## Returns
Returns the graphic overrides assigned to the model update status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

