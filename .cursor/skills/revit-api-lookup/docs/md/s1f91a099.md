---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1(Autodesk.Revit.DB.ExtensibleStorage.Field)
source: html/3813febc-1c0b-fcae-e4fd-dbbdc3420b75.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1 Method

Retrieves the value of the field in the entity.

## Syntax (C#)
```csharp
public FieldType Get<FieldType>(
	Field field
)
```

## Parameters
- **field** (`Autodesk.Revit.DB.ExtensibleStorage.Field`) - The field to retrieve.

## Remarks
The template parameter must match the type of the field (specified when creating the
 Schema) exactly; this method does not perform data type conversions. The types for containers are
 IList for arrays and
 IDictionary for maps.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Field belongs to a different Schema from this Entity, or this Entity is invalid.
- **Autodesk.Revit.Exceptions.ArgumentException** - Requested type does not match the field type.
- **Autodesk.Revit.Exceptions.ArgumentException** - For floating-point fields, use the overload taking a ForgeTypeId parameter.
- **Autodesk.Revit.Exceptions.ArgumentException** - This field's subschema prevents reading.

