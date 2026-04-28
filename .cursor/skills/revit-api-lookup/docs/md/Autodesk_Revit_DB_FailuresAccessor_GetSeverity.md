---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetSeverity
source: html/4ee2ef37-cc39-0464-d587-ed0bfdea4aa7.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetSeverity Method

Provides access to the current failure severity.

## Syntax (C#)
```csharp
public FailureSeverity GetSeverity()
```

## Returns
The highest severity of a failure message currently posted in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

