---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetFailureMessages
source: html/f8f03cd4-a151-91c6-4569-24597604cc81.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetFailureMessages Method

Provides access to the individual failure messages currently posted in the document.

## Syntax (C#)
```csharp
public IList<FailureMessageAccessor> GetFailureMessages()
```

## Returns
The accessors to the individual failure messages posted in the document.

## Remarks
Returned set of messages will be ordered from more severe to less severe.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

