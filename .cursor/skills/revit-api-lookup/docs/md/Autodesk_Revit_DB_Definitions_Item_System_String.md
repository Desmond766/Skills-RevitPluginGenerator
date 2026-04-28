---
kind: property
id: P:Autodesk.Revit.DB.Definitions.Item(System.String)
source: html/74fd98e3-daac-ca79-ab60-df34473077b8.htm
---
# Autodesk.Revit.DB.Definitions.Item Property

Retrieves a definition by a given name.

## Syntax (C#)
```csharp
public Definition this[
	string name
] { get; }
```

## Parameters
- **name** (`System.String`) - The name of the parameter definition for which to search.

## Remarks
If the definition is not found then Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned.

