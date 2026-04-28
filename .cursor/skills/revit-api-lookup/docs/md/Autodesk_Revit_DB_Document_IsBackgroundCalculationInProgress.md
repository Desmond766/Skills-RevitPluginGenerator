---
kind: method
id: M:Autodesk.Revit.DB.Document.IsBackgroundCalculationInProgress
zh: 文档、文件
source: html/d465e75a-0fc5-33c1-9d5e-dc711bcaef49.htm
---
# Autodesk.Revit.DB.Document.IsBackgroundCalculationInProgress Method

**中文**: 文档、文件

Indicates whether there are any background calculations in progress for this document.

## Syntax (C#)
```csharp
public bool IsBackgroundCalculationInProgress()
```

## Returns
Returns true if the document has any data calculation in progress and false otherwise.

## Remarks
When a document has background calculations in progress, users cannot perform the following operations:
 Save/Close the document. Export/Print the document. Synchronize to central, in worksharing environment. Create a steel element. Copy/Mirror/Rotate a steel element. Edit the sketch of plate element. Edit a custom connection.

