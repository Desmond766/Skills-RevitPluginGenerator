---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AddSimpleField(System.String,System.Type)
source: html/5de0ea30-a58e-4db2-373c-05222a139465.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AddSimpleField Method

Creates a field containing a single value in the Schema, with given name and type.

## Syntax (C#)
```csharp
public FieldBuilder AddSimpleField(
	string fieldName,
	Type fieldType
)
```

## Parameters
- **fieldName** (`System.String`) - The name of the new field.
- **fieldType** (`System.Type`) - The type of the new field.

## Returns
The FieldBuilder object may be used to add more details to the field. Make sure to set
 the unit type if the field contains floating-point values.

## Remarks
The supported types are Boolean, Byte, Int16, Int32, Int64, Float, Double, ElementId,
 GUID, String, XYZ, UV and Entity. Note that data of type ElementId is not copied to new elements that are created via copy/paste or a linear or radial array. Note that a schema may contain a maximum of 256 fields.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The parameter fieldName is not acceptable for naming Extensible Storage objects.
 -or-
 The field type is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

