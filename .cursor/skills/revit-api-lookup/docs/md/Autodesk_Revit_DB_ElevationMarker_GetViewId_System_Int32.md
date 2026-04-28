---
kind: method
id: M:Autodesk.Revit.DB.ElevationMarker.GetViewId(System.Int32)
source: html/a66f506d-5a5f-9a14-5b7b-aacf46c8f08d.htm
---
# Autodesk.Revit.DB.ElevationMarker.GetViewId Method

Returns the ViewSection id for the index of the ElevationMarker.

## Syntax (C#)
```csharp
public ElementId GetViewId(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the ElevationMarker for which a ViewSection id will be returned.

## Returns
ViewSection id of the view at the ElevationMarker index, invalid element id otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index index is out of range for this ElevationMarker.

