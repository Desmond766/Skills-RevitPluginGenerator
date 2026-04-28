---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.IsValidParameterDefinitionId(Autodesk.Revit.DB.ElementId)
source: html/df43fe3e-0b93-ef67-c877-eedbaf6a7f49.htm
---
# Autodesk.Revit.DB.ColorFillScheme.IsValidParameterDefinitionId Method

Checks whether the input parameter id can be applied to the scheme.

## Syntax (C#)
```csharp
public bool IsValidParameterDefinitionId(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`)

## Returns
Returns true if the input parameter id can be set to this scheme, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

