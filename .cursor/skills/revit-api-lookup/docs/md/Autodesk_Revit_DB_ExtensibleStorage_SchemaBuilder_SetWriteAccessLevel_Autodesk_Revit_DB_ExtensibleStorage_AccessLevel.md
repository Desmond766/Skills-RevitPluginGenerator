---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetWriteAccessLevel(Autodesk.Revit.DB.ExtensibleStorage.AccessLevel)
source: html/5d9b9a09-dd20-a79f-4e43-1f0365ed75be.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetWriteAccessLevel Method

Sets top level write access (for entities)

## Syntax (C#)
```csharp
public SchemaBuilder SetWriteAccessLevel(
	AccessLevel writeAccessLevel
)
```

## Parameters
- **writeAccessLevel** (`Autodesk.Revit.DB.ExtensibleStorage.AccessLevel`) - Write access level value to be set

## Returns
The SchemaBuilder object may be used to add more settings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

