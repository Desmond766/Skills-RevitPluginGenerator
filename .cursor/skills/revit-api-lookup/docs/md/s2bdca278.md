---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides(Autodesk.Revit.DB.CheckoutStatus)
source: html/34582abf-6edd-d9c5-aa00-5d39268ac5a1.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides Method

Returns the graphic overrides associated with a particular ownership status.

## Syntax (C#)
```csharp
public WorksharingDisplayGraphicSettings GetGraphicOverrides(
	CheckoutStatus ownershipStatus
)
```

## Parameters
- **ownershipStatus** (`Autodesk.Revit.DB.CheckoutStatus`) - The ownership status of interest.

## Returns
Returns the graphic overrides assigned to a particular ownership status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

