---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.Title
zh: 提示、弹窗、消息框
source: html/848f5f55-e02c-34bc-58c1-0cd49662cdd8.htm
---
# Autodesk.Revit.UI.TaskDialog.Title Property

**中文**: 提示、弹窗、消息框

Title of the task dialog.

## Syntax (C#)
```csharp
public string Title { get; set; }
```

## Remarks
Titles of task dialogs should be unique. Do not reuse the same title for multiple task dialogs. Newline characters are not allowed in Title. 
When the dialogs is shown, Revit will put "External Command Name –" or "External Application –" in the front of the value by default. Examples:
 Plug-in Name – No Rooms to Calculate Plug-in Name – Invalid Value for Length 
You can suppress it by setting TitleAutoPrefix to false.
Titles should describe the nature of the problem or state the situation that currently exists. 
The title tells the user why they are getting the message, not what they are supposed to do.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when setting the value to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting the value to an empty string or string contains newline characters.

