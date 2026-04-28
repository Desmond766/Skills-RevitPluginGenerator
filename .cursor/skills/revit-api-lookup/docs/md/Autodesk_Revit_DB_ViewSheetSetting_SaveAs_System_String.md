---
kind: method
id: M:Autodesk.Revit.DB.ViewSheetSetting.SaveAs(System.String)
source: html/28ae17e9-7706-5844-9dbb-046a161b1749.htm
---
# Autodesk.Revit.DB.ViewSheetSetting.SaveAs Method

Save the current view sheet set to another view sheet set with the specified name.

## Syntax (C#)
```csharp
public bool SaveAs(
	string newName
)
```

## Parameters
- **newName** (`System.String`) - View sheet set name to be saved as.

## Returns
False if Save As operation fails, otherwise True.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the input name is already existed in current view sheet set list.

