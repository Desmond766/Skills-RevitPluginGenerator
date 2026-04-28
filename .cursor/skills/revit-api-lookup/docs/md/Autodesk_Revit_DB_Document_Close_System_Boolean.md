---
kind: method
id: M:Autodesk.Revit.DB.Document.Close(System.Boolean)
zh: 文档、文件
source: html/5948b03d-5537-33d4-6e38-a8f16d5d6779.htm
---
# Autodesk.Revit.DB.Document.Close Method

**中文**: 文档、文件

Closes the document with the option to save.

## Syntax (C#)
```csharp
public bool Close(
	bool saveModified
)
```

## Parameters
- **saveModified** (`System.Boolean`) - Indicates if the current document should be saved before close operation.

## Returns
False if closing procedure fails or if saving of a modified document was requested (saveModified = True) but failed. 
Also returns False if closing is cancelled by an external application during 'DocumentClosing' event. 
When function succeeds, True is returned.

## Remarks
The currently active document may not be closed by this function. It can only be closed via Revit's UI.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to close the currently active document.
Thrown if there are any transactions, sub-transactions or transaction groups which 
were opened by the API code, and not closed. All of these items must be handled 
before attempting to close the document.
Thrown if saveModified is 'true' and the PathName is not set yet.
Thrown if saveModified is 'true' and the saving target file is read only.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this a linked file.

