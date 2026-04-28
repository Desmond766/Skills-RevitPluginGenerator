---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.FooterText
zh: 提示、弹窗、消息框
source: html/7d4acc42-d796-7d44-4f59-fc94c1fb01da.htm
---
# Autodesk.Revit.UI.TaskDialog.FooterText Property

**中文**: 提示、弹窗、消息框

FooterText is used in the footer area of the task dialog.

## Syntax (C#)
```csharp
public string FooterText { get; set; }
```

## Remarks
HTML Hyperlink tags can be used when specifying Footertext. These will work like normal hyperlinks
where clicking them will launch the default browser to the location specified. 
Revit special cases hyperlinks containing the single character '#' to indicate to launch Revit's 
contextual help for the dialog. The Topic passed for the contextul help takes the form H[id] where
id is the Id for the task dialog.

