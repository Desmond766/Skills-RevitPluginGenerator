---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstrainedHandle.GetEdgeNumber
source: html/edf3ea74-a7cb-e8b4-e26d-29baee9b6d60.htm
---
# Autodesk.Revit.DB.Structure.RebarConstrainedHandle.GetEdgeNumber Method

If the RebarConstrainedHandle's RebarHandleType is 'Edge',
 then this function will return the number of the edge that is
 driven by the handle.

## Syntax (C#)
```csharp
public int GetEdgeNumber()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstrainedHandle is no longer valid.
 -or-
 The RebarConstrainedHandle is not of RebarHandleType 'Edge'.

