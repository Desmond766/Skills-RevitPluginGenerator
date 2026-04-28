---
kind: type
id: T:Autodesk.Revit.UI.PreviewControl
source: html/50112279-5c9d-0351-bbd1-698e76be9e36.htm
---
# Autodesk.Revit.UI.PreviewControl

Presents a preview control to browse the Revit model.

## Syntax (C#)
```csharp
public class PreviewControl : UserControl, 
	IDisposable
```

## Remarks
The dialog or form or window host this preview control must be modal.
The view can be any graphical view but not a non-graphical view. And only one can be active.
The view can be manipulated by embedded view cube and the visibility and graphical settings
set on the view will be evident in the preview control.

