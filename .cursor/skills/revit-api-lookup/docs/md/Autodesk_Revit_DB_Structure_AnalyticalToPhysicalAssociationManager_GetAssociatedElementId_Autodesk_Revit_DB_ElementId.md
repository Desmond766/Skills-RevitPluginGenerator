---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.GetAssociatedElementId(Autodesk.Revit.DB.ElementId)
source: html/59274411-94e7-633b-2d9e-8989a903cc48.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.GetAssociatedElementId Method

Returns id of the element which is in association with the element with the given ElementId.

## Syntax (C#)
```csharp
public ElementId GetAssociatedElementId(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element id for which we want to get the associated element.

## Returns
Id of the associated element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

