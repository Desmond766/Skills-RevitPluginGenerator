---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.Clear(System.String)
source: html/c88bab39-03cd-35e1-fc61-d2be7f365a97.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.Clear Method

Resets the field to its default value.

## Syntax (C#)
```csharp
public void Clear(
	string fieldName
)
```

## Parameters
- **fieldName** (`System.String`) - The name of the field to clear.

## Remarks
The default value is zero for numeric fields, invalid value for identifiers and
 entities, and empty for strings and containers.
This method is a shortcut that will look up the field by name. If you want to call it
 on many entities, it is faster if you look up the field yourself.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name matches no field in this Entity's Schema.
 -or-
 This field's subschema prevents writing.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Entity is invalid.

