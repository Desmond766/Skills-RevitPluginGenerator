---
kind: method
id: M:Autodesk.Revit.DB.ElementType.Duplicate(System.String)
source: html/b0e7d5d5-f33a-8ff2-b471-78a213f06ef5.htm
---
# Autodesk.Revit.DB.ElementType.Duplicate Method

Duplicates an existing element type and assigns it a new name.

## Syntax (C#)
```csharp
public ElementType Duplicate(
	string name
)
```

## Parameters
- **name** (`System.String`) - The new name of the element type.

## Returns
The duplicated element type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The element type name was empty, contained invalid characters, or was invalid for the specific element type.
 -or-
 The name is already in use for this element type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InternalException** - Duplicate element type could not be obtained.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The ElementType cannot be copied.

