---
kind: method
id: M:Autodesk.Revit.UI.ComboBox.AddItem(Autodesk.Revit.UI.ComboBoxMemberData)
source: html/6cbeeb24-76df-d3af-8a6f-300cefc63f05.htm
---
# Autodesk.Revit.UI.ComboBox.AddItem Method

Adds a new item to the ComboBox.

## Syntax (C#)
```csharp
public ComboBoxMember AddItem(
	ComboBoxMemberData memberData
)
```

## Parameters
- **memberData** (`Autodesk.Revit.UI.ComboBoxMemberData`) - An object containing the data needed to construct the ComboBoxMember.

## Returns
The newly added ComboBoxMember.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when memberData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when button with memberData.Name already exists in the drop-down list.

