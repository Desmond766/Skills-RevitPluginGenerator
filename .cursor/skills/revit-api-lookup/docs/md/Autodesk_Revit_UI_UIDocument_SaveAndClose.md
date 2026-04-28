---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.SaveAndClose
source: html/b7a3b928-bca9-d060-72b6-d7feaa2e8439.htm
---
# Autodesk.Revit.UI.UIDocument.SaveAndClose Method

Close the document, prompting the user for saving it when necessary.

## Syntax (C#)
```csharp
public bool SaveAndClose()
```

## Returns
False if closing procedure fails or if saving of a modified document was requested but failed. 
Also returns False if closing is cancelled by an external application during 'DocumentClosing' event. 
When function succeeds, True is returned.

## Remarks
UI dialogs may be shown during the call (e.g. when the document has been changed since last time it was saved) to get user responses.
The currently active document may not be closed by this function. It can only be closed via Revit's UI.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to close the currently active document.
Thrown if there are any transactions, sub-transactions or transaction groups which 
were opened by the API code, and not closed. All of these items must be handled 
before attempting to close the document.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this a linked file.

