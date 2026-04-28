---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.SetFailingElement(Autodesk.Revit.DB.ElementId)
source: html/64ae6c54-f61a-e323-b05c-fcb993346b54.htm
---
# Autodesk.Revit.DB.FailureMessage.SetFailingElement Method

Sets the element that has caused the failure.

## Syntax (C#)
```csharp
public FailureMessage SetFailingElement(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The element that has caused the failure.

## Returns
The FailureMessage.

## Remarks
In Revit error dialog this element will be highlighted to the user and can be deleted by user via extended error dialog.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessage is already posted to a document

