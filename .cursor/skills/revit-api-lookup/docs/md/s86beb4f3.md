---
kind: method
id: M:Autodesk.Revit.DB.TableData.GetSectionData(Autodesk.Revit.DB.SectionType)
source: html/154fcb09-0a96-d795-5df2-e2ec6ad244d5.htm
---
# Autodesk.Revit.DB.TableData.GetSectionData Method

Returns the pointer to the section data array element at the specified section type.

## Syntax (C#)
```csharp
public TableSectionData GetSectionData(
	SectionType sectionType
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The section type of section data array. If the integral value of the section type is out of the boundary of section data array,
 null is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

