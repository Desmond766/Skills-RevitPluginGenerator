---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AddMapField(System.String,System.Type,System.Type)
source: html/ed30389b-a527-c867-3903-ce033f55552c.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AddMapField Method

Creates a field containing an ordered key-value map in the Schema, with given name and
 type of contained values.

## Syntax (C#)
```csharp
public FieldBuilder AddMapField(
	string fieldName,
	Type keyType,
	Type valueType
)
```

## Parameters
- **fieldName** (`System.String`) - The name of the new field.
- **keyType** (`System.Type`) - The type of the keys for the new field.
- **valueType** (`System.Type`) - The type of the values for the new field.

## Returns
The FieldBuilder object may be used to add more details to the field. Make sure to set
 the unit type if the field contains floating-point values.

## Remarks
The supported types for the keys are Boolean, Byte, Int16, Int32, Int64, ElementId,
 GUID and String. Floating-point types (Float, Double, XYZ and UV) are not supported
 because round-off errors frequently cause numeric instability. Subentities are not
 supported because they require a custom comparison operator. The suggested workarounds
 are either placing key values into an Array and using array indices for keys, or
 just using an Array of subentities.
Natural comparison of contained types is used for sorting.
The supported types for values are the same as for simple fields.
 See AddSimpleField(String, Type) for details.
 Note that a schema may contain a maximum of 256 fields.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The parameter fieldName is not acceptable for naming Extensible Storage objects.
 -or-
 The field type is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The combination of key and value types is not supported.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

