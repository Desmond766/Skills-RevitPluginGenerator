---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1(System.String,Autodesk.Revit.DB.ForgeTypeId)
source: html/e5aeaf12-d59f-49be-2da8-08ba044e1517.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Get``1 Method

Retrieves the value of the field in the entity.

## Syntax (C#)
```csharp
public FieldType Get<FieldType>(
	string fieldName,
	ForgeTypeId unitTypeId
)
```

## Parameters
- **fieldName** (`System.String`) - The name of the field to retrieve.
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit to which the value will be converted before returning. Must be compatible with the spec
 specified when creating the Schema.

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
- **Autodesk.Revit.Exceptions.ArgumentException** - The unitTypeId value is not compatible with the field description.
- **Autodesk.Revit.Exceptions.ArgumentException** - This field's subschema prevents reading.

