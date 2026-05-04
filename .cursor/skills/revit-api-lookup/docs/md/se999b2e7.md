---
kind: method
id: M:Autodesk.Revit.DB.Element.IsDemolishedPhaseOrderValid(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/46ec60b6-b1c5-25aa-c544-34379298c7b8.htm
---
# Autodesk.Revit.DB.Element.IsDemolishedPhaseOrderValid Method

**中文**: 构件、图元、元素

Returns true if createdPhaseId and demolishedPhaseId are in order.

## Syntax (C#)
```csharp
public bool IsDemolishedPhaseOrderValid(
	ElementId demolishedPhaseId
)
```

## Parameters
- **demolishedPhaseId** (`Autodesk.Revit.DB.ElementId`) - The demolishedPhaseId.

## Returns
True if createdPhaseId index is less than or equal to demolishedPhaseId, otherwise returns false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

