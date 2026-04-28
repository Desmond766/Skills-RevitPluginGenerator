---
kind: type
id: T:Autodesk.Revit.DB.FailureDefinitionRegistry
source: html/30511621-28f7-c6d7-8a5c-071167eb25dd.htm
---
# Autodesk.Revit.DB.FailureDefinitionRegistry

The global registry for all FailureDefinitions in the Revit session.

## Syntax (C#)
```csharp
public class FailureDefinitionRegistry : IDisposable
```

## Remarks
When a FailureDefinition is created, it will be registered in this registry automatically.
 Registration is allowed only during Revit Application startup - after that FailureDefinitionRegistry is locked
 and creation of new FailureDefinitions is not allowed.
 There is only one instance of FailureDefinitionRegistry in session.
 GetFailureDefinitionRegistry () () ()

