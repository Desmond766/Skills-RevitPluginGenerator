---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsElementsDeletionPermitted
source: html/36a8ce51-3c76-8c7d-832d-4b250c585bf7.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsElementsDeletionPermitted Method

Checks if resolution of the failures by deleting failure elements is permitted.

## Syntax (C#)
```csharp
public bool IsElementsDeletionPermitted()
```

## Returns
True if resolution of the failures by deleting failure elements is permitted.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

