---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.Finish
source: html/399ce458-d43f-57a1-52f4-f862b243edec.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.Finish Method

Registers and returns the created Schema object.

## Syntax (C#)
```csharp
public Schema Finish()
```

## Returns
The newly created Schema.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The SchemaBuilder has already finished building the Schema.
 -or-
 A different Schema with a matching identity already exists.
 -or-
 Two fields with the same name are detected.
 -or-
 At least one field has invalid units.
 -or-
 SchemaName is not set.
 -or-
 VendorId is not set for a restricted access level.
 -or-
 ApplicationGUID is not set for an application access level.
 -or-
 More than 256 fields were added to the schema.

