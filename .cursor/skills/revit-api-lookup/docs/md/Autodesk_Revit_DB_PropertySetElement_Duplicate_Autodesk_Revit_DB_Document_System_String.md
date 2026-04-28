---
kind: method
id: M:Autodesk.Revit.DB.PropertySetElement.Duplicate(Autodesk.Revit.DB.Document,System.String)
source: html/256ff353-2439-9cf4-ae17-74b0fbbd20d3.htm
---
# Autodesk.Revit.DB.PropertySetElement.Duplicate Method

Creates a duplicate of this PropertySetElement.

## Syntax (C#)
```csharp
public PropertySetElement Duplicate(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the PropertySetElement.
- **name** (`System.String`) - The name to use for the new PropertySetElement.

## Returns
The new PropertySetElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for name is already in use as a property set name.
 -or-
 name is an empty string.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

