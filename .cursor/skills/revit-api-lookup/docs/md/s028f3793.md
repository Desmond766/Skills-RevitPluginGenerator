---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetReadAccessLevel(Autodesk.Revit.DB.ExtensibleStorage.AccessLevel)
source: html/48aa900b-69fa-df08-132b-5046447e9dc1.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetReadAccessLevel Method

Sets top level read access (for entities)

## Syntax (C#)
```csharp
public SchemaBuilder SetReadAccessLevel(
	AccessLevel readAccessLevel
)
```

## Parameters
- **readAccessLevel** (`Autodesk.Revit.DB.ExtensibleStorage.AccessLevel`) - Read access level value to be set

## Returns
The SchemaBuilder object may be used to add more settings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

