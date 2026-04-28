---
kind: type
id: T:Autodesk.Revit.UI.Events.MessageBoxData
source: html/787ef878-c3be-555d-b91f-19089352c4dd.htm
---
# Autodesk.Revit.UI.Events.MessageBoxData

An object that represents a simple message box that prompts the user
for some action.

## Syntax (C#)
```csharp
public class MessageBoxData : DialogBoxData
```

## Remarks
When the application receives this object, a simple message box is displayed in Revit that
requires user interaction. The OverrideResult function can be used to cause the dialog
to be dismissed and return a desired result code.

