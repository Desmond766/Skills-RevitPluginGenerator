---
kind: property
id: P:Autodesk.Revit.DB.LinkLoadResult.IsCircularLink
source: html/9d3b2a62-a121-a9c3-b3e8-5c55295eec7d.htm
---
# Autodesk.Revit.DB.LinkLoadResult.IsCircularLink Property

True if these results are part of a link cycle.

## Syntax (C#)
```csharp
public bool IsCircularLink { get; }
```

## Remarks
A link cycle occurs when, for example, model A links model B as an attachment,
 which links model C as an attachment, which links model A as an attachment.
 Revit will only load one copy of model A; it will ignore the instance of A linked
 under C.
Circular links do not abort the load process, so they do not appear as a result type
 in LinkLoadResultType.Enum.
This property is only relevant for LinkLoadResult object for RvtLinkSymbol.
 ie. when getIsRvtLink() is true.

