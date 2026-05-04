---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.HasSameType(Autodesk.Revit.DB.Electrical.PanelScheduleTemplate)
source: html/03c9e112-1fb3-5e42-1114-e99555cd1bfd.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.HasSameType Method

Checks if given template has the same panel schedule type with this template.

## Syntax (C#)
```csharp
public bool HasSameType(
	PanelScheduleTemplate otherTemplate
)
```

## Parameters
- **otherTemplate** (`Autodesk.Revit.DB.Electrical.PanelScheduleTemplate`) - The given template to check.

## Returns
True if the given template has the same panel schedule type with this template, false otherwise.

## Remarks
The panel schedule type is the enum type of PanelScheduleType class (Branch, switchboard, data etc.)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

