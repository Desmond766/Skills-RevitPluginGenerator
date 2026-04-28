---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetVendorId(System.String)
source: html/4b94c68b-5f9c-f798-2619-0bd88a856f37.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.SetVendorId Method

Sets the ID of the third-party vendor that may access entities of this Schema under the
 Vendor acess level, and to generally identify the owner of this Schema.

## Syntax (C#)
```csharp
public SchemaBuilder SetVendorId(
	string vendorId
)
```

## Parameters
- **vendorId** (`System.String`) - The vendor id.

## Returns
The SchemaBuilder object may be used to add more settings.

## Remarks
This method throws an ArgumentException if the given vendor ID string is not valid.
 To understand the validity requirements for vendor ID strings, see the documentation
 for the ESSchemaBuilder method vendorIdIsValid().
Since vendor IDs are not case sensitive, the string will be converted to upper case
 before it is stored in the schema.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The vendorId is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.

