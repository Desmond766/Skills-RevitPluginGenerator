---
kind: method
id: M:Autodesk.Revit.DB.View.IsolateElementTemporary(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/6aa52291-2f4b-27d7-b999-5b5755bd7235.htm
---
# Autodesk.Revit.DB.View.IsolateElementTemporary Method

**中文**: 视图

Set one element to be temporarily isolated in the view.
 To isolate a group completely, you must also include all members of all groups and nested groups in your input, therefore you should use the version of this method that accepts multiple element ids as input.

## Syntax (C#)
```csharp
public void IsolateElementTemporary(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of element to be isolated.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

