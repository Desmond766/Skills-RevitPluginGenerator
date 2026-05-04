---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.SelectUnderlay
source: html/af559e78-19d9-a193-f276-d5791e360140.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.SelectUnderlay Property

Indicates whether elements that are displayed as underlay can be selected.

## Syntax (C#)
```csharp
public bool SelectUnderlay { get; set; }
```

## Remarks
When this setting is false, if an element is displayed as underlay in a view then the user will
 not be able to select it in that view. The element may still be selected in views where it
 is not displayed as underlay. When this setting is true, elements that are displayed as underlay
 may still be selected.

