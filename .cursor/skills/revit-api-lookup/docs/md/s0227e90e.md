---
kind: method
id: M:Autodesk.Revit.DB.TableView.IsValidSectionType(Autodesk.Revit.DB.SectionType)
source: html/5c2f17c8-6be8-b344-74fd-1d5c47cf7bca.htm
---
# Autodesk.Revit.DB.TableView.IsValidSectionType Method

Identifies if the section type is valid for this view.

## Syntax (C#)
```csharp
public bool IsValidSectionType(
	SectionType sectionType
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The section type.

## Returns
True if the Section Type is valid, false otherwise.

## Remarks
Some TableViews do not contain all of the possible section types. For
 example, standard schedules have only a Heading and Body.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

