---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.IsValidType(Autodesk.Revit.DB.Electrical.PanelScheduleType)
source: html/613065f5-c3e7-2fec-c21f-d223df0d6fe0.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.IsValidType Method

Checks if given type is valid for this panel schedule template element.

## Syntax (C#)
```csharp
public static bool IsValidType(
	PanelScheduleType panelScheduleType
)
```

## Parameters
- **panelScheduleType** (`Autodesk.Revit.DB.Electrical.PanelScheduleType`) - The given type to check.

## Returns
True if panel schedule template can have a type assigned and this type is valid for this element, false otherwise.

## Remarks
A type is valid for a panel schedule template element if it is defined by the PanelScheduleType class.
 Note: PanelScheduleType::Enum::Unknown is not a valid type, it is used for initializing the variable of
 the PanelScheduleType::Enum.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

