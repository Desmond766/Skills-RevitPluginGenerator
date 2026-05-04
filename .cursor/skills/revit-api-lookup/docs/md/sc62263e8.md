---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.DoDragDrop(System.Object,Autodesk.Revit.UI.IDropHandler)
source: html/205f588e-23a2-e41d-b141-b575fccff2e8.htm
---
# Autodesk.Revit.UI.UIApplication.DoDragDrop Method

Initiates a drag and drop operation with a custom drop implementation.

## Syntax (C#)
```csharp
public static void DoDragDrop(
	Object dropData,
	IDropHandler handler
)
```

## Parameters
- **dropData** (`System.Object`) - Any arbitrary data to be passed to the drop handler when the drop occurs.
- **handler** (`Autodesk.Revit.UI.IDropHandler`) - The handler to be executed when the drop occurs.

## Remarks
When the user inputs IControllableDropHandler ,
it allows the handler to verify whether the drop event can be executed on the given view; 
When the user inputs IDropHandler 
the handler will be executed without any condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when dropData or handler is Nothing nullptr a null reference ( Nothing in Visual Basic) .

