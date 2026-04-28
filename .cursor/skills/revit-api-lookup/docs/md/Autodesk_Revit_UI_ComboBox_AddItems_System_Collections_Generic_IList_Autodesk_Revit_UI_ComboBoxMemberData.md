---
kind: method
id: M:Autodesk.Revit.UI.ComboBox.AddItems(System.Collections.Generic.IList{Autodesk.Revit.UI.ComboBoxMemberData})
source: html/3fef4a5e-1d55-2c8a-33ed-13a29d269e31.htm
---
# Autodesk.Revit.UI.ComboBox.AddItems Method

Adds a new items to the ComboBox.

## Syntax (C#)
```csharp
public IList<ComboBoxMember> AddItems(
	IList<ComboBoxMemberData> memberData
)
```

## Parameters
- **memberData** (`System.Collections.Generic.IList < ComboBoxMemberData >`) - An object list containing the data needed to construct the ComboBoxMember.

## Returns
The newly added ComboBoxMembers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when memberData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when button with memberData.Name already exists in the drop-down list.

