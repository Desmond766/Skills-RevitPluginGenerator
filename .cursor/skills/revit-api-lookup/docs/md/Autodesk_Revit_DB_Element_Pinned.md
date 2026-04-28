---
kind: property
id: P:Autodesk.Revit.DB.Element.Pinned
zh: 构件、图元、元素
source: html/c37bc7f9-409e-9b8a-f491-f700228985e2.htm
---
# Autodesk.Revit.DB.Element.Pinned Property

**中文**: 构件、图元、元素

Identifies if the element has been pinned to prevent changes.

## Syntax (C#)
```csharp
public bool Pinned { get; set; }
```

## Remarks
An element which is pinned may not be moved, and warnings will be issued
 when an attempt is made to delete it.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Element cannot be pinned or unpinned.

