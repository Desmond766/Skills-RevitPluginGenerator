---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.SetFailingElements(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/ded7f9de-f807-344d-9344-e8c386f2532d.htm
---
# Autodesk.Revit.DB.FailureMessage.SetFailingElements Method

Sets elements that have caused the failure.

## Syntax (C#)
```csharp
public FailureMessage SetFailingElements(
	ICollection<ElementId> idsToShow
)
```

## Parameters
- **idsToShow** (`System.Collections.Generic.ICollection < ElementId >`) - The elements that have caused the failure.

## Returns
The FailureMessage.

## Remarks
In the Revit error dialog these elements will be highlighted to the user and can be deleted by user via extended error dialog.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessage is already posted to a document

