---
kind: type
id: T:Autodesk.Revit.UI.Events.DialogBoxData
source: html/41f22b16-a68b-8c19-53f6-de079feb756c.htm
---
# Autodesk.Revit.UI.Events.DialogBoxData

An object that is passed to your application when a dialog is displayed in Revit.

## Syntax (C#)
```csharp
public class DialogBoxData : APIObject
```

## Remarks
When the application receives this object, a dialog has been displayed in Revit that
requires user interaction. The OverrideResult function can be used to cause the dialog
to be dismissed and return a desired result code.

