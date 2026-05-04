---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.DragOnSelection
source: html/e214ae48-7475-e505-26e1-402caf20f799.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.DragOnSelection Property

Indicates whether elements can be dragged immediately when they are selected.

## Syntax (C#)
```csharp
public bool DragOnSelection { get; set; }
```

## Remarks
When this setting is false, the user must click once to select an element and then must
 explicitly click again in order to drag the element. This option helps users avoid accidentally
 moving elements. When this setting is true, the user can click on an element to select it
 and drag the element immediately by holding down the mouse.

