---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AddArrayField(System.String,System.Type)
source: html/f20f39f5-152c-98e9-32b7-b8c3bd575e4b.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AddArrayField Method

Creates a field containing an array of values in the Schema, with given name and type
 of contained values.

## Syntax (C#)
```csharp
public FieldBuilder AddArrayField(
	string fieldName,
	Type fieldType
)
```

## Parameters
- **fieldName** (`System.String`) - The name of the new field.
- **fieldType** (`System.Type`) - The type of the contents in the new field.

## Returns
The FieldBuilder object may be used to add more details to the field. Make sure to set
 the unit type if the field contains floating-point values.

## Remarks
The supported types for the contents are the same as for simple fields.
 See AddSimpleField(String, Type) for details.
 Note that a schema may contain a maximum of 256 fields.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The parameter fieldName is not acceptable for naming Extensible Storage objects.
 -or-
 The field type is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

