---
kind: method
id: M:Autodesk.Revit.DB.InsulationLiningBase.GetInsulationIds(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/3d2a12de-0c85-da2d-006c-e5b3714ebdf4.htm
---
# Autodesk.Revit.DB.InsulationLiningBase.GetInsulationIds Method

Returns the ids of the insulation elements associated to a given element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetInsulationIds(
	Document document,
	ElementId elemId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element.

## Returns
A collection of the ids of the insulation elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This id does not represent a valid host for insulation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

