---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleData.AddLoadClassification(Autodesk.Revit.DB.ElementId)
source: html/756df300-6d02-f9b3-e57b-165eb7900179.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleData.AddLoadClassification Method

Add a Load Classification Id to the array of Load Classifications.

## Syntax (C#)
```csharp
public bool AddLoadClassification(
	ElementId loadClassficationId
)
```

## Parameters
- **loadClassficationId** (`Autodesk.Revit.DB.ElementId`) - The load classification to add

## Returns
True if success; false if the given Id has already existed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

