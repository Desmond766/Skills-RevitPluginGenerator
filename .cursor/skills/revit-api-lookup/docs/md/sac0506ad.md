---
kind: method
id: M:Autodesk.Revit.DB.MultiSegmentGrid.GetMultiSegementGridId(Autodesk.Revit.DB.Grid)
source: html/141c947b-7be3-4eee-9a92-627865023bf8.htm
---
# Autodesk.Revit.DB.MultiSegmentGrid.GetMultiSegementGridId Method

Retrieve the element id of the MultiSegmentGrid of which the specified Grid is a member.

## Syntax (C#)
```csharp
public static ElementId GetMultiSegementGridId(
	Grid grid
)
```

## Parameters
- **grid** (`Autodesk.Revit.DB.Grid`) - A Grid.

## Returns
The element id of the associated GridChain. If the Grid is not associated to a GridChain,
 this will return invalidElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

