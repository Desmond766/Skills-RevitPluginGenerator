---
kind: method
id: M:Autodesk.Revit.UI.SplitButtonData.#ctor(System.String,System.String)
source: html/4419ecd0-2250-a567-a5c4-901d92e99ffd.htm
---
# Autodesk.Revit.UI.SplitButtonData.#ctor Method

Constructs a new instance of SplitButtonData.

## Syntax (C#)
```csharp
public SplitButtonData(
	string name,
	string text
)
```

## Parameters
- **name** (`System.String`) - The internal name of the new button.
- **text** (`System.String`)

## Remarks
This text will be displayed on the button if drop-down is empty. If sub-items are added, 
then the split button will display the current PushButton's text.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when Nothing nullptr a null reference ( Nothing in Visual Basic) is passed for one or more arguments.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when an empty string is passed for one or more arguments.

