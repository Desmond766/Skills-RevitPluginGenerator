---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.SelectPinned
source: html/bf2562c0-7c48-b007-7431-a182b5da79ef.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.SelectPinned Property

Indicates whether pinned elements can be selected.

## Syntax (C#)
```csharp
public bool SelectPinned { get; set; }
```

## Remarks
When this setting is false, the user cannot select most pinned elements in canvas. This option
 helps users avoid accidentally moving important pinned objects such as levels and grids. When
 this option is true, the user can select pinned elements directly.
 Note that to improve usability, the behavior of this option has some added intelligence
 beyond simply checking whether the element is pinned. For example, if a model group is pinned,
 the corresponding attached detail group is not selectable if selection of pinned elements is
 disabled. To check whether a particular element is pinned for purposes of this setting, see
 ElementSelectsAsPinned(Document, Element) .

