---
kind: property
id: P:Autodesk.Revit.DB.Revision.RevisionDate
source: html/0895e812-4ea9-f128-2ae1-4a1e6c3397bd.htm
---
# Autodesk.Revit.DB.Revision.RevisionDate Property

The date of this Revision.

## Syntax (C#)
```csharp
public string RevisionDate { get; set; }
```

## Remarks
The Revision date is an arbitrary String and can be blank. Revit will not
 attempt to interpret it as an actual date.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation cannot be performed on Revisions that have already been issued.

