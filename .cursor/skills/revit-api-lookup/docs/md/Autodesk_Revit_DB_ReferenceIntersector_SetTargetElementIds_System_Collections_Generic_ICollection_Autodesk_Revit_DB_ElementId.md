---
kind: method
id: M:Autodesk.Revit.DB.ReferenceIntersector.SetTargetElementIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 射线、射线相交
source: html/600d7702-878d-26ed-e3db-d70b05bb3c6c.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.SetTargetElementIds Method

**中文**: 射线、射线相交

Sets the set of ElementIds to test from in intersection testing.

## Syntax (C#)
```csharp
public void SetTargetElementIds(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The target ElementIds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

