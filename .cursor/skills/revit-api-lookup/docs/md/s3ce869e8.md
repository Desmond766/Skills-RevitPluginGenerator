---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.GetSectionData(Autodesk.Revit.DB.SectionType)
source: html/232a1d1e-9112-362c-7539-4ce3b68689b9.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.GetSectionData Method

Gets the writable section data object.

## Syntax (C#)
```csharp
public TableSectionData GetSectionData(
	SectionType sectionType
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`)

## Returns
The table section data object.

## Remarks
Access to this information requires an open transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

