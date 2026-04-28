---
kind: method
id: M:Autodesk.Revit.UI.TableViewUIUtils.TestCellAndPromptToEditTypeParameter(Autodesk.Revit.DB.TableView,Autodesk.Revit.DB.SectionType,System.Int32,System.Int32)
source: html/0b44f494-b249-822e-6d2b-61064169b511.htm
---
# Autodesk.Revit.UI.TableViewUIUtils.TestCellAndPromptToEditTypeParameter Method

Prompts the end-user to control whether a type parameter contained in the specified table cell should be allowed edited.

## Syntax (C#)
```csharp
public static bool TestCellAndPromptToEditTypeParameter(
	TableView tableView,
	SectionType sectionType,
	int row,
	int column
)
```

## Parameters
- **tableView** (`Autodesk.Revit.DB.TableView`) - The table view.
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The section the row lies in.
- **row** (`System.Int32`) - The row index in the section.
- **column** (`System.Int32`) - The column index in the section.

## Returns
Returns true if editing the cell is allowed; otherwise false.

## Remarks
If the specified cell contains an instance parameter, the method automatically returns true without prompting the user.
 For type parameters, a task dialog will be shown and the user's choice will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number row is invalid.
 -or-
 The given column number column is invalid.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

