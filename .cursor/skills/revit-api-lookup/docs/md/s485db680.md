---
kind: method
id: M:Autodesk.Revit.DB.InsulationLiningBase.GetLiningIds(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/b13b6336-657f-1c89-47d6-e9c6dc3f7998.htm
---
# Autodesk.Revit.DB.InsulationLiningBase.GetLiningIds Method

Returns the ids of the lining elements associated to a given element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetLiningIds(
	Document document,
	ElementId elemId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element.

## Returns
A collection of the ids of the lining elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This id does not represent a duct, fitting, or accessory element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

