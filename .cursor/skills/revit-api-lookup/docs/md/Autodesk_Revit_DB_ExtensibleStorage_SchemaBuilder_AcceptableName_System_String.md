---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AcceptableName(System.String)
source: html/0ac1f229-14e3-6039-22f1-1d6b40a000de.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.AcceptableName Method

Checks whether a string is an acceptable name for a Schema or a Field.

## Syntax (C#)
```csharp
public bool AcceptableName(
	string name
)
```

## Parameters
- **name** (`System.String`) - The string to check.

## Returns
True if the name is acceptable.

## Remarks
For interoperability, names are required to be usable as C++ identifiers.
 The allowable characters are ASCII letters, numbers (except the first character) and
 underscore. The length must be between 1 and 247 characters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

