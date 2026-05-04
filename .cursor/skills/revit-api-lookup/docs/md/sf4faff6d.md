---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.CreateInstanceView(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/dd63cef1-6086-2e92-aa06-6720df3c9ae6.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.CreateInstanceView Method

Creates a new instance of this view (using default template)

## Syntax (C#)
```csharp
public static PanelScheduleView CreateInstanceView(
	Document ADoc,
	ElementId panelId
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The Document
- **panelId** (`Autodesk.Revit.DB.ElementId`) - Element id of the electrical panel element.

## Returns
The PanelScheduleView

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

