---
kind: property
id: P:Autodesk.Revit.DB.Document.IsModifiable
zh: 文档、文件
source: html/af884262-3ba2-b0a0-d7ef-f0a49c1bf1bc.htm
---
# Autodesk.Revit.DB.Document.IsModifiable Property

**中文**: 文档、文件

Identifies if the document is modifiable.

## Syntax (C#)
```csharp
public bool IsModifiable { get; }
```

## Remarks
This is not a permanent state such as, for example IsReadOnlyFile .
 Value of this property changes dynamically multiple times within the life-time of an open document.
 Regardless of the mode a document is opened with, the model can only be modified inside an open transaction.
 Furthermore, even with a transaction open, the model is not always modifiable.
 Though this is rather a rare situation, it can happen, most likely during model regeneration, failure processing, or some events.
 An attempt to modify a non-modifiable document will result in throwing a ModificationOutsideTransactionException.
 See also IsReadOnly

