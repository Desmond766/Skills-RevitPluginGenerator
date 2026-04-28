---
kind: property
id: P:Autodesk.Revit.DB.RevisionCloud.RevisionId
source: html/611e9a5a-f968-152d-707b-de7395f65819.htm
---
# Autodesk.Revit.DB.RevisionCloud.RevisionId Property

The Revision associated with this RevisionCloud.

## Syntax (C#)
```csharp
public ElementId RevisionId { get; set; }
```

## Remarks
This property cannot be set to a Revision that has already been issued. If this RevisionCloud is already associated
 with a Revision that has been issued then this property cannot be changed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: revisionId is not a valid Revision.
 -or-
 When setting this property: This operation cannot be performed because revisionId is an issued Revision.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation cannot be performed on a RevisionCloud associated with a Revision that has been issued.

