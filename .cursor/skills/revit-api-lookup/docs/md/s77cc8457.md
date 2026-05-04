---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.GetDisplacementElementId(Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/c4790d71-c7a4-b298-8428-035de9981392.htm
---
# Autodesk.Revit.DB.DisplacementElement.GetDisplacementElementId Method

The element id of the DisplacementElement that includes the specified element.

## Syntax (C#)
```csharp
public static ElementId GetDisplacementElementId(
	View view,
	ElementId id
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element id.

## Returns
The element id of DisplacementElement that includes the specified element id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

