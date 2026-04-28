---
kind: type
id: T:Autodesk.Revit.UI.TextBox
source: html/5cfff6ff-3982-e8f7-a3c8-43d93204d41a.htm
---
# Autodesk.Revit.UI.TextBox

The TextBox object represents text-based control that allows the user to enter text.

## Syntax (C#)
```csharp
public class TextBox : RibbonItem
```

## Remarks
The ItemText property inherited from RibbonItem has no effect. 
The text entered in the TextBox is edited by the UI user is accepted only if the user presses the Enter key or click the image button when ShowImageAsButton is true. 
If the user clicks off of this component without pressing Enter or click the image button; then the text will be reverted to the previous value.
Use of this class is not supported in Revit Macros.

