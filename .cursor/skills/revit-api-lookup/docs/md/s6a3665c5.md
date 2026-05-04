---
kind: method
id: M:Autodesk.Revit.DB.View.SetFilterOverrides(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.OverrideGraphicSettings)
zh: 视图
source: html/4f523352-a258-97dc-002f-cf328ca34566.htm
---
# Autodesk.Revit.DB.View.SetFilterOverrides Method

**中文**: 视图

Sets the overrides associated with a filter.

## Syntax (C#)
```csharp
public void SetFilterOverrides(
	ElementId filterElementId,
	OverrideGraphicSettings overrideGraphicSettings
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the filter.
- **overrideGraphicSettings** (`Autodesk.Revit.DB.OverrideGraphicSettings`) - The overrides to apply to the filter.

## Remarks
If the filter is not currently applied to the view, this will add the filter with the assigned overrides.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ElementId is not associated with a FilterElement.
 -or-
 Fill pattern must be a drafting pattern.
 -or-
 Fill pattern Id must be invalidElementId or point to a LinePattern element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

