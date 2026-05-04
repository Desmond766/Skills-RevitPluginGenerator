---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1(Autodesk.Revit.DB.ExtensibleStorage.Field,Autodesk.Revit.DB.ForgeTypeId)
source: html/0bef4bf0-1b80-9e4b-d3ab-73df3bb952d4.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1 Method

Retrieves the value of the field in the entity.

## Syntax (C#)
```csharp
public FieldType Get<FieldType>(
	Field field,
	ForgeTypeId unitTypeId
)
```

## Parameters
- **field** (`Autodesk.Revit.DB.ExtensibleStorage.Field`) - The field to retrieve.
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit to which the value will be converted before returning. Must be compatible with the spec
 specified when creating the Schema.

## Remarks
The template parameter must match the type of the field (specified when creating the
 Schema) exactly; this method does not perform data type conversions. The types for containers are
 IList for arrays and
 IDictionary for maps.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Field belongs to a different Schema from this Entity, or this Entity is invalid.
- **Autodesk.Revit.Exceptions.ArgumentException** - Requested type does not match the field type.
- **Autodesk.Revit.Exceptions.ArgumentException** - The unitTypeId value is not compatible with the field description.
- **Autodesk.Revit.Exceptions.ArgumentException** - This field's subschema prevents reading.

