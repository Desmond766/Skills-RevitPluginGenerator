---
kind: property
id: P:Autodesk.Revit.UI.UIControlledApplication.MainWindowHandle
source: html/a18b37eb-cfa9-198c-bb54-65ca60dd72fa.htm
---
# Autodesk.Revit.UI.UIControlledApplication.MainWindowHandle Property

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

