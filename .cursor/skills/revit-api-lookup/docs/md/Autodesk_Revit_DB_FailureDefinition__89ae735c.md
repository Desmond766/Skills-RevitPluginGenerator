---
kind: type
id: T:Autodesk.Revit.DB.FailureDefinition
source: html/b0c061b0-d712-0c41-6054-b8ce8f996256.htm
---
# Autodesk.Revit.DB.FailureDefinition

Defines persistent information about a failure.

## Syntax (C#)
```csharp
public class FailureDefinition : IDisposable
```

## Remarks
Each failure that can be potentially posted in Revit must be based on a FailureDefinition object
 that contains some persistent information about failure such as identity, severity,
 basic description text, types of resolution and default resolution. Each FailureMessage, which
 contains variable part of the information for a specific failure when it occurs, is created with a reference to a registered FailureDefinition.
 In order to be able to post a failure, one must define and register it via FailureDefinition object during Revit Application startup.

