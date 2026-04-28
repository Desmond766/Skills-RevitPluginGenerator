---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.SetSubSchemaGUID(System.Guid)
source: html/bac5b4c3-e3b5-a06c-c94c-4a72e074a653.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.SetSubSchemaGUID Method

Sets the GUID of the Schema of the Entities that are intended to be stored in this field.

## Syntax (C#)
```csharp
public FieldBuilder SetSubSchemaGUID(
	Guid guid
)
```

## Parameters
- **guid** (`System.Guid`) - The GUID of the subschema.

## Returns
The FieldBuilder object may be used to add more details to the field.

## Remarks
Fields of type Entity - subentities - need to specify their Schema. The framework
 will prevent subentities with incorrect schemas from being stored in the entity.
 Additionally, the access level of the subschema will be checked against the
 currently executing add-in and access to restricted subentities will be prevented.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.
 -or-
 The field type does not utilize SubSchemas.

