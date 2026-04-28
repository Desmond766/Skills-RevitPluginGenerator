---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.RemoveAddInCommandBinding(Autodesk.Revit.UI.RevitCommandId)
source: html/ebf66326-a8e8-cf68-7421-87b12a0eada8.htm
---
# Autodesk.Revit.UI.UIControlledApplication.RemoveAddInCommandBinding Method

Removes an AddInCommandBinding.

## Syntax (C#)
```csharp
public void RemoveAddInCommandBinding(
	RevitCommandId revitCommandId
)
```

## Parameters
- **revitCommandId** (`Autodesk.Revit.UI.RevitCommandId`) - The Revit command id to identify the command handler you want to remove the binding.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when uiApplication or revitCommandId
is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the given command is not bound with this add-in.

