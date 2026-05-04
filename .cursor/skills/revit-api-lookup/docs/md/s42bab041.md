---
kind: property
id: P:Autodesk.Revit.DB.Revision.IssuedBy
source: html/f75eee1c-5fa8-9428-a4be-8fec0136f99d.htm
---
# Autodesk.Revit.DB.Revision.IssuedBy Property

Indicates who has issued or will issue this Revision.

## Syntax (C#)
```csharp
public string IssuedBy { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation cannot be performed on Revisions that have already been issued.

