---
kind: property
id: P:Autodesk.Revit.DB.Analysis.HVACLoadSpaceType.SpaceTypeName
source: html/cce2ca16-7412-3c71-750e-b70e4eb675fc.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadSpaceType.SpaceTypeName Property

The space type name.

## Syntax (C#)
```csharp
public string SpaceTypeName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: name is an empty string or contains only whitespace.
 -or-
 When setting this property: name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 When setting this property: The given value for name is already in use as a space type name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

