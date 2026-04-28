---
kind: property
id: P:Autodesk.Revit.UI.UIApplication.MainWindowHandle
source: html/e28d23a9-6814-1e70-9943-1ee852887dae.htm
---
# Autodesk.Revit.UI.UIApplication.MainWindowHandle Property

Get the handle of the Revit main window.

## Syntax (C#)
```csharp
public virtual IntPtr MainWindowHandle { get; }
```

## Remarks
Returns the main window handle of the Revit application. This handle should be used when displaying 
modal dialogs and message windows to insure that they are properly parented. This property replaces
System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle property, which is no longer a reliable 
method of retrieving the main window handle starting with Revit 2019.

