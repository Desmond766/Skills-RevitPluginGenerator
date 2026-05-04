---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.GetAssociatedElementIds(Autodesk.Revit.DB.ElementId)
source: html/f3710676-cd32-eb7d-59aa-8a11be872ba9.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.GetAssociatedElementIds Method

Returns ids of the elements which are in association with the element with the given ElementId.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAssociatedElementIds(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element id for which we want to get the associated elements.

## Returns
Ids of the associated elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

