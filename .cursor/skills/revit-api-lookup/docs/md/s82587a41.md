---
kind: property
id: P:Autodesk.Revit.DB.Element.IsTransient
zh: 构件、图元、元素
source: html/f391d235-555f-6651-99c6-895fc443f8d8.htm
---
# Autodesk.Revit.DB.Element.IsTransient Property

**中文**: 构件、图元、元素

Indicates whether an element is transient or permanent.

## Syntax (C#)
```csharp
public bool IsTransient { get; }
```

## Remarks
Transient elements are usually created for short term use. This type of element can be created via Document.MakeTransientElements(). Transient and Permanent elements are not allowed to reference each other. A transient element can only refer to other transient elements in the same document. Transient elements also cannot be selected or scheduled, and will not be saved when the document is saved, and will be discarded when the document is closed. Modifying a transient element does not require a transaction, because such elements are not part of the model. As an effect of this, however, creation and modification of transients cannot be undone. Because transient elements are technically not part of the model, they will not be found when using standard element filters, or in any collection of elements Revit returns, such as elements reported in dynamic updaters, etc.

