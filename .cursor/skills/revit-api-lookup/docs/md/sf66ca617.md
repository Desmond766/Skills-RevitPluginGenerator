---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.CreateInstanceView(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/e657b335-7266-9ece-6dea-6f2b13a3ce93.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.CreateInstanceView Method

Creates a new instance of this view (using specific template)

## Syntax (C#)
```csharp
public static PanelScheduleView CreateInstanceView(
	Document ADoc,
	ElementId templateId,
	ElementId panelId
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The Document
- **templateId** (`Autodesk.Revit.DB.ElementId`) - The templateId that this function will use
- **panelId** (`Autodesk.Revit.DB.ElementId`) - Element id of the electrical panel element.

## Returns
The PanelScheduleView

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

