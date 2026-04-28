---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.CopyFrom(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Electrical.PanelScheduleTemplate)
source: html/9d71d5fd-d9bb-dd85-d58d-709e089e9d2b.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.CopyFrom Method

Copies all values from other element to this object.

## Syntax (C#)
```csharp
public void CopyFrom(
	Document OtherADoc,
	PanelScheduleTemplate otherElem
)
```

## Parameters
- **OtherADoc** (`Autodesk.Revit.DB.Document`) - The Document for the otherElem
- **otherElem** (`Autodesk.Revit.DB.Electrical.PanelScheduleTemplate`) - The element being copied from.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given template otherElem has different type of this element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

