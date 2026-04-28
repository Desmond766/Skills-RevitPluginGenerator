---
kind: method
id: M:Autodesk.Revit.UI.PulldownButton.AddPushButton(Autodesk.Revit.UI.PushButtonData)
source: html/e4c7cf52-8ae4-b5af-8289-29ef64ee22f6.htm
---
# Autodesk.Revit.UI.PulldownButton.AddPushButton Method

Adds a new pushbutton to the pulldown button and associates it with an ExternalCommand.

## Syntax (C#)
```csharp
public PushButton AddPushButton(
	PushButtonData buttonData
)
```

## Parameters
- **buttonData** (`Autodesk.Revit.UI.PushButtonData`) - An object containing the data needed to construct the pushbutton.

## Returns
The newly added pushbutton.

## Remarks
The new button will display its large image if PushButton.LargeImage is set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when buttonData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when button with buttonData.Name already exists in the button.

