---
kind: property
id: P:Autodesk.Revit.UI.ComboBox.Current
source: html/114dac7f-7920-964e-4b54-808eb6d96d56.htm
---
# Autodesk.Revit.UI.ComboBox.Current Property

Gets or sets the current checked ComboBox member of the ComboBox.

## Syntax (C#)
```csharp
public ComboBoxMember Current { get; set; }
```

## Remarks
The default value is the first ComboBox member added to the ComboBox.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when trying to set this property to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when trying to set this property to a button not in this ComboBox.

