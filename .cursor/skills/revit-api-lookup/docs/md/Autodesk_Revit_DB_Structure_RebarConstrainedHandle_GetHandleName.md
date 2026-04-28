---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstrainedHandle.GetHandleName
source: html/943f2aba-3e09-5364-c035-28691f643c56.htm
---
# Autodesk.Revit.DB.Structure.RebarConstrainedHandle.GetHandleName Method

Gets the name of the handle.

## Syntax (C#)
```csharp
public string GetHandleName()
```

## Returns
Returns the name of the handle. In case of handles of CustomHandle type it can return null if the .dll that contains the server is not loaded.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstrainedHandle is no longer valid.

