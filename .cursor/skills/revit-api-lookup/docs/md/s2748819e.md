---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.SetParamValue(Autodesk.Revit.DB.SectionType,System.Int32,System.Int32,System.String)
source: html/0686769d-e034-6999-f897-5ee6f94c473b.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.SetParamValue Method

Sets the text for the given cell, returns true if successful, false otherwise

## Syntax (C#)
```csharp
public bool SetParamValue(
	SectionType sectionType,
	int nRow,
	int nCol,
	string sValue
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The associated section
- **nRow** (`System.Int32`) - Row Number of the Section
- **nCol** (`System.Int32`) - Column Number of the Section
- **sValue** (`System.String`) - String value to set the parameter

## Returns
Returns whether the function succeeded

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 Thrown if there is no parameter at this cell
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if attempt to call on a template

