---
kind: type
id: T:Autodesk.Revit.UI.RadioButtonGroup
source: html/ab5af3a0-2a19-603c-57c6-f28dd78c5f9c.htm
---
# Autodesk.Revit.UI.RadioButtonGroup

Represents a group of related buttons in the Ribbon.

## Syntax (C#)
```csharp
public class RadioButtonGroup : RibbonItem
```

## Remarks
This class contains a collection of ToggleButtons. Only one of the ToggleButtons will appear active at a given time. 
When a different button is clicked in the UI the current ToggleButton will be changed, and the ToggleButton's external command will be invoked.
Use of this class is not supported in Revit Macros.

