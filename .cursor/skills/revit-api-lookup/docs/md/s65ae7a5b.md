---
kind: method
id: M:Autodesk.Revit.UI.RadioButtonGroup.AddItem(Autodesk.Revit.UI.ToggleButtonData)
source: html/0d3f2b91-1641-d55c-4265-2cc7005bafe7.htm
---
# Autodesk.Revit.UI.RadioButtonGroup.AddItem Method

Adds a new ToggleButton to the RadioButtonGroup.

## Syntax (C#)
```csharp
public ToggleButton AddItem(
	ToggleButtonData buttonData
)
```

## Parameters
- **buttonData** (`Autodesk.Revit.UI.ToggleButtonData`) - An object containing the data needed to construct the ToggleButton.

## Returns
The newly added ToggleButton.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when buttonData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when button with buttonData.Name already exists in the group.

