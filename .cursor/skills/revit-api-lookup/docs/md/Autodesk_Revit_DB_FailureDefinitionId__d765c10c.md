---
kind: type
id: T:Autodesk.Revit.DB.FailureDefinitionId
source: html/b6ada360-a6fe-ebb6-b095-d74b37ade9bf.htm
---
# Autodesk.Revit.DB.FailureDefinitionId

The unique identifier of a FailureDefinition.

## Syntax (C#)
```csharp
public class FailureDefinitionId : GuidEnum
```

## Remarks
Each possible failure in Revit must be defined and registered during Revit application startup
 by creating a FailureDefinition object.
 Unique FailureDefinitionId must be used as a key to register FailureDefinition.
 Those unique FailureDefinitionId should be created using GUID generation tool.
 Later FailureDefinitionId can be used to lookup FailureDefinition
 in FailureDefinitionRegistry, and create and post FailureMessages.

