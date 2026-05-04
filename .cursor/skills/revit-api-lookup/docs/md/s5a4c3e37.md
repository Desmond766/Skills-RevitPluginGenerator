---
kind: method
id: M:Autodesk.Revit.DB.View.SetFilterVisibility(Autodesk.Revit.DB.ElementId,System.Boolean)
zh: 视图
source: html/d04b73e5-d8f2-f403-5770-6f4a2e0f8857.htm
---
# Autodesk.Revit.DB.View.SetFilterVisibility Method

**中文**: 视图

Sets the visibility of the elements associated with a filter.

## Syntax (C#)
```csharp
public void SetFilterVisibility(
	ElementId filterElementId,
	bool visibility
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the filter.
- **visibility** (`System.Boolean`) - True if the elements associated with the filter are visible in the view, false otherwise.

## Remarks
If the filter is not currently applied to the view, this will add the filter with the specified visibility.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ElementId is not associated with a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

