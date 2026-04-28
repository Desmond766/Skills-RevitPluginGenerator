---
kind: method
id: M:Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs.OverrideResult(System.Int32)
source: html/49ba2725-74c9-02b3-4321-eac1f2295bd3.htm
---
# Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs.OverrideResult Method

Call this method to cause the Autodesk Revit dialog to be dismissed with the specified return value.

## Syntax (C#)
```csharp
public bool OverrideResult(
	int resultCode
)
```

## Parameters
- **resultCode** (`System.Int32`) - The result code you wish the Revit dialog to return.

## Returns
True if the result code was accepted.

## Remarks
The range of valid result values depends on the type of dialog as follows:
DialogBox: Any non-zero value will cause a dialog to be dismissed.
MessageBox: Standard Message Box IDs, such as IDOK and IDCANCEL, are accepted.
 For all possible IDs, refer to the Windows API documentation.
 The ID used must be relevant to the buttons in a message box.
TaskDialog: Standard Message Box IDs and Revit Custom IDs are accepted,
 depending on the buttons used in a dialog. Standard buttons, such as OK
 and Cancel, have standard IDs described in Windows API documentation.
 Buttons with custom text have custom IDs with incremental values
 starting at 1001 for the left-most or top-most button in a task dialog.

