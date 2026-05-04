---
kind: property
id: P:Autodesk.Revit.DB.DefinitionGroups.Item(System.String)
source: html/5112ae01-0cf1-d97e-879f-49d171d24097.htm
---
# Autodesk.Revit.DB.DefinitionGroups.Item Property

Retrieve a definition group by name.

## Syntax (C#)
```csharp
public DefinitionGroup this[
	string groupName
] { get; }
```

## Parameters
- **groupName** (`System.String`) - The name of the group for which to search.

## Remarks
If the group is not found then Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned.

