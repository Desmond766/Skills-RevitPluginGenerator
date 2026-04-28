---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Set``1(Autodesk.Revit.DB.ExtensibleStorage.Field,``0)
source: html/fef836d9-61bf-4acb-cdeb-7f03d7f23a51.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Set``1 Method

Stores the value of the field in the entity.

## Syntax (C#)
```csharp
public void Set<FieldType>(
	Field field,
	FieldType value
)
```

## Parameters
- **field** (`Autodesk.Revit.DB.ExtensibleStorage.Field`) - The field to update.
- **value** (`FieldType`)

## Remarks
The template parameter must match the type of the field (specified when creating the
 Schema) exactly; this method does not perform data type conversions. The types for containers are
 IList for arrays and
 IDictionary for maps.
Note that when string values are specified as map keys,
 they are case-insensitive.
This method only modifies your copy of the Entity. Store the Entity in an element or
 another Entity to save the new value. Write access check is not performed on each call
 to Set. Instead, write access is checked when you try to save the Entity in an Element
 or another Entity.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Field belongs to a different Schema from this Entity, or this Entity is invalid.
- **Autodesk.Revit.Exceptions.ArgumentException** - Requested type does not match the field type.
- **Autodesk.Revit.Exceptions.ArgumentException** - For floating-point fields, use the overload taking a ForgeTypeId parameter.
- **Autodesk.Revit.Exceptions.ArgumentException** - This field's subschema prevents writing.
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid floating-point value.
- **Autodesk.Revit.Exceptions.ArgumentException** - String is too long; exceeds max length of 16mb characters.

