---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.DeleteAllWarnings
source: html/c7f9d1a3-6fc0-7aaf-33da-3b31b3ab413e.htm
---
# Autodesk.Revit.DB.FailuresAccessor.DeleteAllWarnings Method

Deletes all FailureMessages of severity "Warning" currently posted in a document.

## Syntax (C#)
```csharp
public void DeleteAllWarnings()
```

## Remarks
Warnings are deleted immediately and will not be accessible by any further failures processing.
 Any accessors for these failure messages become invalid.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

