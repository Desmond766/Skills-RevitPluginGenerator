---
kind: method
id: M:Autodesk.Revit.DB.TableView.GetAvailableParameterCategories(Autodesk.Revit.DB.SectionType,System.Int32)
source: html/ba9bbe03-12e6-f5b4-d817-89a1e05f7f8f.htm
---
# Autodesk.Revit.DB.TableView.GetAvailableParameterCategories Method

Get all available parameter categories.

## Syntax (C#)
```csharp
public IList<ElementId> GetAvailableParameterCategories(
	SectionType sectionType,
	int row
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The section the row lies in.
- **row** (`System.Int32`) - The row.

## Returns
The available parameter categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sectionType is not a valid type for this view.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number row is invalid.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

