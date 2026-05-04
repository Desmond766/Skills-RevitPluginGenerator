---
kind: method
id: M:Autodesk.Revit.UI.IControllableDropHandler.CanExecute(Autodesk.Revit.UI.UIDocument,System.Object,Autodesk.Revit.DB.ElementId)
source: html/e1cf8815-cf84-4156-8c29-a1a5821d3fd3.htm
---
# Autodesk.Revit.UI.IControllableDropHandler.CanExecute Method

Implement this method to inform Revit whether the drop event can be executed onto the given view.

## Syntax (C#)
```csharp
bool CanExecute(
	UIDocument document,
	Object data,
	ElementId dropViewId
)
```

## Parameters
- **document** (`Autodesk.Revit.UI.UIDocument`) - The document on which the data was dropped.
- **data** (`System.Object`) - The data.
- **dropViewId** (`Autodesk.Revit.DB.ElementId`) - The view upon which the user will drop.

## Returns
Return true to activate the target view and execute the drop. 
Return false to cancel the activation and the drop execution.

## Remarks
Document modifications are not permitted from this callback.

