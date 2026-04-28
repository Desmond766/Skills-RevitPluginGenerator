---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstrainedHandle.GetCustomHandleTag
source: html/d7552c41-e1e7-c891-c609-7da444492de7.htm
---
# Autodesk.Revit.DB.Structure.RebarConstrainedHandle.GetCustomHandleTag Method

Returns the tag of the handle. The type of the handle should be 'CustomHandle'.

## Syntax (C#)
```csharp
public int GetCustomHandleTag()
```

## Returns
Returns the tag of custom handle.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstrainedHandle is no longer valid.
 -or-
 The RebarConstrainedHandle is not of RebarHandleType 'CustomHandle'.

