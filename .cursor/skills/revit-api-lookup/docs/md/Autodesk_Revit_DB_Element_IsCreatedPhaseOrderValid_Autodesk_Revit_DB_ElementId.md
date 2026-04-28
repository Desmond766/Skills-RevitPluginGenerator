---
kind: method
id: M:Autodesk.Revit.DB.Element.IsCreatedPhaseOrderValid(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/b2bcaf7f-c453-d6e2-fd85-083783e935f3.htm
---
# Autodesk.Revit.DB.Element.IsCreatedPhaseOrderValid Method

**中文**: 构件、图元、元素

Returns true if createdPhaseId and demolishedPhaseId are in order.

## Syntax (C#)
```csharp
public bool IsCreatedPhaseOrderValid(
	ElementId createdPhaseId
)
```

## Parameters
- **createdPhaseId** (`Autodesk.Revit.DB.ElementId`) - The createdPhaseId.

## Returns
True if createdPhaseId index is less than or equal to demolishedPhaseId, otherwise returns false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

