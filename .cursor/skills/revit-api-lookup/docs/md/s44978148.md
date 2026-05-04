---
kind: property
id: P:Autodesk.Revit.DB.EditScope.IsActive
source: html/b4387ada-7b23-edd0-3836-f7faf47d021e.htm
---
# Autodesk.Revit.DB.EditScope.IsActive Property

Tells if the EditScope is active. In other words, the EditScope has started but not committed/canceled yet.

## Syntax (C#)
```csharp
public bool IsActive { get; }
```

## Remarks
Starting the edit scope is not permitted when it is active.
 Canceling/committing is not allowed when the edit scope is not active.

