---
kind: type
id: T:Autodesk.Revit.DB.FailureMessageKey
source: html/f0fa1b40-5df3-ddaf-e38d-85bd438a89e3.htm
---
# Autodesk.Revit.DB.FailureMessageKey

A unique key assigned to each posted failure message

## Syntax (C#)
```csharp
public class FailureMessageKey : IDisposable
```

## Remarks
When a failure message is posted, it gets a unique key assigned and returned to the caller. The key is guaranteed to be unique in the Revit session.
 The key can be used to unpost (delete) previously posted failure message if it is no longer valid.

