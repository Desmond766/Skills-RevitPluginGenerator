---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1(System.String)
source: html/335c9ebe-8d73-f9e7-631c-7a026972f364.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1 Method

Retrieves the value of the field in the entity.

## Syntax (C#)
```csharp
public FieldType Get<FieldType>(
	string fieldName
)
```

## Parameters
- **fieldName** (`System.String`) - The name of the field to retrieve.

## Remarks
The template parameter must match the type of the field (specified when creating the
 Schema) exactly; this method does not perform data type conversions. The types for containers are
 IList for arrays and
 IDictionary for maps.
This method is a shortcut that will look up the field by name. If you want to call it
 on many entities, it is faster if you look up the field yourself.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Field belongs to a different Schema from this Entity, or this Entity is invalid.
- **Autodesk.Revit.Exceptions.ArgumentException** - Requested type does not match the field type.
- **Autodesk.Revit.Exceptions.ArgumentException** - The name matches no field in this Entity's Schema.
- **Autodesk.Revit.Exceptions.ArgumentException** - For floating-point fields, use the overload taking a ForgeTypeId parameter.
- **Autodesk.Revit.Exceptions.ArgumentException** - This field's subschema prevents reading.

