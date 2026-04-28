---
kind: property
id: P:Autodesk.Revit.DB.Reference.LinkedElementId
source: html/97813744-6e64-00a7-da5c-b2c6de7919ad.htm
---
# Autodesk.Revit.DB.Reference.LinkedElementId Property

The id of the top-level element in the linked document that is referred to by this reference.

## Syntax (C#)
```csharp
public ElementId LinkedElementId { get; }
```

## Remarks
InvalidElementId will be returned for references that don't refer to an element in a linked RVT file.

