---
kind: property
id: P:Autodesk.Revit.UI.SplitButton.CurrentButton
source: html/e02be889-7902-eee9-23df-2db54e268487.htm
---
# Autodesk.Revit.UI.SplitButton.CurrentButton Property

Gets or sets the current PushButton of the SplitButton.

## Syntax (C#)
```csharp
public PushButton CurrentButton { get; set; }
```

## Remarks
This property is applicable only if IsSynchronizedWithCurrentItem is true.
The default value of this property will be the first enabled PushButton in the drop down list after the SplitButton is shown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when trying to set the CurrentButton to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when trying to set the CurrentButton to a button which is not in current drop-down list.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when trying to set the CurrentButton if IsSynchronizedWithCurrentItem is false.

