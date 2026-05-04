---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GenerateInstanceFromTemplate(Autodesk.Revit.DB.ElementId)
source: html/542faccb-031b-6579-8d70-3f166a1821ca.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GenerateInstanceFromTemplate Method

Assigns the data from the template to the instance and performs any tasks specific to the instance (3rd phase, borders, etc)

## Syntax (C#)
```csharp
public void GenerateInstanceFromTemplate(
	ElementId templateId
)
```

## Parameters
- **templateId** (`Autodesk.Revit.DB.ElementId`) - Element id of the template element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

