---
kind: property
id: P:Autodesk.Revit.UI.SplitButton.IsSynchronizedWithCurrentItem
source: html/0691fcf0-aa3e-6f9e-7ca8-aaebe21bc6f7.htm
---
# Autodesk.Revit.UI.SplitButton.IsSynchronizedWithCurrentItem Property

Indicates whether the top PushButton on the SplitButton changes based on the CurrentButton property.

## Syntax (C#)
```csharp
public bool IsSynchronizedWithCurrentItem { get; set; }
```

## Remarks
If this property is true the SplitButton uses the current PushButton's properties to display the image, text, tooltip, 
etc. and executes the current item when clicked. If it is false the first listed PushButton in the GetItems() return is shown, 
and executes this PushButton when clicked. 
If it is false the items in drop down list can only be executed by opening the drop down list and clicking an item in the list.
The default value is true.

