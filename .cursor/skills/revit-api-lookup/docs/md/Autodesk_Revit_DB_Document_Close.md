---
kind: method
id: M:Autodesk.Revit.DB.Document.Close
zh: 文档、文件
source: html/da2f27b9-7255-4950-82a2-86e1432ff9f0.htm
---
# Autodesk.Revit.DB.Document.Close Method

**中文**: 文档、文件

Closes the document, save the changes if there are.

## Syntax (C#)
```csharp
public bool Close()
```

## Returns
False if either closing procedure fails or if saving of a modified document failed. 
Also returns False if closing is cancelled by an external application during 'DocumentClosing' event. 
When function succeeds, True is returned.

## Remarks
The currently active document may not be closed by this function. It can only be closed via Revit's UI.
 The changes will saved automatically, the document will not be closed if failed to save changes.
If the document was created in this current session and has not been saved to a file yet, it needs to call Revit::UI::UIDocument::SaveAndClose() method instead.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to close the currently active document.
Thrown if there are any transactions, sub-transactions or transaction groups which 
were opened by the API code, and not closed. All of these items must be handled 
before attempting to close the document.
Thrown if the PathName is not set yet.
Thrown if the saving target file is read only.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this a linked file.

