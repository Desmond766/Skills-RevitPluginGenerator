---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.FindSpaceBoundingElementHandle(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/facc8372-3b66-2b31-135c-852985763186.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.FindSpaceBoundingElementHandle Method

Looks up the handle associated to the element and level id from the ExporterIFC's internal cache.

## Syntax (C#)
```csharp
public IFCAnyHandle FindSpaceBoundingElementHandle(
	ElementId id,
	ElementId levelId
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The Revit element id to look for.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The element level id.

## Returns
The handle associated to the element and level id. If the id is not found in the cache, an empty handle
 is returned (HasValue == false).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

