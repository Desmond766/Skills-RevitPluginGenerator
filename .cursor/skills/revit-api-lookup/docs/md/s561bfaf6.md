---
kind: method
id: M:Autodesk.Revit.DB.Panel.FindHostPanel
zh: 面板
source: html/412c38f0-a6cc-3d20-4b18-bad93839c986.htm
---
# Autodesk.Revit.DB.Panel.FindHostPanel Method

**中文**: 面板

Finds the id of the host panel (i.e., wall)
associated with this panel. If a host panel is present, then
it is displayed instead of the curtain panel.

## Syntax (C#)
```csharp
public ElementId FindHostPanel()
```

## Returns
Element id of the host panel associated with this panel.
Otherwise, InvalidElementId is returned

