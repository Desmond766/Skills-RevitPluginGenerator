---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.MainContent
zh: 提示、弹窗、消息框
source: html/0c2eb583-de3d-58f5-31ea-7ff71eae51a5.htm
---
# Autodesk.Revit.UI.TaskDialog.MainContent Property

**中文**: 提示、弹窗、消息框

MainContent is the smaller text that appears just below the main instructions.

## Syntax (C#)
```csharp
public string MainContent { get; set; }
```

## Remarks
The Main Content is optional. It should be used to give further explanation to the user, such as how to correct the problem or work around the situation. 
It displays in a smaller black font below the main instructions. Follow these guidelines:
 Text should be clear and jargon free. Main content should not simply restate the main instructions in a different way, they should contain additional information 
 that builds upon or reinforces the main instructions. Main content should be written in sentence format (normal capitalization and punctuation). Address the user directly as "you" when needed.

