---
kind: property
id: P:Autodesk.Revit.DB.Revision.IssuedTo
source: html/0e7c1d1a-2c48-18db-e633-15995383ef93.htm
---
# Autodesk.Revit.DB.Revision.IssuedTo Property

Indicates to whom this Revision was or will be issued.

## Syntax (C#)
```csharp
public string IssuedTo { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation cannot be performed on Revisions that have already been issued.

