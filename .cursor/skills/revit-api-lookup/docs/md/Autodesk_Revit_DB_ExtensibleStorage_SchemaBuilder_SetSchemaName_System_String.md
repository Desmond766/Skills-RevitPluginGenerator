---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetSchemaName(System.String)
source: html/f53b3048-99f8-0dbc-f623-f997ab673932.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetSchemaName Method

Sets the name of the Schema.

## Syntax (C#)
```csharp
public SchemaBuilder SetSchemaName(
	string schemaName
)
```

## Parameters
- **schemaName** (`System.String`) - The name for the Schema.

## Returns
The SchemaBuilder object may be used to add more settings.

## Remarks
The name is a user-friendly identifier of the Schema. GUIDs are used exclusively
 for Schema identity, but the name is useful to identify the Schema during development
 or in an error message.
This field is required.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The parameter schemaName is not acceptable for naming Extensible Storage objects.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

