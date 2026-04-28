---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.CreateAddInCommandBinding(Autodesk.Revit.UI.RevitCommandId)
source: html/ea28c2a3-378c-146d-ca27-d14145a1d9cf.htm
---
# Autodesk.Revit.UI.UIControlledApplication.CreateAddInCommandBinding Method

Creates a new AddInCommandBinding.

## Syntax (C#)
```csharp
public AddInCommandBinding CreateAddInCommandBinding(
	RevitCommandId revitCommandId
)
```

## Parameters
- **revitCommandId** (`Autodesk.Revit.UI.RevitCommandId`) - The Revit command id to identify the command handler you want to replace.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when uiApplication or revitCommandId
is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the given command already has been bound.

