---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.ActivateControlsAndDimensionsOnMultiSelect
source: html/fbc9cf7c-8e63-00a8-bf9a-7277d2b5a38b.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.ActivateControlsAndDimensionsOnMultiSelect Property

Indicates whether controls and temporary dimensions are activated on selection of multiple elements.

## Syntax (C#)
```csharp
public bool ActivateControlsAndDimensionsOnMultiSelect { get; set; }
```

## Remarks
Revit always shows certain controls and temporary dimensions for a single selected element
 When this option is set Revit also shows these controls and dimensions when multiple elements are selected.
 Note that this setting takes effect on the next selection change.
 To have this change take effect immediately use Copy C# Selection.SetElementIds(Selection.GetElementIds());

