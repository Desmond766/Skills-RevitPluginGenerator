---
kind: property
id: P:Autodesk.Revit.DB.Element.IsModifiable
zh: 构件、图元、元素
source: html/65f9f835-daaa-3efa-2976-3f932aa18366.htm
---
# Autodesk.Revit.DB.Element.IsModifiable Property

**中文**: 构件、图元、元素

Identifies if the element is modifiable.

## Syntax (C#)
```csharp
public bool IsModifiable { get; }
```

## Remarks
This is not a permanent state. The value depends on the document state. For example, active edit modes can make IsModifiable false for many elements.

