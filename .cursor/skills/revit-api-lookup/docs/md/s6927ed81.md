---
kind: property
id: P:Autodesk.Revit.UI.RadioButtonGroup.Current
source: html/23720f6e-08aa-61f3-6091-e8b8af950145.htm
---
# Autodesk.Revit.UI.RadioButtonGroup.Current Property

Gets or sets the current checked ToggleButton of the RadioButtonGroup.

## Syntax (C#)
```csharp
public ToggleButton Current { get; set; }
```

## Remarks
The default value is the first ToggleButton added to the group.
When using this property to set the current ToggleButton, the external command of that button will not be called.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when trying to set this property to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when trying to set this property to a button not in this group.

