---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkInstance.GetLinkDocument
zh: 链接模型、链接
source: html/6f81c365-15d9-06b8-48ef-df84914fec60.htm
---
# Autodesk.Revit.DB.RevitLinkInstance.GetLinkDocument Method

**中文**: 链接模型、链接

The document associated with the Revit link.

## Syntax (C#)
```csharp
public Document GetLinkDocument()
```

## Remarks
Operations that require a transaction or modify the document's status in memory (such as Save and Close) cannot be performed on this document.

