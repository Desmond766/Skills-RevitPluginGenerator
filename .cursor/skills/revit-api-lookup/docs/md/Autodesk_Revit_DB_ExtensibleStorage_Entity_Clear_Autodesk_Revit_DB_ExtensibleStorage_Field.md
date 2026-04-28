---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Clear(Autodesk.Revit.DB.ExtensibleStorage.Field)
source: html/3845e78b-0c8b-4f81-11fb-5f970891c435.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Clear Method

Resets the field to its default value.

## Syntax (C#)
```csharp
public void Clear(
	Field field
)
```

## Parameters
- **field** (`Autodesk.Revit.DB.ExtensibleStorage.Field`) - The field to clear.

## Remarks
The default value is zero for numeric fields, invalid value for identifiers and
 entities, and empty for strings and containers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Field belongs to a different Schema from this Entity, or this Entity is invalid.
 -or-
 This field's subschema prevents writing.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

