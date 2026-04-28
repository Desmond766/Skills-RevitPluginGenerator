---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides(Autodesk.Revit.DB.CheckoutStatus,Autodesk.Revit.DB.WorksharingDisplayGraphicSettings)
source: html/e3cc759d-88b7-05dc-b952-703778273911.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides Method

Sets the graphic overrides assigned to elements with a particular ownership status.

## Syntax (C#)
```csharp
public void SetGraphicOverrides(
	CheckoutStatus status,
	WorksharingDisplayGraphicSettings overrides
)
```

## Parameters
- **status** (`Autodesk.Revit.DB.CheckoutStatus`) - The ownership status of interest.
- **overrides** (`Autodesk.Revit.DB.WorksharingDisplayGraphicSettings`) - The desired graphic overrides for this ownership status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

