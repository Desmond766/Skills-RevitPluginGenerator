---
kind: method
id: M:Autodesk.Revit.UI.RadioButtonGroup.AddItems(System.Collections.Generic.IList{Autodesk.Revit.UI.ToggleButtonData})
source: html/cd056380-098b-f95e-fe1a-a5da1eef2367.htm
---
# Autodesk.Revit.UI.RadioButtonGroup.AddItems Method

Adds new ToggleButtons to the RadioButtonGroup.

## Syntax (C#)
```csharp
public IList<ToggleButton> AddItems(
	IList<ToggleButtonData> buttonData
)
```

## Parameters
- **buttonData** (`System.Collections.Generic.IList < ToggleButtonData >`) - A list of objects containing the data needed to construct the ToggleButtons.

## Returns
The newly added ToggleButtons.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when buttonData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when button with buttonData.Name already exists in the group.

