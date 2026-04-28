---
kind: method
id: M:Autodesk.Revit.DB.Document.GetWarnings
zh: 文档、文件
source: html/4774613d-600a-e1b5-b5aa-f1ee3b14394c.htm
---
# Autodesk.Revit.DB.Document.GetWarnings Method

**中文**: 文档、文件

Returns list of failure messages generated from persistent (reviewable) warnings accumulated in the document.

## Syntax (C#)
```csharp
public IList<FailureMessage> GetWarnings()
```

## Returns
List of failure messages representing warnings accumulated in the document.

## Remarks
Function returns list of failure messages identical to the list displayed in a warning dialog when command
 Manage tab->Inquiry pane->Review Warnings is issued through the UI. Operations performed on the returned list by the caller
 do not impact information about warnings stored in the document.

