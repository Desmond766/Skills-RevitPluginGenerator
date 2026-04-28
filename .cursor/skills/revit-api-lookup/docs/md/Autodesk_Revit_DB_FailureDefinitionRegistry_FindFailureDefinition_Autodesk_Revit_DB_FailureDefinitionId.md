---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinitionRegistry.FindFailureDefinition(Autodesk.Revit.DB.FailureDefinitionId)
source: html/b244067c-6296-41db-7b34-1ee6fc69a3a6.htm
---
# Autodesk.Revit.DB.FailureDefinitionRegistry.FindFailureDefinition Method

Finds a specific FailureDefinition by a given FailureDefinitionId.

## Syntax (C#)
```csharp
public FailureDefinitionAccessor FindFailureDefinition(
	FailureDefinitionId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.FailureDefinitionId`) - The id of the FailureDefinition.

## Returns
The accessor of the found FailureDefinition, or null, if the FailureDefinition was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

