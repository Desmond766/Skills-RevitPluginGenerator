---
kind: property
id: P:Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs.DialogId
source: html/7311c9d6-f223-f4c2-0b7a-197e42e5ee61.htm
---
# Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs.DialogId Property

A unique string identifier for DialogBox and TaskDialog type dialogs in Revit.

## Syntax (C#)
```csharp
public string DialogId { get; }
```

## Remarks
The contents of this entry vary depending on the type of dialog which is shown:
 DialogBox: A unique string ID that can be used to identify those whihch dialog has been invoked. TaskDialog: The customed string if TaskDialog.Id is set, empty string for default TaskDialog.Show(). For Revit-created dialog boxes, this
 should always have an assigned value. Standard Message Boxes: this will be an empty string.

