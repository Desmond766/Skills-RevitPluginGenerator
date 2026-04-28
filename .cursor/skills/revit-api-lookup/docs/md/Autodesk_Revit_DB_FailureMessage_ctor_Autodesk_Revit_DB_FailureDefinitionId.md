---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.#ctor(Autodesk.Revit.DB.FailureDefinitionId)
source: html/5ae69c95-3892-a491-742e-6a8a8a91f99b.htm
---
# Autodesk.Revit.DB.FailureMessage.#ctor Method

Creates a new FailureMessage related to a given FailureDefinition.

## Syntax (C#)
```csharp
public FailureMessage(
	FailureDefinitionId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.FailureDefinitionId`) - Id of FailureDefinition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - id is valid or does not have corresponding failure definition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

